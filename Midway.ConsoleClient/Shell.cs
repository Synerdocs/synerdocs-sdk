using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using Midway.Crypto;
using Midway.ObjectModel;
using Midway.ObjectModel.Common;
using Midway.ObjectModel.Exceptions;
using Midway.ObjectModel.Extensions;
using Midway.ServiceClient;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// 
    /// </summary>
    public class Shell
    {
        private ClientContext context;
        private List<UserInput.Option> departmentsOptions;
        private int index = 0;
        private string applicationId = "45EFA3B0-4302-4CF6-95AD-5ACA21EE2FA2";

        /*

         Пример демонстрирует:
         * [+] авторизация по логину паролю
         * [+] авторизация по сертификату
         * [+] отправка подписанного НД
         * [+] подписание НД
         * [+] отказ от подписи под НД
         * [+] отправка ИОД для НД
         * [+] прием СД для НД (ИОП, УОУ, Подпись)
         * [+] отправка ЭСФ
         * [+] отправка СД для ЭСФ
         * [+] прием СД для ЭСФ
         * [+] работа с черновиками сообщений
         * [-] работа с контактами
         * [+] отправка нескольких документов
         * [+] обработка ошибок
         * [-] SSL
         * [+] загрузка большого документа (>1Мб)
         * [-] повторная отправка сообщения
         * [+-] загрузка, сохранение документа и документооборота на диск
         * [+] отображение подписи входящего документа
        */
        public void Run(string[] args)
        {
            var url = args[0];

            // Выбор нужной конечной точки в клиенте, т.к. конфиг не позволяет задать это одновременно простым способом
            // нужно, чтобы можно было заходить как по http, так и по https через консольный клиент
            // Bug 7733:В консольном клиенте не работает авторизация
            var configEndpointName = url.StartsWith("https") ?
                "WSHttpsBinding_IExchangeService" :
                "WSHttpBinding_IExchangeService";

            // принять url
            var client = new Client(url, enableTracing: false, useStreamRequest: false, configEndpointName: configEndpointName);

            try
            {
                context = new ClientContext
                {
                    ServiceClient = client,
                    //MessageFactory = new MessageFactory(client)
                };

                // аутентификация
                Auth(client);

                // следующие команды ...
                var commandsMap = new Dictionary<string, Tuple<Action, string>>()
                {
                    {"get-boxes", Tuple.Create<Action,string>(Boxes, "Показать список ящиков")} ,
                    {"set-box", Tuple.Create<Action,string>(SetBox, "Выбрать ящик")} ,
                    {"load-messages", Tuple.Create<Action,string>(LoadMessages, "Загрузить и обработать входящие сообщения")},
                    {"send-docs", Tuple.Create<Action,string>(() => SendDocuments(FlowType.SentSigned), "Отправить документы")},
                    {"send-unsigned", Tuple.Create<Action,string>(() => SendDocuments(FlowType.SentUnsigned), "Отправить документы без подписи")},
                    {"send-forward", Tuple.Create<Action,string>(() => SendDocuments(FlowType.SentForward), "Переслать документы")},
                    {"send-internal", Tuple.Create<Action,string>(() => SendDocuments(FlowType.SentInternal), "Отправить документы подразделению")},
                    {"sign-document", Tuple.Create<Action,string>(SignDocument, "Подписать документ")},
                    {"reject-sign", Tuple.Create<Action,string>(RejectSign, "Отказать в подписании документа")},
                    {"move-docs", Tuple.Create<Action,string>(MoveDocuments, "Переместить документы в подразделение")},
                    {"get-doc-entries", Tuple.Create<Action,string>(GetDocumentEntries, "Список вхождений документов")},
                    {"get-doc-inner", Tuple.Create<Action,string>(GetInternalDocuments, "Список внутренних документов")},
                    {"get-doc-list", Tuple.Create<Action,string>(GetDocumentList, "Список документов")},
                    {"get-doc-info", Tuple.Create<Action,string>(GetDocumentInfo, "Загрузить документ")},
                    {"get-doc-flow", Tuple.Create<Action,string>(GetDocumentFlow, "Загрузить документ c вхождениями")},
                    {"get-draft-list", Tuple.Create<Action,string>(GetDraftMessageList, "Список черновиков")},
                    {"get-draft", Tuple.Create<Action,string>(GetDraftMessage, "Загрузить черновик")},
                    {"del-draft", Tuple.Create<Action,string>(DeleteDraftMessage, "Удалить черновик")},
                    {"get-contacts", Tuple.Create<Action,string>(GetActiveContacts, "Список активных контактов")},
                    {"del-contact", Tuple.Create<Action,string>(DeleteContact, "Удалить контакт")},
                    {"get-structure", Tuple.Create<Action,string>(GetOrganizationStructure, "Дерево орг.структуры")},
                    {"add-department", Tuple.Create<Action,string>(AddOrganizationStructureElement, "Добавить подразделение")},
                    {"edit-department", Tuple.Create<Action,string>(EditOrganizationStructureElement, "Изменить подразделение")},
                    {"del-department", Tuple.Create<Action,string>(DeleteOrganizationStructureElement, "Удалить подразделение")},
                    {"accept-reg", Tuple.Create<Action,string>(AcceptRegulation, "Принять Правила Synerdocs")},
                    // {"outmsg", OuntgoingMessages},
                };

                PrintAvailableCommnads(commandsMap);

                //
                // выбираем первый доступный ящик
                var firstAvailableBox = client.GetBoxes().FirstOrDefault();
                if (firstAvailableBox == null)
                {
                    throw new InvalidOperationException("У пользователя нет доступа ни к одному ящику");
                }
                context.CurrentBox = firstAvailableBox.Address;
                context.CurrentOrganizationId = firstAvailableBox.OrganizationId;
                context.LoadLastProcessedMessageId();
                context.MessageFactory = new MessageFactory(context.ServiceClient, context.CurrentBox);

                while (true)
                {
                    UserInput.Write(ConsoleColor.White, ">");
                    var line = UserInput.ReadLine();
                    if (commandsMap.ContainsKey(line))
                    {
                        try
                        {
                            commandsMap[line].Item1();
                        }
                        catch (InputCanceledException)
                        {
                            Console.Out.WriteLine("Команда прервана");
                            continue;
                        }
                        catch (Exception ex)
                        {
                            UserInput.Error("При выполнении команды произошла неожиданная ошибка");
                            UserInput.Error(ex.ToString());
                        }
                    }
                    else
                    {
                        UserInput.Error("Неправильно указано имя команды \"{0}\"", line);
                        PrintAvailableCommnads(commandsMap);
                    }
                }

                // интерактивная консоль для ввода

                // ввод значений списочных параметров по номерам
                // > auth
                // выберите сертификат
                // achmed@synerdocs.ru [1]
                // saitov@synerdocs.ru [2]
                // Сертификат [1]>
                //
                // Подтверждения
                // Отправить файлы? [Y/n]>
            }
            catch (InputCanceledException)
            {
                // Ctrl+C
                Console.Out.WriteLine();
                Console.Out.WriteLine("Выход");
            }
            catch (Exception ex)
            {
                UserInput.Error("Произошла неожиданная ошибка");
                UserInput.Error(ex.ToString());
            }
        }

        private MessageRecipient ChooseExternalRecipient()
        {
            var fromList = new UserInput.Option("1", "Из списка контрагентов", true, true);
            var manuallyEntry = new UserInput.Option("2", "Ввести вручную", false, true);

            var chooseOption = UserInput.ChooseOption("Выбрать получателя", new[]
                                                                    {
                                                                        fromList,
                                                                        manuallyEntry,
                                                                    });
            var organizationId = (string)null;
            var boxAddress = (string)null;
            if (chooseOption == fromList)
            {
                var contactSearchResult = context.ServiceClient.SearchContacts(
                    new ContactSearchOptions
                        {
                            OrganizationId = context.CurrentOrganizationId,
                            ContactStatus = ContactStatus.Active,
                            From = 0,
                            Max = 20
                        });
                var contragentOption = UserInput.ChooseOption
                    ("Выберите получателя",
                    contactSearchResult.Items
                        .Select((c, i) =>
                            new UserInput.Option((i + 1).ToString(), c.ContragentName, i == 0, c)));
                var contactSearchItem = ((ContactSearchItem)contragentOption.Data);
                organizationId = contactSearchItem.ContragentId.ToString();
                boxAddress = contactSearchItem.BoxAddress;
            }
            else
            {
                var address = UserInput.ReadParameter("Введите адрес получателя");
                var organization = context.ServiceClient.GetOrganizationBy(context.CurrentBox,
                                                                           OrganizationByCriteria.ByBoxAddress,
                                                                           new OrganizationByCriteriaValues { BoxAddress = address });

                if (organization == null)
                {
                    UserInput.Error("Неправильно указан адресат");
                    return null;
                }
                UserInput.Success(String.Format("Выбрана организация: {0}",organization.Name));
                organizationId = organization.OrganizationId;
                boxAddress = organization.BoxAddress;
            }

            var messageRecipient = new MessageRecipient { OrganizationBoxId = boxAddress };

            if (UserInput.ChooseYesNo("Указать подразделение"))
            {
                var selectedDepartment = ChooseOrganizationStructureElement(organizationId);
                if (selectedDepartment != null)
                    messageRecipient.DepartmentId = selectedDepartment.Id;
            }

            return messageRecipient;
        }

        private InternalMessageRecipient ChooseInternalRecipient()
        {
            var internalRecipient = new InternalMessageRecipient();
            var selectedDepartment = ChooseOrganizationStructureElement(context.CurrentOrganizationId.ToString());
            if (selectedDepartment != null)
                internalRecipient.DepartmentId = selectedDepartment.Id;
            if (UserInput.ChooseYesNo("Указать пользователя"))
            {
                var selectedUser = ChoseUser(selectedDepartment.Id);
                if (selectedUser != null)
                    internalRecipient.UserLogin = selectedUser.Login;
            }
            return internalRecipient;
        }

        private OrganizationStructureElement ChooseOrganizationStructureElement(string organizationId)
        {
            var departmentInfos = context.ServiceClient.GetOrganizationStructure
                (context.CurrentBox, organizationId.ToString());


            var depInputOptions =
                departmentInfos.Select
                    (
                        (c, i) =>
                        new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture), c.Name, i == 0, c))
                               .ToList();

            var chooseOption = UserInput.ChooseOption("Выберите подразделение получателя", depInputOptions);
            return (OrganizationStructureElement)chooseOption.Data;
        }

        private User ChoseUser(string departmentId)
        {
            var fromList = new UserInput.Option("1", "Из списка сотрудников", true, true);
            var manuallyEntry = new UserInput.Option("2", "Ввести вручную", false, true);
            
            var chooseOption = UserInput.ChooseOption(
                "Выбрать пользователя",
                new[]
                {
                    fromList,
                    manuallyEntry,
                });

            if (chooseOption == fromList)
            {
                var userList = context.ServiceClient.GetDepartmentEmployees(context.CurrentBox, departmentId);
                if (userList.Length == 0)
                {
                    UserInput.Warning("У подразделения нет сотрудников");
                    return null;
                }
                var userOption = UserInput.ChooseOption(
                    "Выберите сотрудника",
                    userList.Select((u, i) => new UserInput.Option(
                        (i + 1).ToString(),
                        String.Format("{0} {1} {2}", u.LastName, u.FirstName, u.MiddleName),
                        i == 0,
                        u)));
                return (User)userOption.Data;
            }
            else
            {
                return new User
                {
                    Login = UserInput.ReadParameter("Укажите логин пользователя"),
                };
            }
        }

        /// <summary>
        /// Выбрать директорию
        /// </summary>
        /// <returns></returns>
        private static string ChooseDirectory()
        {
            while (true)
            {
                var directoryPath = UserInput.ReadParameter("Введите имя директории", Environment.CurrentDirectory);
                if (!Path.IsPathRooted(directoryPath))
                {
                    directoryPath = Path.Combine(Environment.CurrentDirectory, directoryPath);
                }
                return directoryPath;
            }
        }

        /// <summary>
        /// Запрашивает у пользователя тип документооборота
        /// </summary>
        /// <returns>Тип документооборота</returns>
        private FlowType ChooseFlowType()
        {
            return (FlowType)Int32.Parse(UserInput
                .ChooseOption("Выберите тип документооборота", new[]
                {
                    new UserInput.Option(((int)FlowType.SentUnsigned).ToString(), "Без подписи", isDefault: true),
                    new UserInput.Option(((int)FlowType.SentForward).ToString(), "Пересланный", isDefault: false),
                    new UserInput.Option(((int)FlowType.SentInternal).ToString(), "Внутренний", isDefault: false),
                })
                .Id);
        }

        /// <summary>
        /// Отправить документы
        /// </summary>
        private void SendDocuments(FlowType flowType)
        {
            // нужен сертификат
            if (flowType != FlowType.SentUnsigned && context.Certificate == null)
                ChooseCertificate();

            var externalRecipients = new List<MessageRecipient>();
            var internalRecipients = new List<InternalMessageRecipient>();
            do
            {
                if (flowType != FlowType.SentInternal)
                {
                    var recipient = ChooseExternalRecipient();
                    if (recipient != null)
                    {
                        externalRecipients.Add(recipient);
                        if (flowType == FlowType.SentUnsigned)
                            break;
                        if (!UserInput.ChooseYesNo("Добавить еще одного получателя?"))
                            break;
                    }
                }
                else
                {
                    var recipient = ChooseInternalRecipient();
                    if (recipient != null)
                    {
                        internalRecipients.Add(recipient);
                        break;
                    }
                }
            }
            while (true);

            Message message = null;
            UnsignedMessage unsignedMessage = null;
            ForwardMessage forwardMessage = null;
            InternalMessage internalMessage = null;
            switch (flowType)
            {
                case FlowType.SentSigned:
                    message = CreateMessage(externalRecipients);
                    break;
                case FlowType.SentUnsigned:
                    unsignedMessage = CreateUnsignedMessage(externalRecipients);
                    break;
                case FlowType.SentForward:
                    forwardMessage = CreateForwardMessage(externalRecipients);
                    break;
                case FlowType.SentInternal:
                    internalMessage = CreateInternalMessage(internalRecipients);
                    break;
            }

            if ((message != null && message.Documents.Length == 0)
                || (unsignedMessage != null && unsignedMessage.Documents.Length == 0)
                || (forwardMessage != null && forwardMessage.ForwardDocuments.Length == 0)
                || (internalMessage != null && internalMessage.Documents.Length == 0))
            {
                UserInput.Error("Документы для отправки не выбраны");
                return;
            }

            var sendMessageOption = new UserInput.Option("1", "Отправить сообщение", true);
            var saveToDraftOption = new UserInput.Option("2", "Сохранить как черновик", false);

            while (true)
            {
                var chosenOption = UserInput.ChooseOption("Выберите действие", new[]
                {
                    sendMessageOption,
                    saveToDraftOption
                });

                if (chosenOption == sendMessageOption)
                {
                    break;
                }
                else if (chosenOption == saveToDraftOption)
                {
                    DraftMessage draftMessage = null;
                    if (message != null)
                        draftMessage = ConvertToDraftMessage(message);
                    else if (unsignedMessage != null)
                        draftMessage = ConvertToDraftMessage(unsignedMessage);
                    else if (forwardMessage != null)
                        draftMessage = ConvertToDraftMessage(forwardMessage);
                    else if (internalMessage != null)
                        draftMessage = ConvertToDraftMessage(internalMessage);
                    var draftMessageId = context.ServiceClient.CreateDraftMessage(draftMessage);
                    UserInput.Success("Черновик сообщения сохранен, Id:{0}", draftMessageId);
                    return;
                }
            }

            try
            {
                SentMessage sentMessage = null;
                if (message != null)
                    sentMessage = context.ServiceClient.SendMessage(message);
                else if (unsignedMessage != null)
                    sentMessage = context.ServiceClient.SendUnsignedMessage(unsignedMessage);
                else if (forwardMessage != null)
                    sentMessage = context.ServiceClient.SendForwardMessage(forwardMessage);
                else if (internalMessage != null)
                    sentMessage = context.ServiceClient.SendInternalMessage(internalMessage);
                UserInput.Success("Сообщение отправлено Id:{0}", sentMessage.MessageId);
            }
            catch (ServerException ex)
            {
                if (ex.Code == ServiceErrorCode.ContragentIsNotAuthorized)
                {
                    UserInput.Error("Контрагент не авторизован");
                }
                else if (ex.Code == ServiceErrorCode.InvalidDestinationAddress)
                {
                    UserInput.Error("Неправильно указан адресат");
                }
                else if (ex.Code == ServiceErrorCode.NotFilledRequiredField)
                {
                    UserInput.Error("Не заполнено обязательно поле \"{0}\"", ex.Field);
                }
                else
                {
                    UserInput.Error("Ошибка отправки Code:{0} Field:{1} Message:{2}", ex.Code, ex.Field, ex.Message);
                    // TODO обработка других ошибок, отображение текста!
                }
            }
            // перехват ошибки уровня транспорта
            catch (Exception ex)
            {
                // TODO здесь надо сделать правильную обработку ошибки
                UserInput.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Подписание документа
        /// </summary>
        private void SignDocument()
        {
            // нужен сертификат
            if (context.Certificate == null)
                ChooseCertificate();

            var flowType = ChooseFlowType();
            var documentId = UserInput.ReadParameter("Введите ИД документа");
            byte[] signData;
            if (UserInput.ChooseYesNo("Загрузить подпись из файла", false))
            {
                do
                {
                    var signPath = UserInput.ReadParameter("Введите имя файла, содержащего подпись");
                    if (!Path.IsPathRooted(signPath))
                        signPath = Path.Combine(Environment.CurrentDirectory, signPath);
                    if (!File.Exists(signPath))
                    {
                        UserInput.Error("Файл не найден {0}", signPath);
                        continue;
                    }
                    signData = File.ReadAllBytes(signPath);
                    break;
                }
                while (true);
            }
            else
            {
                signData = CryptoApiHelper.Sign(
                    context.Certificate,
                    context.ServiceClient.GetDocumentContent(context.CurrentBox, documentId),
                    detached: true);
            }

            var sign = new Sign
            {
                From = context.CurrentBox,
                DocumentId = documentId,
                Raw = signData,
            };

            try
            {
                context.ServiceClient.SignDocument(flowType, sign);
                UserInput.Success("Документ был успешно подписан");
            }
            catch (Exception ex)
            {
                UserInput.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Отказать в подписании
        /// </summary>
        private void RejectSign()
        {
            var flowType = ChooseFlowType();
            var documentId = UserInput.ReadParameter("Введите ИД документа");
            var comment = UserInput.ReadParameter("Введите уведомление об уточнении");

            var rejectSign = new RejectSign
            {
                From = context.CurrentBox,
                DocumentId = documentId,
                Comment = comment,
            };

            try
            {
                context.ServiceClient.RejectSign(flowType, rejectSign);
                UserInput.Success("Отказ в подписании документа успешно отправлен");
            }
            catch (Exception ex)
            {
                UserInput.Error(ex.ToString());
            }
        }

        private void MoveDocuments()
        {
            var documentIds = new List<string>();
            documentIds.Add(UserInput.ReadParameter("Введите ИД документа"));
            if (UserInput.ChooseYesNo("Добавить еще документы для перемещения"))
            {
                do
                {
                    var documentId = UserInput.ReadParameter("Введите ИД документа (или пустую строку для прекращения ввода)");
                    if (String.IsNullOrEmpty(documentId))
                        break;
                    documentIds.Add(documentId);

                }
                while (true);
            }

            var department = ChooseOrganizationStructureElement(context.CurrentOrganizationId.ToString());
            if (department != null)
            {
                try
                {
                    if (documentIds.Count > 1)
                    {
                        var movedIds = context.ServiceClient.MoveDocumentsToDepartment(context.CurrentBox, documentIds.ToArray(), department.Id);
                        if (movedIds.Length == documentIds.Count)
                            UserInput.Success("Все документы были успешно перемещены");
                        else if (movedIds.Length > 0)
                            UserInput.Success(
                                "Было перемещено {0} документов из {1}, т.к. остальные уже находятся в этом подразделении",
                                movedIds.Length,
                                documentIds.Count);
                        else
                            UserInput.Warning("Документы уже находятся в этом подразделении");
                    }
                    else
                    {
                        if (context.ServiceClient.MoveDocumentToDepartment(context.CurrentBox, documentIds[0], department.Id))
                            UserInput.Success("Документ был успешно перемещен");
                        else
                            UserInput.Warning("Документ уже находится в этом подразделении");
                    }
                }
                catch (Exception ex)
                {
                    UserInput.Error(ex.ToString());
                }
            }
        }

        private static DraftForwardDocument ConvertToDraftForwardDocument(ForwardDocument document)
        {
            return new DraftForwardDocument
            {
                OriginalDocumentId = document.OriginalDocumentId,
                NeedSign = document.NeedSign,
                Comment = document.Comment,
            };
        }

        private static DraftDocument ConvertToDraftDocument(Document document)
        {
            return new DraftDocument
            {
                Id = document.Id,
                DocumentType = document.DocumentType,
                Name = document.Name ?? document.FileName,
                FileName = document.FileName,
                FileSize = document.FileSize,
                Content = document.Content,
                Card = document.Card,
                Comment = document.Comment,
                NeedSign = document.NeedSign,
                NeedReceipt = document.NeedReceipt
            };
        }

        private static DraftMessage ConvertToDraftMessage(Message message)
        {
            return new DraftMessage
            {
                Id = message.Id,
                SenderBoxId = message.From,
                Recipients = message.Recipients,
                Documents = message.Documents
                    .Select(ConvertToDraftDocument)
                    .ToArray(),
            };
        }

        private static DraftMessage ConvertToDraftMessage(UnsignedMessage message)
        {
            return new DraftMessage
            {
                Id = Guid.NewGuid().ToString(),
                SenderBoxId = message.From,
                Recipients = message.Recipients,
                Documents = message.Documents
                    .Select(ConvertToDraftDocument)
                    .ToArray(),
            };
        }

        private static DraftMessage ConvertToDraftMessage(ForwardMessage message)
        {
            return new DraftMessage
            {
                Id = Guid.NewGuid().ToString(),
                SenderBoxId = message.From,
                Recipients = message.Recipients,
                Documents = message.Documents != null
                    ? message.Documents
                        .Select(ConvertToDraftDocument)
                        .ToArray()
                    : null,
                ForwardDocuments = message.ForwardDocuments
                    .Select(ConvertToDraftForwardDocument)
                    .ToArray(),
            };
        }

        private static DraftMessage ConvertToDraftMessage(InternalMessage message)
        {
            return new DraftMessage
            {
                Id = Guid.NewGuid().ToString(),
                SenderBoxId = message.BoxId,
                InternalRecipients = message.Recipients,
                Documents = message.Documents != null
                    ? message.Documents
                        .Select(ConvertToDraftDocument)
                        .ToArray()
                    : null,
                SendMode = DraftMessageSendMode.Internal,
            };
        }

        private void GetDocumentFlow()
        {
            var documentId = UserInput.ReadParameter("Id документа");
            var flowDocumentInfo = context.ServiceClient.GetFlowDocumentInfo(context.CurrentBox, documentId);
            if (flowDocumentInfo == null)
            {
                UserInput.Error("Неправильный идентификатор документа");
                return;
            }

            Console.Out.Write("Загружен ");
            PrintDocumentFlow(flowDocumentInfo);
            SaveDocumentFlow(flowDocumentInfo);
        }

        private void GetDocumentInfo()
        {
            var documentId = UserInput.ReadParameter("Id документа");
            var fullDocumentInfo = context.ServiceClient.GetFullDocumentInfo(context.CurrentBox, documentId);
            if (fullDocumentInfo == null)
            {
                UserInput.Error("Неправильный идентификатор документа");
                return;
            }

            Console.Out.Write("Загружен ");
            PrintDocumentInfo(fullDocumentInfo);
            SaveDocumentInfo(fullDocumentInfo);
        }

        private void GetDocumentList()
        {
#pragma warning disable 618 //Отлючить предупреждения насчет устаревших полей (obsolete)

            var incoming = UserInput.ChooseYesNo("Входящие");
            var documentListOptions = new DocumentListOptions()
            {
                BoxTo = incoming ? context.CurrentBox : null,
                BoxFrom = !incoming ? context.CurrentBox : null,
                First = 0,
                Max = 10
            };

            if (UserInput.ChooseYesNo("Указать период отправки", false))
            {
                documentListOptions.From = ChooseDate(from: true);
                documentListOptions.To = ChooseDate(from: false);
            }

            var documentList = context.ServiceClient.GetDocumentList(documentListOptions);
            Console.Out.WriteLine("Всего документов {0}", documentList.Total);

            while (true)
            {
                Console.Out.WriteLine("Документы с "
                    + (documentListOptions.First + 1) + " по "
                    + Math.Min(documentListOptions.First + documentListOptions.Max, documentList.Total));

                foreach (var documentListEntry in documentList.Items)
                {
                    Console.Out.WriteLine("{0, -60} {1, -20} {2, -20} {3, -20} {4} {5}",
                        documentListEntry.Name,
                        incoming ?
                            documentListEntry.FromOrganizationName
                            : documentListEntry.ToOrganizationName,
                        documentListEntry.DocumentType,
                        StatusText(documentListEntry.MessageTo, documentListEntry.Status),
                        documentListEntry.Id,
                        documentListEntry.SentDate);
                }

                if (documentListOptions.First + documentListOptions.Max > documentList.Total)
                    break;
                if (!UserInput.ChooseYesNo("Далее"))
                    break;

                documentListOptions.First += documentListOptions.Max;
                documentList = context.ServiceClient.GetDocumentList(documentListOptions);
            }
        }

        private void GetDocumentEntries()
        {
            var incoming = UserInput.ChooseYesNo("Входящие");
            var documentEntryOptions = new DocumentEntryOptions()
            {
                BoxTo = incoming ? context.CurrentBox : null,
                BoxFrom = !incoming ? context.CurrentBox : null,
                First = 0,
                Max = 10,
            };

            if (UserInput.ChooseYesNo("Указать параметры фильтрации", false))
            {
                var flowTypes = new List<DocumentFlowType>();
                if (UserInput.ChooseYesNo("С подписью"))
                    flowTypes.Add(DocumentFlowType.SentSigned);
                if (UserInput.ChooseYesNo("Без подписи"))
                    flowTypes.Add(DocumentFlowType.SentUnsigned);
                if (UserInput.ChooseYesNo("Подготовлен"))
                    flowTypes.Add(DocumentFlowType.SentPrepared);
                if (UserInput.ChooseYesNo("Переслан"))
                    flowTypes.Add(DocumentFlowType.SentForward);
                documentEntryOptions.DocumentFlowTypes = flowTypes.ToArray();

                if (UserInput.ChooseYesNo("Указать период отправки"))
                {
                    documentEntryOptions.From = ChooseDate(from: true);
                    documentEntryOptions.To = ChooseDate(from: false);
                }
            }

            var documentEntries = context.ServiceClient.GetDocumentEntries(documentEntryOptions);
            Console.Out.WriteLine("Всего вхождений документов {0}", documentEntries.Total);

            while (true)
            {
                Console.Out.WriteLine("Вхождения документов с "
                    + (documentEntryOptions.First + 1) + " по "
                    + Math.Min(documentEntryOptions.First + documentEntryOptions.Max, documentEntries.Total));

                foreach (var documentEntryItem in documentEntries.Items)
                    Console.Out.WriteLine("{0, -60} {1, -20} {2, -20} {3, -20} {4} {5}",
                        documentEntryItem.Name,
                        documentEntryItem.FromOrganizationName,
                        documentEntryItem.DocumentType,
                        documentEntryItem.FlowType,
                        documentEntryItem.DocumentId,
                        documentEntryItem.SentDate);

                if (documentEntryOptions.First + documentEntryOptions.Max > documentEntries.Total)
                    break;
                if (!UserInput.ChooseYesNo("Далее"))
                    break;

                documentEntryOptions.First += documentEntryOptions.Max;
                documentEntries = context.ServiceClient.GetDocumentEntries(documentEntryOptions);
            }
        }

        private void GetInternalDocuments()
        {
            var internalListOptions = new InternalListOptions()
            {
                BoxId = context.CurrentBox,
                First = 0,
                Max = 10,
            };

            if (UserInput.ChooseYesNo("Указать параметры фильтрации", false))
            {
                var excludeUnavailable = UserInput.ChooseYesNo("Исключить из списка документы, подписание/отказ по которым недоступны", false);
                internalListOptions.ExcludeUnavailable = excludeUnavailable;

                var currentOrganizationId = context.CurrentOrganizationId.ToString();
                if (UserInput.ChooseYesNo("Указать подразделение отправителя"))
                {
                    var senderDepartment = ChooseOrganizationStructureElement(currentOrganizationId);
                    if (senderDepartment != null)
                        internalListOptions.SenderDepartmentIds = new[] { senderDepartment.Id };
                }

                if (UserInput.ChooseYesNo("Указать подразделение получателя"))
                {
                    var recipientDepartment = ChooseOrganizationStructureElement(currentOrganizationId);
                    if (recipientDepartment != null)
                    {
                        internalListOptions.RecipientDepartmentIds = new[] { recipientDepartment.Id };
                        if (UserInput.ChooseYesNo("Указать пользователя получателя"))
                        {
                            var recipientUser = ChoseUser(recipientDepartment.Id);
                            if (recipientUser != null)
                                internalListOptions.RecipientUserLogins = new[] { recipientUser.Login };
                        }
                    }
                }

                if (UserInput.ChooseYesNo("Указать статусы подписания"))
                {
                    var signStatuses = new List<DocumentSignStatus>();
                    if (UserInput.ChooseYesNo("Подпись не требуется"))
                        signStatuses.Add(DocumentSignStatus.NoSignNeeded);
                    if (UserInput.ChooseYesNo("Подписан"))
                        signStatuses.Add(DocumentSignStatus.Signed);
                    if (UserInput.ChooseYesNo("Отказано"))
                        signStatuses.Add(DocumentSignStatus.SignRejected);
                    if (UserInput.ChooseYesNo("Требуется подпись"))
                        signStatuses.Add(DocumentSignStatus.WaitingForSign);
                    internalListOptions.DocumentSignStatuses = signStatuses.ToArray();
                }

                if (UserInput.ChooseYesNo("Указать период отправки"))
                {
                    internalListOptions.From = ChooseDate(from: true);
                    internalListOptions.To = ChooseDate(from: false);
                }
            }

            var internalDocuments = context.ServiceClient.GetInternalDocuments(internalListOptions);
            Console.Out.WriteLine("Всего внутренних документов {0}", internalDocuments.Total);

            while (true)
            {
                Console.Out.WriteLine("Внутренние документов с "
                    + (internalListOptions.First + 1) + " по "
                    + Math.Min(internalListOptions.First + internalListOptions.Max, internalDocuments.Total));

                foreach (var documentEntryItem in internalDocuments.Items)
                {
                    var flow = documentEntryItem.Flows.First();
                    Console.Out.WriteLine("{0, -60} {1, -20} {2, -20} {3, -20} {4} {5}",
                        documentEntryItem.Name,
                        flow.SenderDepartment.Name,
                        flow.RecipientDepartment.Name,
                        flow.RecipientStatus,
                        documentEntryItem.DocumentId,
                        documentEntryItem.SentDate);
                }

                if (internalListOptions.First + internalListOptions.Max > internalDocuments.Total)
                    break;
                if (!UserInput.ChooseYesNo("Далее"))
                    break;

                internalListOptions.First += internalListOptions.Max;
                internalDocuments = context.ServiceClient.GetInternalDocuments(internalListOptions);
            }
        }

        private string StatusText(string to, DocumentFlowStatus status)
        {
            var invoiceDocumentFlowStatus = status as InvoiceDocumentFlowStatus;
            if (invoiceDocumentFlowStatus != null)
            {
                // входящий
                if (context.CurrentBox == to)
                {
                    return invoiceDocumentFlowStatus.BuyerFlow.ToString();
                }
                else
                {
                    return invoiceDocumentFlowStatus.SellerFlow.ToString();
                }
            }
            var untypedDocumentFlowStatus = status as UntypedDocumentFlowStatus;
            if (untypedDocumentFlowStatus != null)
            {
                return untypedDocumentFlowStatus.SignStatus.ToString();
            }
            return "(null)";
        }

        /// <summary>
        /// Получить список черновиков
        /// </summary>
        private void GetDraftMessageList()
        {
            var settings = new FetchingSettings
                {
                    Sorting = null,     // Сортировка по умолчанию
                    Paging = new PageSettings
                        {
                            First = 0,
                            PageSize = 10
                        }
                };

            ShowDraftMessageSearchResult(
                () => context.ServiceClient.GetDraftMessageList(settings, context.CurrentBox),
                settings.Paging);
        }

        /// <summary>
        /// Отобразить результат поиска черновиков с постраничной паджинацией
        /// </summary>
        /// <param name="func"></param>
        /// <param name="pageSettings"></param>
        /// <returns></returns>
        private DraftMessageSearchResult ShowDraftMessageSearchResult(Func<DraftMessageSearchResult> func, PageSettings pageSettings)
        {
            var result = func();
            Console.Out.WriteLine("Всего черновиков {0}", result.TotalCount);

            while (result.Items.Length > 0)
            {
                Console.Out.WriteLine("Черновики с " + (pageSettings.First + 1) + " по " +
                                      Math.Min(pageSettings.First + pageSettings.PageSize, result.TotalCount));

                foreach (var draftMessage in result.Items)
                {
                    Console.Out.WriteLine("{0} {1} Получателей:{2} Документов:{3} Связ.док-тов:{4} Перес.док-ов:{5}",
                        draftMessage.Id,
                        draftMessage.CreateDate,
                        draftMessage.SendMode != DraftMessageSendMode.Internal
                            ? (draftMessage.Recipients ?? new MessageRecipient[0]).Length
                            : (draftMessage.InternalRecipients ?? new InternalMessageRecipient[0]).Length,
                        draftMessage.Documents.Length,
                        draftMessage.RelatedDocuments.Length,
                        draftMessage.ForwardDocuments.Length
                        );
                }

                if (pageSettings.First + pageSettings.PageSize >= result.TotalCount)
                    break;
                if (!UserInput.ChooseYesNo("Далее"))
                    break;

                pageSettings.First += pageSettings.PageSize;
                result = func();
            }
            return result;
        }

        /// <summary>
        /// Получить черновик
        /// </summary>
        private void GetDraftMessage()
        {
            var draftMessageId = UserInput.ReadParameter("Id черновика сообщения");

            DraftMessage draftMessage;
            try
            {
                draftMessage = context.ServiceClient.GetDraftMessage(draftMessageId, true, true);
            }
            catch (ServerException ex)
            {
                if (ex.Code != ServiceErrorCode.UnexpectedError)
                {
                    UserInput.Error(ex.Message);
                    return;
                }
                throw;
            }

            Console.Out.WriteLine("Загружен");
            PrintDraftMessageInfo(draftMessage);

            if (!UserInput.ChooseYesNo("Сохранить информацию?"))
                return;

            var directoryPath = ChooseDirectory();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            // Сохранить документы
            foreach (var draftDocument in draftMessage.Documents)
            {
                Console.Out.WriteLine("Сохранение документа '{0}'", draftDocument.FileName);
                FileHelper.WriteAllBytes(directoryPath, draftDocument.FileName, draftDocument.Content);

                // сохраняем карточку, если есть
                if (draftDocument.Card != null)
                {
                    var cardFileName = Path.GetFileNameWithoutExtension(draftDocument.FileName) + ".card.xml";
                    Console.Out.WriteLine("Сохранение карточки документа '{0}'", cardFileName);
                    FileHelper.WriteAllBytes(directoryPath, cardFileName, draftDocument.Card);
                }
            }
        }

        /// <summary>
        /// Удалить черновик
        /// </summary>
        private void DeleteDraftMessage()
        {
            var draftMessageId = UserInput.ReadParameter("Id черновика сообщения");
            try
            {
                context.ServiceClient.DeleteDraftMessage(draftMessageId);
            }
            catch (ServerException ex)
            {
                if (ex.Code != ServiceErrorCode.UnexpectedError)
                {
                    UserInput.Error(ex.Message);
                    return;
                }
                throw;
            }

            UserInput.Success(String.Format("Черновик {0} удален", draftMessageId));
        }

        /// <summary>
        /// Добавить документ к неотправленному сообщению
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="document">Документ</param>
        /// <param name="sign">Подпись в формате CMS</param>
        private Message AddDocumentToNewMessage(Message message, Document document, byte[] sign)
        {
            return MessageFactory.AddDocumentToNewMessage(message, document, sign);
        }

        /// <summary>
        /// Выбрать сертификат из списка утсановленных
        /// </summary>
        private void ChooseCertificate()
        {
            // The following code gets the cert from the keystore
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            var cettificates =
                     store.Certificates.Cast<X509Certificate2>()
                // выбираем только сертификаты с закрытым ключем
                     .Where(c => c.HasPrivateKey)
                // алгоритм ГОСТ
                     .Where(c => c.SignatureAlgorithm.Value == "1.2.643.2.2.4" || c.SignatureAlgorithm.Value == "1.2.643.2.2.3")
                     .ToList();

            var chooseOption = UserInput.ChooseOption("Выберите сертификат", cettificates
                .Select((c, i) => new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture),
                    // получаем Common Name (CN) из сертификата
                    c.GetNameInfo(X509NameType.SimpleName, false),
                    i == 0, c)));
            var certificate = (X509Certificate2)chooseOption.Data;
            Console.Out.WriteLine("Выбран сертификат {0}", certificate.Subject);
            context.Certificate = certificate;
        }

        /// <summary>
        /// Выбрать дату
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="from">Начало?</param>
        /// <returns>Выбранная дата</returns>
        private DateTime? ChooseDate(bool from)
        {
            DateTime dateValue;
            do
            {
                var dateText = UserInput.ReadParameter(String.Format(
                    "Укажите дату {0} периода в формате ДД.ММ.ГГГГ (или пустую строку, чтобы не указывать дату)",
                    from ? "начала" : "завершения"));
                if (String.IsNullOrEmpty(dateText))
                    return null;
                if (DateTime.TryParse(dateText, out dateValue))
                    return dateValue;
                else
                    UserInput.Error("Дата указана некорректно. Повторите ввод.");
            }
            while (true);
        }

        /// <summary>
        /// Загрузка и обработка входящих сообщений
        /// </summary>
        private void LoadMessages()
        {
            if (context.Certificate == null)
            {
                ChooseCertificate();
            }

            // загружаем входящие сообщения в цикле по 100 шт маскимум
            MessageInfo[] messages = null;
            int count = 0;
            do
            {
                messages = context.ServiceClient.GetMessages(context.LastProcessedMessageId, null, context.CurrentBox);

                foreach (var messageInfo in messages)
                {
                    UserInput.Separator();
                    var message = context.ServiceClient.GetMessage(context.CurrentBox, messageInfo.Id);
                    var organization = context.ServiceClient.GetOrganizationBy(context.CurrentBox, OrganizationByCriteria.ByBoxAddress, new OrganizationByCriteriaValues { BoxAddress = messageInfo.From });
                    var department = context.ServiceClient.GetOrganizationStructure(context.CurrentBox, organization.OrganizationId.ToString()).First(d => d.Id == message.FromDepartment);
                    Console.Out.WriteLine("Обрабатывается сообщение");
                    PrintProperty("Id", messageInfo.Id);
                    PrintProperty("From", messageInfo.From);
                    PrintProperty("FromDepartment", department.Name);
                    PrintProperty("Дата", message.SentDate);
                    PrintProperty("Документы", message.Documents.Length);
                    PrintProperty("Подписи", message.Signs.Length);
                    ProcessMessage(message, context);
                    context.LastProcessedMessageId = message.Id;
                    context.SaveLastProcessedMessageId();
                }

                count += messages.Length;

            } while (messages.Length > 0);

            Console.Out.WriteLine("Загружено {0} сообщений из ящика {1}", count, context.CurrentBox);
        }

        private static void PrintProperty(string propertyName, object value)
        {
            Console.Out.WriteLine("\t{0,-15}{1}", string.Format("{0}:", propertyName), value);
        }

        /// <summary>
        /// Обработка входящего сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ctx"></param>
        /// <returns><c>true</c>, если сообщение было успешно обработано, иначе <c>false</c></returns>
        private bool ProcessMessage(Message message, ClientContext ctx)
        {
            var documentId = string.Empty;
            try
            {
                if (message.Documents.Length > 0)
                    foreach (var document in message.Documents)
                    {
                        documentId = document.Id;
                        ProcessIncomingDocument(message, document);
                    }

                // обрабатываем подписи присланные от получателей документов
                var signsFromRecipient =
                    message.Signs.Where(s => !message.Documents.Any(d => d.Id == s.DocumentId)).ToList();
                foreach (var sign in signsFromRecipient)
                    if (string.IsNullOrEmpty(sign.ParentId))
                    {
                        documentId = sign.DocumentId;
                        ProcessSign(sign);
                    }
                return true;
            }
            catch (ServerException ex)
            {
                // при загрузке сообщений, загружаются все сообщения
                // включая те, которые содержат документы, к которым
                // нет доступа у текущего пользователя, поэтому при
                // обнаружении такого документа, пропускаем сообщение
                if (ex.Code == ServiceErrorCode.AccessDeniedError)
                {
                    UserInput.Warning(
                        "Не доступа к документу {0}. Загрузка сообщения {1} пропущена.",
                        documentId,
                        message.Id);
                    return false;
                }
                else
                    throw;
            }
        }

        private void ProcessSign(Sign sign)
        {
            UserInput.Separator();

            var documentInfo = context.ServiceClient.GetFullDocumentInfo(context.CurrentBox, sign.DocumentId);
            Console.Out.WriteLine("Обрабатывается подпись на документ {0}", DocumentShortName(documentInfo));
            var certificate = CheckSignAndGetCertificate(documentInfo, sign);
            if (certificate != null)
            {
                UserInput.Success("Подпись корректна, контрагент подписал документ {0}", certificate.GetNameInfo(X509NameType.SimpleName, false));
            }
        }

        /// <summary>
        /// Обработка входящего документа
        /// </summary>
        /// <param name="message"></param>
        /// <param name="document"></param>
        private void ProcessIncomingDocument(Message message, Document document)
        {
            // в зависимости от типа документа показывать атрибуты
            // для ЭСФ это карточка, статус, подпись, имя файла
            // для СД это тип (по типу разное отображение), подпись, к какому документу относится
            // для НД название, подпись, ожидается ли подпись
            var documentInfo = context.ServiceClient.GetFullDocumentInfo(context.CurrentBox, document.Id);
            UserInput.Separator();
            Console.Out.Write("Обрабатывается ");
            PrintDocumentInfo(documentInfo);

            // НД
            if (document.DocumentType == DocumentType.Untyped)
            {
                ProcessUntypedDocument(message, documentInfo);
            }
            // НД: ИОП
            else if (document.DocumentType == DocumentType.ServiceReceipt)
            {
                ProcessDeliveryConfirmation(document);
            }
            // НД: УОУ
            else if (document.DocumentType == DocumentType.ServiceAmendmentRequest)
            {
                ProcessRejectSign(document);
            }
            // ЭСФ
            else if (document.DocumentType == DocumentType.Invoice)
            {
                ProcessInvoice(message, documentInfo);
            }
            // ЭСФ: подтверждение о дате отправки/приема 
            else if (document.DocumentType == DocumentType.ServiceInvoiceConfirmation)
            {
                ProcessServiceInvoiceConfirmation(message, documentInfo);
            }
            // ЭСФ: УОУ
            else if (document.DocumentType == DocumentType.ServiceInvoiceAmendmentRequest)
            {
                ProcessServiceInvoiceAmendmentRequest(message, documentInfo);
            }
            // Товарная накладная: титул продавца
            else if (document.DocumentType == DocumentType.WaybillSeller)
            {
                ProcessFormalizedDocument(message, documentInfo);
            }
            // Товарная накладная: титул покупателя
            else if (document.DocumentType == DocumentType.WaybillBuyer)
            {
                ProcessTitleBuyer(document);
            }
            // Акт о выполнении работ: титул исполнителя
            else if (document.DocumentType == DocumentType.ActOfWorkSeller)
            {
                ProcessFormalizedDocument(message, documentInfo);
            }
            // Акт о выполнении работ: титул заказчика
            else if (document.DocumentType == DocumentType.ActOfWorkBuyer)
            {
                ProcessTitleBuyer(document);
            }
            // TODO сделать методы автоматической генерации служебных документов в SDK
        }

        private void PrintDocumentInfo(FullDocumentInfo fullDocumentInfo)
        {
            var document = fullDocumentInfo.Document;
            Console.Out.WriteLine(DocumentShortName(fullDocumentInfo));
            PrintProperty("Id", document.Id);
            PrintProperty("Тип", document.DocumentType);

            if (fullDocumentInfo.Status != null)
            {
                if (document.DocumentType == DocumentType.Untyped
                    || document.DocumentType == DocumentType.WaybillSeller
                    || document.DocumentType == DocumentType.ActOfWorkSeller)
                {
                    PrintProperty("Подписание", ((UntypedDocumentFlowStatus)fullDocumentInfo.Status).SignStatus);
                }
                else if (document.DocumentType == DocumentType.Invoice)
                {
                    var invoiceDocumentFlowStatus = (InvoiceDocumentFlowStatus)fullDocumentInfo.Status;
                    PrintProperty("Номер", invoiceDocumentFlowStatus.Number);
                    PrintProperty("От", invoiceDocumentFlowStatus.Date);
                    PrintProperty("Сумма", invoiceDocumentFlowStatus.Total);
                    PrintProperty("Статус покупателя", invoiceDocumentFlowStatus.BuyerFlow);
                    PrintProperty("Статус продавца", invoiceDocumentFlowStatus.SellerFlow);
                }
                else
                {
                    // для служебных документов печатаем ParentId
                    PrintProperty("ParentDocumentId", fullDocumentInfo.Document.ParentDocumentId);
                }
            }

            if (fullDocumentInfo.Signs != null)
                foreach (var sign in fullDocumentInfo.Signs)
                {
                    var certificate = CheckSignAndGetCertificate(fullDocumentInfo, sign);
                    if (certificate != null)
                    {
                        PrintProperty("Подпись", certificate.GetNameInfo(X509NameType.SimpleName, false));
                        if (sign.TimeStamp != DateTime.MinValue)
                            PrintProperty("Штамп времени", sign.TimeStamp);
                        else
                            PrintProperty("Штамп времени", "отсутствует");
                    }
                }

            PrintProperty("Имя файла", document.FileName);
            // PrintProperty("Размер", document.FileSize);
            if (document.DocumentType == DocumentType.Invoice
                || document.DocumentType == DocumentType.Untyped
                || document.DocumentType == DocumentType.WaybillSeller
                || document.DocumentType == DocumentType.ActOfWorkSeller)
            {
                if (fullDocumentInfo.ServiceDocuments != null)
                {
                    Console.Out.WriteLine("\tСлужeбные документы {0} шт.", fullDocumentInfo.ServiceDocuments.Length);
                    foreach (var serviceDocument in fullDocumentInfo.ServiceDocuments)
                        Console.Out.WriteLine("\t\t{0} {1}", serviceDocument.FileName, serviceDocument.DocumentType);
                }
                if (fullDocumentInfo.RelatedDocuments != null)
                {
                    Console.Out.WriteLine("\tСвязные документы {0} шт.", fullDocumentInfo.RelatedDocuments.Length);
                    foreach (var relatedDocument in fullDocumentInfo.RelatedDocuments)
                        Console.Out.WriteLine("\t\t{0} {1}", relatedDocument.FileName, relatedDocument.DocumentType);
                }
            }
        }

        private void PrintDocumentFlow(FlowDocumentInfo flowDocumentInfo)
        {
            PrintDocumentInfo(flowDocumentInfo);
            if (flowDocumentInfo.Entries != null)
            {
                Console.Out.WriteLine("\tВхождения {0} шт.", flowDocumentInfo.Entries.Length);
                foreach (var entry in flowDocumentInfo.Entries)
                {
                    Console.Out.WriteLine("\t\t{0} {1} {2}", entry.FlowType, entry.SentDate, entry.Comment);
                    if (entry.Flows != null)
                    {
                        Console.Out.WriteLine("\t\tДокументооборот {0} шт.", entry.Flows.Length);
                        foreach (var flow in entry.Flows)
                            Console.Out.WriteLine("\t\t\t{0} {1} {2}", flow.RecipientStatus, flow.FlowDate, flow.Comment);
                    }
                }
            }
            else if (flowDocumentInfo.Flows != null)
            {
                Console.Out.WriteLine("\tДокументооборот {0} шт.", flowDocumentInfo.Flows.Length);
                foreach (var flow in flowDocumentInfo.Flows)
                    Console.Out.WriteLine("\t\t{0} {1} {2} {4}", flow.FlowType, flow.RecipientStatus, flow.FlowDate, flow.Comment);
            }
        }

        private void SaveDocumentInfo(FullDocumentInfo fullDocumentInfo)
        {
            if (!UserInput.ChooseYesNo("Сохранить информацию?"))
                return;

            var directoryPath = ChooseDirectory();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            // сохраняем основной документ
            Console.Out.WriteLine("Сохранение документа '{0}'", fullDocumentInfo.Document.FileName);
            FileHelper.WriteAllBytes(directoryPath, fullDocumentInfo.Document.FileName, GetDocuemntContent(fullDocumentInfo.Document));

            // сохраняем карточку, если есть
            if (fullDocumentInfo.Document.Card != null)
            {
                var cardFileName = Path.GetFileNameWithoutExtension(fullDocumentInfo.Document.FileName) + ".card.xml";
                Console.Out.WriteLine("Сохранение карточки документа '{0}'", cardFileName);
                FileHelper.WriteAllBytes(directoryPath, cardFileName, fullDocumentInfo.Document.Card);
            }

            // сохраняем подписи, если есть
            if (fullDocumentInfo.Signs != null)
            {
                foreach (var sign in fullDocumentInfo.Signs)
                {
                    var signFileName = sign.Subject + ".sig";

                    Console.Out.WriteLine("Сохранение подписи '{0}'", signFileName);
                    FileHelper.WriteAllBytes(directoryPath, signFileName, sign.Raw);
                }

                //Получение усовершенствованных подписей
                if (!UserInput.ChooseYesNo("Получить усовершенствованные подписи?"))
                    return;
                foreach (var sign in fullDocumentInfo.Signs)
                {
                    var signFileName = sign.Subject + ".sig";
                    Console.Out.WriteLine("Получение усовершенствованной подписи для '{0}'", signFileName);
                    EnhancedSign enhancedSign = null;
                    try
                    {
                        enhancedSign = context.ServiceClient.GetEnhancedSignById(context.CurrentBox, sign.Id);
                    }
                    catch (Exception exc)
                    {
                        Console.Error.WriteLine(exc.Message);
                        continue;
                    }
                    if (enhancedSign.CreateStatus == EnhancedSignCreateStatus.Failed)
                        Console.Out.WriteLine("Не удалось создать усовершенствованную подпись для {0}: {1}", signFileName, enhancedSign.FailedInfo.Message);
                    else if (enhancedSign.CreateStatus == EnhancedSignCreateStatus.InProgress)
                        Console.Out.WriteLine("Усовершенствованная подпись для {0} еще не создана, запросите еще раз {1}", signFileName, enhancedSign.CreateTime.ToString("dd.MM.yyyy hh:mm:ss UTC"));
                    else
                    {
                        var enhancedSignFileName = sign.Subject + ".enhanced.sig";
                        Console.Out.WriteLine("Сохранение усовершенствованной подписи '{0}'", enhancedSignFileName);
                        FileHelper.WriteAllBytes(directoryPath, enhancedSignFileName, enhancedSign.Raw);
                    }
                }
                // TODO сохранить служебные документы и подписи к ним
            }
        }

        private void SaveDocumentFlow(FlowDocumentInfo flowDocumentInfo)
        {
            SaveDocumentInfo(flowDocumentInfo);
        }

        private static void PrintDraftMessageInfo(DraftMessage draftMessage)
        {
            PrintProperty("Id", draftMessage.Id);
            PrintProperty("Создан", draftMessage.CreateDate);
            Console.Out.WriteLine("Получателей: {0}", draftMessage.Recipients.Length);
            foreach (var recipient in draftMessage.Recipients)
            {
                PrintProperty("Ящик", recipient.OrganizationBoxId);
                PrintProperty("ИД подразделения", recipient.DepartmentId);
                Console.Out.WriteLine();
            }
            Console.Out.WriteLine("Документов: {0}", draftMessage.Documents.Length);
            foreach (var draftDocument in draftMessage.Documents)
            {
                PrintProperty("Id", draftDocument.Id);
                PrintProperty("Тип", draftDocument.DocumentType);
                PrintProperty("Наименование", draftDocument.Name);
                PrintProperty("Размер", draftDocument.FileSize);
                PrintProperty("Имя файла", draftDocument.FileName);
                PrintProperty("Комментарий", draftDocument.Comment);
                PrintProperty("Подтверждение приема", draftDocument.NeedReceipt);
                PrintProperty("Требуется подпись", draftDocument.NeedSign);
                Console.Out.WriteLine();
            }
            Console.Out.WriteLine("Связанных документов: {0}", draftMessage.RelatedDocuments.Length);
            Console.Out.WriteLine("Пересылаемых документов: {0}", draftMessage.ForwardDocuments.Length);
            foreach (var relatedDocument in draftMessage.RelatedDocuments)
            {
                PrintProperty("Id", relatedDocument.DocumentId);
                Console.Out.WriteLine();
            }
        }

        private void ProcessServiceInvoiceAmendmentRequest(Message message, FullDocumentInfo documentInfo)
        {
            var document = documentInfo.Document;
            if (document.NoticeRequired)
            {
                Console.Out.WriteLine("Генерируются извещения о получении УОУ");
                var noticeMessage = context.MessageFactory.CreateInvoiceReceipt(message, document, context.Certificate);
                SendServiceDocument(noticeMessage, "Отправлено извещение о получении УОУ");
            }
            else
            {
                UserInput.Information("Извещение о получении УОУ уже было отправлено");
            }
        }

        private void ProcessServiceInvoiceConfirmation(Message message, FullDocumentInfo documentInfo)
        {
            var document = documentInfo.Document;
            if (document.NoticeRequired)
            {
                Console.Out.WriteLine("Генерируются извещения о получении подтверждения");
                var noticeMessage = context.MessageFactory.CreateInvoiceReceipt(message, document, context.Certificate);
                SendServiceDocument(noticeMessage, "Отправлено извещение о получении подтверждения");
            }
            else
            {
                UserInput.Information("Извещение о получении подтверждения уже было отправлено");
            }
        }

        private void ProcessRejectSign(Document document)
        {
            var documentInfo = context.ServiceClient.GetFullDocumentInfo(context.CurrentBox, document.ParentDocumentId);
            Console.Out.WriteLine("Отказано в подписи под документом {0}", DocumentShortName(documentInfo));
        }

        private void ProcessDeliveryConfirmation(Document document)
        {
            var documentInfo = context.ServiceClient.GetFullDocumentInfo(context.CurrentBox, document.ParentDocumentId);
            Console.Out.WriteLine("Документ {0} дошел до получателя", DocumentShortName(documentInfo));
        }

        private void ProcessTitleBuyer(Document document)
        {
            var documentInfo = context.ServiceClient.GetFullDocumentInfo(context.CurrentBox, document.ParentDocumentId);
            Console.Out.WriteLine("Документ {0} подписан", DocumentShortName(documentInfo));
        }

        private void EnsureDocumentContentLoaded(Document document)
        {
            if (document.Content == null)
                GetDocuemntContent(document);
        }

        private byte[] GetDocuemntContent(Document document)
        {
            if (document.Content == null)
            {
                // содержимое больших документов (> 1Mb) загружается отдельным запросом
                document.Content = context.ServiceClient.GetDocumentContent(context.CurrentBox, document.Id);
            }
            return document.Content;
        }

        private X509Certificate2 CheckSignAndGetCertificate(FullDocumentInfo documentInfo, Sign sign)
        {
            var document = documentInfo.Document;
            if (document.NeedReceipt && IsNoticeRequired(documentInfo))
            {
                UserInput.Warning("Не удалось проверить подпись документа т.к. на него запрошено УОП");
                return null;
            }
            X509Certificate2 certificate;
            var contentInfo = new ContentInfo(GetDocuemntContent(document));
            var signedCms = new SignedCms(contentInfo, true);
            try
            {
                // проверям подпись (действительность сервтификата не проверям для простоты)
                signedCms.Decode(sign.Raw);
                signedCms.CheckSignature(true);
            }
            catch (CryptographicException)
            {
                UserInput.Error("Подпись на документ {0} недействительна", document.Id);
                return null;
            }
            certificate = signedCms.Certificates[0];
            return certificate;
        }

        private bool IsSignRequired(FullDocumentInfo documentInfo)
        {
            if (!documentInfo.Document.NeedSign)
                return false;
            var untypedFlowStatus = documentInfo.Status as UntypedDocumentFlowStatus;
            if (untypedFlowStatus == null)
                return false;
            return untypedFlowStatus.SignStatus == DocumentSignStatus.WaitingForSign;
        }

        private bool IsNoticeRequired(FullDocumentInfo documentInfo)
        {
            if (!documentInfo.Document.NoticeRequired)
                return false;
            var untypedFlowStatus = documentInfo.Status as UntypedDocumentFlowStatus;
            if (untypedFlowStatus == null)
                return false;
            return untypedFlowStatus.DeliveryStatus != DocumentDeliveryStatus.DeliveredToRecipient;
        }

        private void ProcessInvoice(Message message, FullDocumentInfo documentInfo)
        {
            var document = documentInfo.Document;
            if (document.NoticeRequired)
            {
                Console.Out.WriteLine("Генерируются извещения о получении ЭСФ");
                var noticeMessage = context.MessageFactory.CreateInvoiceReceipt(message, document, context.Certificate);
                SendServiceDocument(noticeMessage, "Отправлено извещение о получении ЭСФ отправлено");
            }
            else
            {
                UserInput.Information("Извещение о получении ЭСФ уже было отправлено");
            }

            if (((InvoiceDocumentFlowStatus)documentInfo.Status).BuyerFlow == InvoiceFlowStatus.InvoiceRejected)
            {
                UserInput.Information("Уведомление об уточнении ЭСФ уже было отправлено");
            }
            else if (UserInput.ChooseYesNo("Запросить уточнение на счет-фактуру?"))
            {
                var text = UserInput.ReadParameter("Текст уточнения:", String.Empty);
                var invoiceAmendmentRequestMessage = context.MessageFactory.GenerateInvoiceAmendmentRequest(message, document, text, context.Certificate);
                SendServiceDocument(invoiceAmendmentRequestMessage, "Отправлено уведомление об уточнении ЭСФ");
            }
        }

        private void ProcessUntypedDocument(Message message, FullDocumentInfo documentInfo)
        {
            var document = documentInfo.Document;
            var certificate = context.Certificate;

            // если требуется отправляем ИОП
            if (IsNoticeRequired(documentInfo))
            {
                if (document.NeedReceipt)
                {
                    UserInput.Information("Отправитель запросил подтверждение получения документа");
                    if (!UserInput.ChooseYesNo("Отправить извещение о получении?"))
                        return;
                }
                Console.Out.WriteLine("Отправляется извещение о получении");
                var deliveryConfirmationMessage = context.MessageFactory.CreateReceipt(message, document, certificate);
                SendServiceDocument(deliveryConfirmationMessage, "Извещение о получении отправлено");
            }
            else
            {
                UserInput.Information("Извещение о получении уже было отправлено");
            }

            // если ожидается подпись то подписываем или отказываем в подписи
            if (IsSignRequired(documentInfo))
            {
                if (UserInput.ChooseYesNo("Отправитель запросил подпись под документом. Подписать документ?"))
                {
                    // отправляем подпись под документом
                    EnsureDocumentContentLoaded(document);
                    var signMessage = context.MessageFactory.CreateSign(message, document, certificate);
                    SendServiceDocument(signMessage, "Документ продписан");
                }
                else
                {
                    // генерируем СД УОУ
                    var text = UserInput.ReadParameter("Текст уточнения:", String.Empty);
                    var amendmentRequestMessage = context.MessageFactory.CreateAmendmentRequest(message, document, text, certificate);
                    SendServiceDocument(amendmentRequestMessage, "Отправлено уведомление об уточнении");
                }
            }
        }

        private Message CreateMessage(IEnumerable<MessageRecipient> recipients, bool isActOfWorkBuyer = false, bool isWaybillBuyer = false, string parentId = null)
        {
            var message = new Message()
            {
                Id = Guid.NewGuid().ToString(),
                From = context.CurrentBox,
                //To = boxTo,
                Documents = new Document[0],
                Signs = new Sign[0],
                Recipients = recipients.ToArray(),
            };

            do
            {
                DocumentType documentType;
                if (isActOfWorkBuyer)
                {
                    Console.Out.WriteLine("Необходимо загрузить титул заказчика на Акт о выполнении работ");
                    documentType = DocumentType.ActOfWorkBuyer;
                }
                else if (isWaybillBuyer)
                {
                    Console.Out.WriteLine("Необходимо загрузить титул покупателя на Товарную накладную");
                    documentType = DocumentType.WaybillBuyer;
                }
                else
                {
                    documentType = (DocumentType)UserInput.ChooseOption("Выберите тип документа", new[]
                    {
                        new UserInput.Option("1", "Неструктурированный", true, DocumentType.Untyped),
                        new UserInput.Option("2", "Электронный счет-фактура", true, DocumentType.Invoice),
                        new UserInput.Option("3", "Товарная накладная (титул продавца)", true, DocumentType.WaybillSeller),
                        new UserInput.Option("4", "Акт о выполнении работ (титул исполнителя)", true, DocumentType.ActOfWorkSeller),
                        new UserInput.Option("5", "Исправленный счет-фактура", true, DocumentType.InvoiceRevision),
                        new UserInput.Option("6", "Корректировочный счет-фактура", true, DocumentType.InvoiceCorrection),
                        new UserInput.Option("7", "Исправленный корректировочный счет-фактура",true,DocumentType.InvoiceCorrectionRevision)
                    }).Data;
                }
                if (documentType != DocumentType.Invoice && documentType.IsInvoice())
                {
                    parentId = UserInput.ReadParameter("Введите идентификатор родительского документа");
                }
                var filePath = UserInput.ReadParameter("Введите имя файла");
                // если путь не абсолютный, то пытаемся найти файл из текущей лиректории
                if (!Path.IsPathRooted(filePath))
                    filePath = Path.Combine(Environment.CurrentDirectory, filePath);
                if (!File.Exists(filePath))
                {
                    UserInput.Error("Файл не найден {0}", filePath);
                    continue;
                }

                byte[] content = null;
                content = File.ReadAllBytes(filePath);

                // TODO генерация имени файла для ЭСФ тип документа Invoice
                var fileName = Path.GetFileName(filePath);

                string documentKindType = null;
                if (documentType == DocumentType.Untyped)
                    documentKindType = UserInput.ReadParameter("Введите подтип документа, если необходимо");

                byte[] card = null;
                if (UserInput.ChooseYesNo("Прикрепить карточку?", false))
                {
                    var cardfilePath = UserInput.ReadParameter("Введите имя файла");
                    if (!Path.IsPathRooted(cardfilePath))
                        cardfilePath = Path.Combine(Environment.CurrentDirectory, filePath);
                    if (!File.Exists(cardfilePath))
                    {
                        UserInput.Error("Файл не найден {0}", cardfilePath);
                        continue;
                    }
                    card = File.ReadAllBytes(cardfilePath);
                }

                byte[] sign;
                if (UserInput.ChooseYesNo("Загрузить подпись из файла", false))
                {
                    var signPath = UserInput.ReadParameter("Введите имя файла, содержащего подпись");
                    // если путь не абсолютный, то пытаемся найти файл из текущей директории
                    if (!Path.IsPathRooted(signPath))
                        signPath = Path.Combine(Environment.CurrentDirectory, signPath);
                    if (!File.Exists(signPath))
                    {
                        UserInput.Error("Файл не найден {0}", signPath);
                        continue;
                    }
                    sign = File.ReadAllBytes(signPath);
                }
                else
                {
                    sign = CryptoApiHelper.Sign(context.Certificate, content, true);
                }

                bool needSign = false;
                // для ЭСФ, Товарной накладной (титул покупателя), Акта о выполнении работ (титул заказчика) подпись не запрашивается
                if (documentType != DocumentType.Invoice && documentType != DocumentType.WaybillBuyer && documentType != DocumentType.ActOfWorkBuyer)
                {
                    needSign = UserInput.ChooseYesNo("Запросить подпись под документом?");
                }

                AddDocumentToNewMessage(message, new Document()
                {
                    Id = Guid.NewGuid().ToString(), // при интеграции с КИС здесь должен быть локальный идентификатор документа
                    DocumentType = documentType,
                    UntypedKind = documentKindType,
                    FileName = fileName,
                    Content = content,
                    Card = card,
                    NeedSign = needSign,
                    ParentDocumentId = parentId
                }, sign);

                // при отправке титула покупателя(заказчика) отправляется только один документ
                if (documentType != DocumentType.WaybillBuyer && documentType != DocumentType.ActOfWorkBuyer)
                {
                    if (!UserInput.ChooseYesNo("Добавить еще один документ для отправки?", false))
                        break;
                }
                else
                {
                    break;
                }
            }
            while (true);

            return message;
        }

        private UnsignedMessage CreateUnsignedMessage(IEnumerable<MessageRecipient> recipients)
        {
            var documents = new List<Document>();
            do
            {
                var filePath = UserInput.ReadParameter("Введите имя файла");
                if (!Path.IsPathRooted(filePath))
                    filePath = Path.Combine(Environment.CurrentDirectory, filePath);
                if (!File.Exists(filePath))
                {
                    UserInput.Error("Файл не найден {0}", filePath);
                    continue;
                }

                var content = File.ReadAllBytes(filePath);
                var fileName = Path.GetFileName(filePath);
                var documentKindType = UserInput.ReadParameter("Введите подтип документа, если необходимо");
                var needSign = UserInput.ChooseYesNo("Запросить подпись под документом?");

                byte[] card = null;
                if (UserInput.ChooseYesNo("Прикрепить карточку?", false))
                {
                    var cardfilePath = UserInput.ReadParameter("Введите имя файла");
                    if (!Path.IsPathRooted(cardfilePath))
                        cardfilePath = Path.Combine(Environment.CurrentDirectory, filePath);
                    if (!File.Exists(cardfilePath))
                    {
                        UserInput.Error("Файл не найден {0}", cardfilePath);
                        continue;
                    }
                    card = File.ReadAllBytes(cardfilePath);
                }

                documents.Add(new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    DocumentType = DocumentType.Untyped,
                    UntypedKind = documentKindType,
                    FileName = fileName,
                    Content = content,
                    Card = card,
                    NeedSign = needSign,
                });

                if (!UserInput.ChooseYesNo("Добавить еще один документ для отправки?", false))
                    break;
            } 
            while (true);

            return new UnsignedMessage()
            {
                From = context.CurrentBox,
                Documents = documents.ToArray(),
                Recipients = recipients.ToArray(),
            };
        }

        private ForwardMessage CreateForwardMessage(IEnumerable<MessageRecipient> recipients)
        {
            var documents = new List<ForwardDocument>();
            do
            {
                var documentId = UserInput.ReadParameter("Введите ИД документа для пересылки");
                var needSign = UserInput.ChooseYesNo("Запросить подпись под документом?");
                var comment = UserInput.ReadParameter("Введите комментарий для пересылаемого документа");

                documents.Add(new ForwardDocument
                {
                    OriginalDocumentId = documentId,
                    NeedSign = needSign,
                    Comment = comment,
                });

                if (!UserInput.ChooseYesNo("Добавить еще один документ для пересылки?", false))
                    break;
            }
            while (true);

            var message = UserInput.ChooseYesNo("Добавить новые документы для отправки?", false)
                ? CreateMessage(recipients)
                : null;

            return new ForwardMessage()
            {
                From = context.CurrentBox,
                ForwardDocuments = documents.ToArray(),
                Documents = message != null
                    ? message.Documents
                    : null,
                Recipients = message != null
                    ? message.Recipients
                    : recipients.ToArray(),
                Signs = message != null
                    ? message.Signs
                    : null,
            };
        }

        private InternalMessage CreateInternalMessage(IEnumerable<InternalMessageRecipient> recipients)
        {
            var documents = new List<Document>();
            var signs = new List<Sign>();
            do
            {
                var filePath = UserInput.ReadParameter("Введите имя файла");
                if (!Path.IsPathRooted(filePath))
                    filePath = Path.Combine(Environment.CurrentDirectory, filePath);
                if (!File.Exists(filePath))
                {
                    UserInput.Error("Файл не найден {0}", filePath);
                    continue;
                }

                var content = File.ReadAllBytes(filePath);
                var fileName = Path.GetFileName(filePath);
                var documentKindType = UserInput.ReadParameter("Введите подтип документа, если необходимо");
                var needSign = UserInput.ChooseYesNo("Запросить подпись под документом?");

                byte[] card = null;
                if (UserInput.ChooseYesNo("Прикрепить карточку?", false))
                {
                    var cardfilePath = UserInput.ReadParameter("Введите имя файла");
                    if (!Path.IsPathRooted(cardfilePath))
                        cardfilePath = Path.Combine(Environment.CurrentDirectory, filePath);
                    if (!File.Exists(cardfilePath))
                    {
                        UserInput.Error("Файл не найден {0}", cardfilePath);
                        continue;
                    }
                    card = File.ReadAllBytes(cardfilePath);
                }

                byte[] sign;
                if (UserInput.ChooseYesNo("Загрузить подпись из файла", false))
                {
                    var signPath = UserInput.ReadParameter("Введите имя файла, содержащего подпись");
                    // если путь не абсолютный, то пытаемся найти файл из текущей директории
                    if (!Path.IsPathRooted(signPath))
                        signPath = Path.Combine(Environment.CurrentDirectory, signPath);
                    if (!File.Exists(signPath))
                    {
                        UserInput.Error("Файл не найден {0}", signPath);
                        continue;
                    }
                    sign = File.ReadAllBytes(signPath);
                }
                else
                {
                    sign = CryptoApiHelper.Sign(context.Certificate, content, true);
                }

                var documentId = Guid.NewGuid().ToString();
                documents.Add(new Document
                {
                    Id = documentId,
                    DocumentType = DocumentType.Untyped,
                    UntypedKind = documentKindType,
                    FileName = fileName,
                    Content = content,
                    Card = card,
                    NeedSign = needSign,
                });

                signs.Add(new Sign
                {
                    Id = Guid.NewGuid().ToString(),
                    DocumentId = documentId,
                    Raw = sign,
                });

                if (!UserInput.ChooseYesNo("Добавить еще один документ для отправки?", false))
                    break;
            }
            while (true);

            return new InternalMessage()
            {
                Id = Guid.NewGuid().ToString(),
                BoxId = context.CurrentBox,
                Documents = documents.ToArray(),
                Recipients = recipients.ToArray(),
                Signs = signs.ToArray(),
            };
        }

        private void ProcessFormalizedDocument(Message message, FullDocumentInfo documentInfo)
        {
            var document = documentInfo.Document;
            var certificate = context.Certificate;

            // отправляем ИОП если требуется 
            if (IsNoticeRequired(documentInfo))
            {
                if (document.NeedReceipt)
                {
                    UserInput.Information("Отправитель запросил подтверждение получения документа");
                    if (!UserInput.ChooseYesNo("Отправить извещение о получении?"))
                        return;
                }
                Console.Out.WriteLine("Отправляется извещение о получении");
                var deliveryConfirmationMessage = context.MessageFactory.CreateReceipt(message, document, context.Certificate);
                SendServiceDocument(deliveryConfirmationMessage, "Извещение о получении отправлено");
            }
            else
            {
                UserInput.Information("Извещение о получении уже было отправлено");
            }

            // если ожидается подпись то оформляем ответный титул и подписываем или отказываем в подписи
            if (IsSignRequired(documentInfo))
            {
                if (UserInput.ChooseYesNo("Отправитель запросил подпись под документом. Подписать документ?"))
                {
                    if (document.DocumentType == DocumentType.ActOfWorkSeller)
                        SendServiceDocument(
                            CreateMessage(message.GetRecipientListForSender(context.CurrentBox), true, false,
                                document.Id), "Документ подписан");
                    else
                        SendServiceDocument(
                            CreateMessage(message.GetRecipientListForSender(context.CurrentBox), false, true,
                                document.Id), "Документ подписан");
                }
                else
                {
                    // генерируем СД УОУ
                    var text = UserInput.ReadParameter("Текст уточнения:", String.Empty);
                    var amendmentRequestMessage = context.MessageFactory.CreateAmendmentRequest(message, document, text, certificate);
                    SendServiceDocument(amendmentRequestMessage, "Отправлено уведомление об уточнении");
                }
            }
        }

        private void ProcessAuthRequest(Contact contact)
        {
            if (UserInput.ChooseYesNo(String.Format("Авторизовать контрагента {0}", contact.ContragentName)))
            {
                var comment = UserInput.ReadParameter("Комментарий");
                context.ServiceClient.AcceptAuthRequest(context.CurrentOrganizationId, contact.ContragentId, comment);
                UserInput.Success(String.Format("Контрагент {0} авторизован", contact.ContragentName));
            }
            else
            {
                var comment = UserInput.ReadParameter("Комментарий");
                context.ServiceClient.RejectAuthRequest(context.CurrentOrganizationId, contact.ContragentId, comment);
                UserInput.Success(String.Format("Запрос авторизации от {0} отклонен", contact.ContragentName));
            }
        }

        private void SendServiceDocument(Message signMessage, string successText)
        {
            try
            {
                context.ServiceClient.SendMessage(signMessage);
                UserInput.Success(successText);
            }
            catch (ServerException ex)
            {
                if (ex.Code == ServiceErrorCode.SignAlreadyExists || ex.Code == ServiceErrorCode.WorkflowViolation)
                {
                    UserInput.Error("Нарушение регламента ({0}).", ex.Message);
                }
                else
                    throw;
            }
        }

        private string DocumentShortName(FullDocumentInfo fullDocumentInfo)
        {
            switch (fullDocumentInfo.Document.DocumentType)
            {
                case DocumentType.Invoice:
                    var invoiceDocumentFlowStatus = (InvoiceDocumentFlowStatus)fullDocumentInfo.Status;
                    return string.Format("Счет-фактура №{0} от {1}", invoiceDocumentFlowStatus.Number, invoiceDocumentFlowStatus.Date.ToString("dd/MM/yyyy"));
                case DocumentType.Untyped:
                    return string.Format("{0}", fullDocumentInfo.Document.FileName);
                default:
                    return string.Format("{0}", fullDocumentInfo.Document.DocumentType);
            };
        }

        /// <summary>
        /// Список доситупных ящиков
        /// </summary>
        private void Boxes()
        {
            var boxInfos = context.ServiceClient.GetBoxes();
            Console.Out.WriteLine("Доступно {0} ящиков, текущий ящик {1}", boxInfos.Length, context.CurrentBox);
            foreach (var boxInfo in boxInfos)
            {
                Console.Out.WriteLine("ящик: {0}, название: {1}, ИНН/КПП {2}/{3}, id организации {4}", boxInfo.Address,
                                      boxInfo.Name, boxInfo.Inn, boxInfo.Kpp, boxInfo.OrganizationId);
            }
        }

        /// <summary>
        /// Установить текущий ящик
        /// </summary>
        private void SetBox()
        {
            var boxInfos = context.ServiceClient.GetBoxes();
            var options = boxInfos.Select((b, i) => new UserInput.Option(i.ToString(), b.Address, b.Address == context.CurrentBox));
            var chooseOption = UserInput.ChooseOption("Выберите ящик", options);
            context.CurrentBox = chooseOption.Name;
            context.CurrentOrganizationId = boxInfos.Single(i => i.Address == context.CurrentBox).OrganizationId;
            context.LoadLastProcessedMessageId();
            context.MessageFactory = new MessageFactory(context.ServiceClient, context.CurrentBox);
            Console.Out.WriteLine("Текущий ящик {0}", context.CurrentBox);
        }

        /// <summary>
        /// Напечатать доступные команды
        /// </summary>
        /// <param name="commandsMap"></param>
        private void PrintAvailableCommnads(Dictionary<string, Tuple<Action, string>> commandsMap)
        {
            Console.Out.WriteLine("Доступные команды:");
            foreach (var pair in commandsMap)
            {
                Console.Out.WriteLine("\t{0,-15}{1}", pair.Key, pair.Value.Item2);
            }
        }

        private void GetActiveContacts()
        {
            var contactInfos = context.ServiceClient.SearchContacts(new ContactSearchOptions
            {
                From = 0,
                Max = 100,
                OrganizationId = context.CurrentOrganizationId,
                ContactStatus = ContactStatus.Active
            }).Items;
            if (contactInfos.Length == 0)
            {
                Console.Out.WriteLine("Активных контактов нет");
                return;
            }
            foreach (var contactInfo in contactInfos)
            {
                UserInput.Separator();
                var contact = context.ServiceClient.GetContact(context.CurrentOrganizationId,
                                                                contactInfo.ContragentId);
                PrintProperty("Контрагент", contact.ContragentName);
                PrintProperty("Авторизован", contact.Date);
            }
        }

        private void DeleteContact()
        {
            var contactInfos = context.ServiceClient.SearchContacts(new ContactSearchOptions
            {
                From = 0,
                Max = 100,
                OrganizationId = context.CurrentOrganizationId,
                ContactStatus = ContactStatus.Active
            }).Items;
            if (contactInfos.Length == 0)
            {
                Console.Out.WriteLine("Активных контактов нет");
                return;
            }
            var usrInputOptions =
                    contactInfos.Select(
                        (c, i) =>
                        new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture), c.ContragentName, i == 0, c))
                        .ToList();
            var chooseOption = UserInput.ChooseOption("Выберите контакт для удаления", usrInputOptions.AsEnumerable());
            var selectedOrganization = (ContactSearchItem)chooseOption.Data;
            if (!UserInput.ChooseYesNo(String.Format("Вы действительно хотите удалить контакт {0}", selectedOrganization.ContragentName)))
                return;
            var comment = UserInput.ReadParameter("Комментарий");
            try
            {
                context.ServiceClient.DeleteContact(context.CurrentOrganizationId,
                                                    selectedOrganization.ContragentId,
                                                    comment);
            }
            catch (Exception ex)
            {
                UserInput.Error(String.Format("Не удалось удалить контакт {0}",
                                              selectedOrganization.ContragentName));
                UserInput.Error(ex.ToString());
                return;
            }
            UserInput.Success(String.Format("Контакт {0} удален",
                                            selectedOrganization.ContragentName));
        }

        /// <summary>
        /// Авторизоваться
        /// </summary>
        /// <param name="client"></param>
        private void Auth(Client client)
        {
            var byCertificate = new UserInput.Option("1", "По сертификату", true);
            var byPassword = new UserInput.Option("2", "По паролю", false);
            var register = new UserInput.Option("3", "Зарегистрироваться в сервисе", false);

            while (true)
            {
                var authOption = UserInput.ChooseOption("Выберите способ аутентификации", new[]
                                                                    {
                                                                        byCertificate,
                                                                        byPassword,
                                                                        register
                                                                    });

                if (authOption == byPassword)
                {
                    var login = UserInput.ReadParameter("имя пользователя");
                    var password = UserInput.ReadParameter("пароль");

                    try
                    {
                        if (client.Authenticate(login, password, applicationId))
                        {
                            UserInput.Success("Аутентификация прошла успешно");
                            return;
                        }
                        UserInput.Error("Неправильный логин или пароль");
                    }
                    catch (Exception ex)
                    {
                        UserInput.Error("Произошла неожиданная ошибка");
                        UserInput.Error(ex.ToString());
                    }
                }
                else if (authOption == byCertificate)
                {
                    try
                    {
                        // выбор сертификата по списку
                        ChooseCertificate();
                        if (client.AuthenticateWithCertificate(context.Certificate.Thumbprint, applicationId))
                        {
                            UserInput.Success("Аутентификация прошла успешно");
                            return;
                        }
                        UserInput.Error("Аутентификация не пройдена");
                    }
                    catch (Win32Exception win32Ex)
                    {
                        UserInput.Error("Произошла ошибка при попытке расшифровать токен");
                        UserInput.Error(win32Ex.ToString());
                    }
                    catch (Exception ex)
                    {
                        UserInput.Error("Произошла неожиданная ошибка");
                        UserInput.Error(ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        var registerResult = new RegisterResult();

                        registerResult = Register();

                        if (registerResult.Success)
                        {

                            client.Authenticate(registerResult.RegisterModel.Login,
                                registerResult.RegisterModel.Password, applicationId);
                        }

                        return;
                    }
                    catch (Exception ex)
                    {
                        UserInput.Error("Произошла неожиданная ошибка");
                        UserInput.Error(ex.ToString());
                    }

                }
            }
        }

        /// <summary>
        /// Регистрация организации
        /// </summary>
        private RegisterResult Register()
        {
            Console.Out.WriteLine("При регистрации все поля обязательны к заполнению." +
                                  " Если у вас есть сертификат квалифицированной электронной подписи -  выберите сертификат" +
                                  " для автоматического заполнения полей формы регистрации.");
            Console.Out.WriteLine("Регистрация в сервисе Synerdocs:");

            var registerModel = new RegisterModel();

            if (UserInput.ChooseYesNo("Выбрать сертификат?", false))
            {
                // регистрация по сертификату
                ChooseCertificate();
            }
            else
            {
                // регистрация по паролю
                
                // очистим данные о сертификате, если они там есть
                context.Certificate = null;

                registerModel.OrganizationType = (OrganizationType)Enum
                    .Parse(typeof(OrganizationType),
                        UserInput.ChooseOption("Выберите тип организации",
                            new[]
                            {
                                new UserInput.Option("1", "Юридическое лицо", true),
                                new UserInput.Option("2", "Индивидуальный предприниматель", false),
                                new UserInput.Option("3", "Физическое лицо", false)
                            }).Id);

                if (registerModel.OrganizationType == OrganizationType.LegalEntity)
                {
                    registerModel.OrganizationName = UserInput.ReadParameter("Введите наименование организации");
                    registerModel.Kpp = UserInput.ReadParameter("Введите КПП");
                    registerModel.Ogrn = UserInput.ReadParameter("Введите ОГРН");
                }

                if (registerModel.OrganizationType == OrganizationType.IndividualEntrepreneur)
                {
                    registerModel.Ogrn = UserInput.ReadParameter("Введите ОГРНИП");
                }

                registerModel.Inn = UserInput.ReadParameter("Введите ИНН");
                registerModel.FirstName = UserInput.ReadParameter("Введите фамилию");
                registerModel.LastName = UserInput.ReadParameter("Введите имя");
                registerModel.MiddleName = UserInput.ReadParameter("Введите отчество");
                registerModel.Email = UserInput.ReadParameter("Введите e-mail");


            }

            registerModel.Login = UserInput.ReadParameter("Введите логин");
            string pass1 = null, pass2 = null;
            while (!PasswordHelper.CheckPassword(pass1, pass2))
            {
                pass1 = UserInput.ReadPassword("Введите пароль");
                pass2 = UserInput.ReadPassword("Подтвердите пароль");
                if (!PasswordHelper.CheckPassword(pass1, pass2))
                    UserInput.Error("Введённые пароли не совпадают! Повторите ввод пароля.");
            }
            registerModel.Password = pass1;

            registerModel.ServiceReglamentAccepted =
                    UserInput.ChooseYesNo("Вы принимаете доступные по адресу www.synerdocs.ru Правила Synerdocs?", false);
            registerModel.OperatorCode = "2IG";
            registerModel.ServiceCode = Guid.NewGuid().ToString();

            var registerResult = new RegisterResult();


            while (!registerResult.Success)
            {
                registerResult = context.ServiceClient.Register(registerModel, context.Certificate != null ? context.Certificate.RawData : null);

                if (registerResult.Success)
                {
                    UserInput.Success(String.Format("Регистрация {0} прошла успешно",
                        registerResult.RegisterModel.OrganizationName));
                    return registerResult;
                }
                UserInput.Error("Во время регистрации обнаружены ошибки: \n" + string.Join("\n", registerResult.ErrorMessages));

                var externalInfoType = typeof(RegisterModel);
                foreach (var errorMember in registerResult.ErrorMembers)
                {
                    var propertyInfo = externalInfoType.GetProperty(errorMember);
                    if (propertyInfo != null)
                    {
                        var attributes = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                        if (attributes.Any())
                        {
                            var displayNameAttr = ((DisplayNameAttribute)attributes[0]);

                            if (propertyInfo.PropertyType == typeof(bool))
                            {
                                propertyInfo.SetValue(registerModel,
                                    Convert.ChangeType(UserInput.ChooseYesNo(displayNameAttr.DisplayName, false),
                                        propertyInfo.PropertyType), null);
                            }
                            else
                            {
                                propertyInfo.SetValue(registerModel,
                                    Convert.ChangeType(UserInput.ReadParameter(displayNameAttr.DisplayName),
                                        propertyInfo.PropertyType), null);
                            }

                        }

                    }

                }

            }

            return registerResult;
        }

        /// <summary>
        /// Принятие Правил Synerdocs
        /// </summary>
        private void AcceptRegulation()
        {
            var acceptRegulation = UserInput.ChooseYesNo("Вы принимаете доступные по адресу www.synerdocs.ru Правила Synerdocs?", false);

            if (context.ServiceClient.AcceptRegulation(context.CurrentBox, acceptRegulation))
            {
                UserInput.Success("Правила Synerdocs успешно приняты.");
            }
            else UserInput.Error("Правила Synerdocs не были приняты.");

        }

        /// <summary>
        /// Просмотр дерева орг.структуры
        /// </summary>
        private void GetOrganizationStructure()
        {
            do
            {
                var departmentInfos = context.ServiceClient.GetOrganizationStructure(context.CurrentBox,
                                                                                     context.CurrentOrganizationId.
                                                                                         ToString());
                if (departmentInfos.Length == 0)
                {
                    Console.Out.WriteLine("Подразделений нет");
                    return;
                }


                departmentsOptions = new List<UserInput.Option>();
                index = 0;
                var depInputOptions = GetTreeOfOrganizationStructure(departmentInfos,
                                                                     new []
                                                                         {
                                                                             departmentInfos.First(
                                                                                 d => string.IsNullOrWhiteSpace(d.ParentId))
                                                                         }, 0);

                var chooseOption =
                    UserInput.ChooseOption("Для просмотра более детальной информации выберите подразделение",
                                           depInputOptions.AsEnumerable());
                var selectedDepartment = (OrganizationStructureElement)chooseOption.Data;

                PrintProperty("Наименование", selectedDepartment.Name);
                PrintProperty("Код", selectedDepartment.Code);
                PrintProperty("КПП", selectedDepartment.Kpp);
                PrintProperty("Примечание", selectedDepartment.AdditionalInfo);
                if (!string.IsNullOrWhiteSpace(selectedDepartment.ParentId))
                    PrintProperty("Родительское подразделение",
                                  departmentInfos.First(d => d.Id == selectedDepartment.ParentId).Name);

                if (!UserInput.ChooseYesNo("Хотите просмотреть другие подразделения?", false))
                    break;
            } while (true);
        }

        /// <summary>
        /// Удалить подразделение
        /// </summary>
        private void DeleteOrganizationStructureElement()
        {
            var departmentInfos = context.ServiceClient.GetOrganizationStructure(context.CurrentBox, context.CurrentOrganizationId.ToString());
            if (departmentInfos.Length == 0)
            {
                Console.Out.WriteLine("Подразделений нет");
                return;
            }

            departmentsOptions = new List<UserInput.Option>();
            index = 0;
            var depInputOptions = GetTreeOfOrganizationStructure(departmentInfos, new OrganizationStructureElement[] { departmentInfos.First(d => d.ParentId == null) }, 0);

            var chooseOption = UserInput.ChooseOption("Выберите подразделение", depInputOptions.AsEnumerable());
            var selectedDepartment = (OrganizationStructureElement)chooseOption.Data;

            if (!UserInput.ChooseYesNo(String.Format("Вы действительно хотите удалить подразделение {0}", selectedDepartment.Name)))
                return;
            try
            {
                context.ServiceClient.DeleteOrganizationStructureElement(context.CurrentOrganizationId.ToString(), selectedDepartment.Id);
            }
            catch (Exception ex)
            {
                UserInput.Error(String.Format("Не удалось удалить подразделение {0}", selectedDepartment.Name));
                UserInput.Error(ex.ToString());
                return;
            }
            UserInput.Success(String.Format("Подразделение {0} удалено", selectedDepartment.Name));
        }

        /// <summary>
        /// Добавить подразделение
        /// </summary>
        private void AddOrganizationStructureElement()
        {
            do
            {
                var departmentInfos = context.ServiceClient.GetOrganizationStructure(context.CurrentBox, context.CurrentOrganizationId.ToString());
                if (departmentInfos.Length == 0)
                {
                    Console.Out.WriteLine("Подразделений нет");
                    return;
                }

                departmentsOptions = new List<UserInput.Option>();
                index = 0;
                var depInputOptions = GetTreeOfOrganizationStructure(departmentInfos, new OrganizationStructureElement[] { departmentInfos.First(d => d.ParentId == null) }, 0);

                var chooseOption = UserInput.ChooseOption("Выберите родительское подразделение", depInputOptions.AsEnumerable());
                if (chooseOption.Data == null)
                    continue;
                var selectedDepartment = (OrganizationStructureElement)chooseOption.Data;

                var elementName = UserInput.ReadParameter("Введите наименование нового подразделения");
                var elementCode = UserInput.ReadParameter("Введите код нового подразделения");
                var elementKpp = UserInput.ReadParameter("Введите КПП нового подразделения");
                var elementAdditionalInfo = UserInput.ReadParameter("Введите примечание");

                try
                {
                    var elementId = context.ServiceClient.AddOrganizationStructureElement(new OrganizationStructureElement
                    {
                        Code = elementCode,
                        AdditionalInfo = elementAdditionalInfo,
                        Kpp = elementKpp,
                        Name = elementName,
                        OrganizationId = context.CurrentOrganizationId.ToString(),
                        ParentId = selectedDepartment.Id
                    });
                }
                catch (Exception ex)
                {
                    UserInput.Error(String.Format("Не удалось добавить подразделение {0}", elementName));
                    UserInput.Error(ex.ToString());
                    return;
                }
                UserInput.Success(String.Format("Подразделение {0} добавлено", elementName));
                return;
            } while (true);
        }

        /// <summary>
        /// Редактировать подразделение
        /// </summary>
        private void EditOrganizationStructureElement()
        {
            do
            {
                var departmentInfos = context.ServiceClient.GetOrganizationStructure(context.CurrentBox, context.CurrentOrganizationId.ToString());
                if (departmentInfos.Length == 0)
                {
                    Console.Out.WriteLine("Подразделений нет");
                    return;
                }

                departmentsOptions = new List<UserInput.Option>();
                index = 0;
                var depInputOptions = GetTreeOfOrganizationStructure(departmentInfos, new OrganizationStructureElement[] { departmentInfos.First(d => d.ParentId == null) }, 0);

                var chooseOption = UserInput.ChooseOption("Выберите подразделение", depInputOptions.AsEnumerable());
                if (chooseOption.Data == null)
                    continue;
                var selectedDepartment = (OrganizationStructureElement)chooseOption.Data;


                if (UserInput.ChooseYesNo("Изменить наименование подразделения?", false))
                {
                    selectedDepartment.Name = UserInput.ReadParameter("Введите новое наименование подразделения");
                }
                if (UserInput.ChooseYesNo("Изменить код подразделения?", false))
                {
                    selectedDepartment.Code = UserInput.ReadParameter("Введите новый код подразделения");
                }
                if (UserInput.ChooseYesNo("Изменить КПП подразделения?", false))
                {
                    selectedDepartment.Kpp = UserInput.ReadParameter("Введите новый КПП подразделения");
                }
                if (UserInput.ChooseYesNo("Изменить примечание к подразделению?", false))
                {
                    selectedDepartment.AdditionalInfo = UserInput.ReadParameter("Введите новое примечание");
                }

                if (UserInput.ChooseYesNo("Изменить родительское подразделение?", false))
                {
                    chooseOption = UserInput.ChooseOption("Выберите новое родительское подразделение", depInputOptions.AsEnumerable());
                    if (chooseOption.Data == null)
                        continue;
                    if (selectedDepartment.Id != ((OrganizationStructureElement)chooseOption.Data).Id)
                        selectedDepartment.ParentId = ((OrganizationStructureElement)chooseOption.Data).Id;
                    else
                    {
                        UserInput.Error(String.Format("Подразделение {0} не может быть родительским для самого себя", selectedDepartment.Name));
                        return;
                    }
                }

                try
                {
                    context.ServiceClient.ModifyOrganizationStructureElement(selectedDepartment);
                }
                catch (Exception ex)
                {
                    UserInput.Error(String.Format("Не удалось изменить подразделение {0}", selectedDepartment.Name));
                    UserInput.Error(ex.ToString());
                    return;
                }
                UserInput.Success(String.Format("Изменения по подразделению {0} сохранены", selectedDepartment.Name));
                return;
            } while (true);
        }

        /// <summary>
        /// возвращает отступы для дерева орг.структуры
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private string GetSpace(int count)
        {
            var space = String.Empty;
            while (count > 0)
            {
                space = space + "  ";
                count = count - 1;
            }
            return space;
        }

        /// <summary>
        /// возвращает дерево орг.структуры
        /// </summary>
        /// <param name="data"></param>
        /// <param name="elements"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<UserInput.Option> GetTreeOfOrganizationStructure(OrganizationStructureElement[] data, OrganizationStructureElement[] elements, int count)
        {
            foreach (var element in elements)
            {
                var label = GetSpace(count) + element.Name + " КПП: " + element.Kpp;
                departmentsOptions.Add(new UserInput.Option((index + 1).ToString(CultureInfo.InvariantCulture), label, index == 0, element));
                index++;
                var childElements = data.Where(d => d.ParentId == element.Id);
                if (childElements.ToArray().Length != 0)
                    GetTreeOfOrganizationStructure(data, childElements.ToArray(), count + 1);
            }

            return departmentsOptions;
        }
    }
}
