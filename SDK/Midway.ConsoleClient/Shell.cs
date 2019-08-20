using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Midway.Crypto;
using Midway.ObjectModel;
using Midway.ObjectModel.Common;
using Midway.ObjectModel.Exceptions;
using Midway.ObjectModel.Extensions;
using Midway.ServiceClient;

/* 
 * Консольное приложение (Консольный клиент) как пример кода демонстрирует возможности*:
 * [+] авторизация по логину паролю
 * [+] авторизация по сертификату
 * [+] отправка подписанного НД
 * [+] подписание НД
 * [+] отказ от подписи под НД
 * [+] отправка ИОД для НД
 * [+] прием СД для НД (ИОП, УОУ, Подпись)
 * [+] отправка СФ
 * [+] отправка СД для СФ
 * [+] прием СД для СФ
 * [+] работа с черновиками сообщений
 * [+] отправка нескольких документов
 * [+] обработка ошибок
 * [-] SSL
 * [+] загрузка большого документа (>1Мб)
 * [-] повторная отправка сообщения
 * [+-] загрузка, сохранение документа и документооборота на диск
 * [+] отображение подписи входящего документа
 * [-] работа с контактами
 * 
 * *пояснения:
 * [+] - сценарий использования есть полностью в коде консольного клиента
 * [-] - сценария использования нет в коде консольного клиента, но такая возможность есть
 * [+-] - сценария использования только частично есть в коде консольного клиента
 * 
 * НД - неформализованный документ (любой произвольный файл)
 * СД - служебный документ \ сервисный документ - неосновной документ документооборота, например УОУ
 * ИОД - извщение о доставке (в рамках документооборота СФ)
 * ИОП - извщение о получении (в рамках документооборота СФ)
 * УОУ - уведомление об уточнении (в рамках документооборота СФ)
 * Подпись - фактически бинарный файл (электронная подпись) к файлу, полученный с помощью средств криптографии и сертификата электронной подписи
 * СФ - счет-фактура
 */

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Основной объект - консольное приложение для примера использования API, использует подключение к API Synerdocs.
    /// Работа через консоль.
    /// </summary>
    public class Shell
    {
        private readonly string _applicationId;
        private readonly string _applicationVersion;
        private ClientContext _context;
        private List<UserInput.Option> _departmentsOptions;
        private int _index;

        /// <summary>
        /// Алгоритмы подписи сертификата, поддерживаемые консольным клиентом.
        /// </summary>
        private static readonly string[] _supportedSignatureAlgorithms = new[]
        {
            "1.2.643.2.2.3", //ГОСТ Р 34.10-2001
            "1.2.643.7.1.1.3.2", //ГОСТ Р 34.10-2012 (256 бит)
            "1.2.643.7.1.1.3.3" //ГОСТ Р 34.10-2012 (512 бит)
        };

        /// <summary>
        /// КОНСТРУКТОР
        /// Основной объект - консольное приложение для примера использования API, использует подключение к API Synerdocs.
        /// </summary>
        public Shell()
        {
            // идентификатор клиентского приложения и версии - может быть задан другой
            _applicationId = "45EFA3B0-4302-4CF6-95AD-5ACA21EE2FA2";
            _applicationVersion = "ConsoleClient";
        }

        /// <summary>
        /// Обработка запуска консольного приложения с параметрами командной строки.
        /// </summary>
        /// <param name="args">аргументы \ параметры запуска из командной строки.</param>
        public void Run(string[] args)
        {
            var url = args[0];

            // Выбор нужной конечной точки в клиенте для возможности подключения по URL как по http, так и по https
            var configEndpointName = url.StartsWith("https")
                ? "WSHttpsBinding_IExchangeService"
                : "WSHttpBinding_IExchangeService";

            // принять url
            var client = new Client(url, false, false, _applicationVersion, configEndpointName);

            try
            {
                _context = new ClientContext
                {
                    ServiceClient = client
                };

                // аутентификация
                Auth(client);

                // следующие команды ...
                var commandsMap = new Dictionary<string, Tuple<Action, string>>
                {
                    {
                        "get-boxes",
                        Tuple.Create<Action, string>(Boxes, "Показать список ящиков")},
                    {
                        "set-box",
                        Tuple.Create<Action, string>(SetBox, "Выбрать ящик")
                    },
                    {
                        "load-messages",
                        Tuple.Create<Action, string>(LoadMessages, "Загрузить и обработать входящие сообщения")
                    },
                    {
                        "send-docs",
                        Tuple.Create<Action, string>(() => SendDocuments(FlowType.SentSigned), "Отправить документы")
                    },
                    {
                        "send-unsigned",
                        Tuple.Create<Action, string>(
                            () => SendDocuments(FlowType.SentUnsigned),
                            "Отправить документы без подписи")
                    },
                    {
                        "send-forward",
                        Tuple.Create<Action, string>(() => SendDocuments(FlowType.SentForward), "Переслать документы")
                    },
                    {
                        "send-internal",
                        Tuple.Create<Action, string>(
                            () => SendDocuments(FlowType.SentInternal),
                            "Отправить документы подразделению")
                    },
                    {
                        "sign-document",
                        Tuple.Create<Action, string>(SignDocument, "Подписать документ")
                    },
                    {
                        "reject-sign",
                        Tuple.Create<Action, string>(RejectSign, "Отказать в подписании документа")
                    },
                    {
                        "move-docs",
                        Tuple.Create<Action, string>(MoveDocuments, "Переместить документы в подразделение")
                    },
                    {
                        "get-doc-entries",
                        Tuple.Create<Action, string>(GetDocumentEntries, "Список вхождений документов")
                    },
                    {
                        "get-doc-inner",
                        Tuple.Create<Action, string>(GetInternalDocuments, "Список внутренних документов")
                    },
                    {
                        "get-doc-list",
                        Tuple.Create<Action, string>(GetDocumentList, "Список документов")
                    },
                    {
                        "get-doc-info",
                        Tuple.Create<Action, string>(GetDocumentInfo, "Загрузить документ")
                    },
                    {
                        "get-doc-flow",
                        Tuple.Create<Action, string>(GetDocumentFlow, "Загрузить документ c вхождениями")
                    },
                    {
                        "get-draft-list",
                        Tuple.Create<Action, string>(GetDraftMessageList, "Список черновиков")
                    },
                    {
                        "get-draft",
                        Tuple.Create<Action, string>(GetDraftMessage, "Загрузить черновик")},
                    {
                        "del-draft",
                        Tuple.Create<Action, string>(DeleteDraftMessage, "Удалить черновик")
                    },
                    {
                        "move-draft",
                        Tuple.Create<Action,string>(MoveDraftMessage, "Передать черновик")
                    },
                    {
                        "get-contacts",
                        Tuple.Create<Action, string>(GetActiveContacts, "Список активных контактов")
                    },
                    {
                        "del-contact",
                        Tuple.Create<Action, string>(DeleteContact, "Удалить контакт")},
                    {
                        "get-structure",
                        Tuple.Create<Action, string>(GetOrganizationStructure, "Дерево орг.структуры")
                    },
                    {
                        "add-department",
                        Tuple.Create<Action, string>(AddOrganizationStructureElement, "Добавить подразделение")
                    },
                    {
                        "edit-department",
                        Tuple.Create<Action, string>(EditOrganizationStructureElement, "Изменить подразделение")
                    },
                    {
                        "del-department",
                        Tuple.Create<Action, string>(DeleteOrganizationStructureElement, "Удалить подразделение")
                    },
                    {
                        "accept-reg",
                        Tuple.Create<Action, string>(AcceptRegulation, "Принять Правила Synerdocs")
                    },
                    {
                        "add-doc-tag",
                        Tuple.Create<Action, string>(AddDocumentTag, "Создать дополнительный статус(тэг) к документу")
                    },
                    {
                        "del-doc-tag",
                        Tuple.Create<Action, string>(
                            DeleteDocumentTag,
                            "Удалить дополнительный статус(тэг), прикрепленный к документу")
                    },
                    {
                        "get-doc-tag",
                        Tuple.Create<Action, string>(
                            GetDocumentTag,
                            "Показать информацию по дополнительному статусу(тэгу)")
                    },
                    {
                        "add-promocode",
                        Tuple.Create<Action, string>(AddOrganizationPromoCode, "Добавить промокод в организацию")
                    },
                    {
                        "get-promocode-list",
                        Tuple.Create<Action, string>(GetOrganizationPromoCodeList, "Список промокодов организации")
                    },
                    {
                        "get-promocode",
                        Tuple.Create<Action, string>(GetPromoCodeByName, "Получить промокод")
                    },
                    {
                        "del-promocode",
                        Tuple.Create<Action, string>(DeleteOrganizationPromoCode, "Удалить промокод")
                    },
                    {
                        "get-messages-without-content",
                        Tuple.Create<Action, string>(
                            GetMessagesWithoutDocumentsSignsContent,
                            "Загрузить входящие сообщения без содержимого документов и подписей")
                    },
                    {
                        "send-revocation-offer",
                        Tuple.Create<Action, string>(SendRevocationOffer, "Отправить ПОА")
                    },
                    {
                        "send-statement",
                        Tuple.Create<Action, string>(
                            SendStatementOfInvoiceReglament,
                            "Отправить заявление об участии в ЭДО счетов-фактур")
                    },
                    {
                        "download-flow",
                        Tuple.Create<Action, string>(DownloadDocumentFlowArchive, "Скачать документооборот в архиве")
                    },
                    {
                        "parse-document",
                        Tuple.Create<Action, string>(TryParseDocumentContentFromFile, "Распарсить документ")
                    },
                    {
                        "download-pdf",
                        Tuple.Create<Action, string>(DownloadPdfDocument, "Скачать документ в формате pdf")
                    },
                    {
                        "create-non-active-subscriber",
                        Tuple.Create<Action, string>(CreateNonActiveSubscriber, "Создать неактивного абонента")
                    },
                    {
                        "check-simple-sgn",
                        Tuple.Create<Action,string>(
                            CheckSimpleSignatureAvailability,
                            "Проверить доступность подписания документа простой ЭП")
                    },
                    {
                        "accept-simple-sgn",
                        Tuple.Create<Action,string>(
                            AcceptSimpleSignatureRegulation,
                            "Принять регламент использования простой ЭП")
                    },
                    {
                        "prev-simple-sgn",
                        Tuple.Create<Action,string>(
                            PreviewSimpleSignatureRequisites,
                            "Предварительный просмотр реквизитов простой ЭП")
                    },
                    {
                        "crt-simple-sgn",
                        Tuple.Create<Action,string>(CreateSimpleSignature, "Подписать документ простой ЭП")
                    },
                    {
                        "print-document",
                        Tuple.Create<Action, string>(PrintDocument, "Напечатать документ")
                    }
                };

                PrintAvailableCommands(commandsMap);

                // выбираем первый доступный ящик
                var firstAvailableBox = client.GetBoxes().FirstOrDefault();
                if (firstAvailableBox == null)
                {
                    throw new InvalidOperationException("У пользователя нет доступа ни к одному абонентскому ящику.");
                }
                _context.CurrentBox = firstAvailableBox.Address;
                _context.CurrentOrganizationId = firstAvailableBox.OrganizationId;
                _context.LoadLastProcessedMessageId();
                _context.MessageFactory = new MessageFactory(_context.ServiceClient, _context.CurrentBox);

                if (string.IsNullOrWhiteSpace(_context.Login))
                {
                    var userInfo = client.GetUserInfo(_context.CurrentBox);
                    _context.Login = userInfo.Login;
                }

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
                        PrintAvailableCommands(commandsMap);
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

        /// <summary>
        /// Выбрать контрагента (например получателя) из списка доступных для обмена или 
        /// указать вручную - например: указав ящик контрагента.
        /// </summary>
        /// <returns></returns>
        private MessageRecipient ChooseExternalRecipient(List<string> selectedContactList)
        {
            var fromList = new UserInput.Option("1", "Из списка контрагентов", true, true);
            var manuallyEntry = new UserInput.Option("2", "Ввести вручную", false, true);

            var chooseOption = UserInput.ChooseOption("Выбрать получателя", new[]
                                                                            {
                                                                                fromList,
                                                                                manuallyEntry
                                                                            });
            string organizationId;
            string boxAddress;
            if (chooseOption == fromList)
            {
                ContactSearchResult contactSearchResult;
                var contactList = new List<ContactSearchItem>();
                var from = 0;
                const int pageSize = 20;
                do
                {
                    contactSearchResult = _context.ServiceClient.SearchContacts(
                        new ContactSearchOptions
                        {
                            OrganizationId = _context.CurrentOrganizationId,
                            ContactStatus = ContactStatus.Active,
                            From = from,
                            Max = pageSize
                        });
                    contactList.AddRange(contactSearchResult.Items);
                    contactList.RemoveAll(c => selectedContactList.Any(value => value.Equals(c.BoxAddress)));
                    from += pageSize;
                } while (contactSearchResult.TotalCount > from);
                var contragentOption = UserInput.ChooseOption
                    ("Выберите получателя",
                        contactList.Select(
                            (c, i) =>
                                new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture), c.ContragentName,
                                    i == 0, c)));
                var contactSearchItem = ((ContactSearchItem)contragentOption.Data);
                organizationId = contactSearchItem.ContragentId.ToString(CultureInfo.InvariantCulture);
                boxAddress = contactSearchItem.BoxAddress;
            }
            else
            {
                var address = UserInput.ReadParameter("Введите адрес получателя");
                if (selectedContactList.Any(value => value.Equals(address)))
                {
                    UserInput.Error("Получатель с таким адресом уже указан");
                    return null;
                }

                var organization = _context.ServiceClient.GetOrganizationBy(_context.CurrentBox,
                    OrganizationByCriteria.ByBoxAddress,
                    new OrganizationByCriteriaValues { BoxAddress = address });

                if (organization == null)
                {
                    UserInput.Error("Неправильно указан адресат");
                    return null;
                }
                UserInput.Success(string.Format("Выбрана организация: {0}", organization.Name));
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
            var selectedDepartment =
                ChooseOrganizationStructureElement(_context.CurrentOrganizationId.ToString(CultureInfo.InvariantCulture));
            if (selectedDepartment != null)
                internalRecipient.DepartmentId = selectedDepartment.Id;
            if (UserInput.ChooseYesNo("Указать пользователя"))
            {
                var selectedUser = ChooseUser(selectedDepartment.Id);
                if (selectedUser != null)
                    internalRecipient.UserLogin = selectedUser.Login;
            }
            return internalRecipient;
        }

        private string ChooseContragentBox()
        {
            var fromList = new UserInput.Option("1", "Из списка контрагентов", true, true);
            var manuallyEntry = new UserInput.Option("2", "Ввести вручную", false, true);

            var chooseOption = UserInput.ChooseOption("Выбрать контрагента", new[]
                                                                             {
                                                                                 fromList,
                                                                                 manuallyEntry
                                                                             });
            string boxAddress;
            if (chooseOption == fromList)
            {
                ContactSearchResult contactSearchResult;
                var contactList = new List<ContactSearchItem>();
                var from = 0;
                const int pageSize = 20;
                do
                {
                    contactSearchResult = _context.ServiceClient.SearchContacts(
                        new ContactSearchOptions
                        {
                            OrganizationId = _context.CurrentOrganizationId,
                            ContactStatus = ContactStatus.Active,
                            From = from,
                            Max = pageSize
                        });
                    contactList.AddRange(contactSearchResult.Items);
                    from += pageSize;
                } while (contactSearchResult.TotalCount > from);
                var contragentOption = UserInput.ChooseOption
                    ("Выберите контрагента",
                        contactList.Select(
                            (c, i) =>
                                new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture), c.ContragentName,
                                    i == 0, c)));
                var contactSearchItem = ((ContactSearchItem)contragentOption.Data);
                boxAddress = contactSearchItem.BoxAddress;
            }
            else
            {
                var address = UserInput.ReadParameter("Введите адрес контрагента");
                var organization = _context.ServiceClient.GetOrganizationBy(_context.CurrentBox,
                    OrganizationByCriteria.ByBoxAddress,
                    new OrganizationByCriteriaValues { BoxAddress = address });

                if (organization == null)
                {
                    UserInput.Error("Неправильно указан адресат");
                    return null;
                }
                UserInput.Success(string.Format("Выбрана организация: {0}", organization.Name));
                boxAddress = organization.BoxAddress;
            }

            return boxAddress;
        }

        private OrganizationStructureElement ChooseOrganizationStructureElement(string organizationId)
        {
            var departmentInfos = _context.ServiceClient.GetOrganizationStructure
                (_context.CurrentBox, organizationId);


            var depInputOptions =
                departmentInfos.Select
                    (
                        (c, i) =>
                            new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture), c.Name, i == 0, c))
                    .ToList();

            var chooseOption = UserInput.ChooseOption("Выберите подразделение получателя", depInputOptions);
            return (OrganizationStructureElement)chooseOption.Data;
        }

        private User ChooseUser(string departmentId)
        {
            var fromList = new UserInput.Option("1", "Из списка сотрудников", true, true);
            var manuallyEntry = new UserInput.Option("2", "Ввести вручную", false, true);

            var chooseOption = UserInput.ChooseOption(
                "Выбрать пользователя",
                new[]
                {
                    fromList,
                    manuallyEntry
                });

            if (chooseOption != fromList)
                return new User
                {
                    Login = UserInput.ReadParameter("Укажите логин пользователя")
                };

            var userList = _context.ServiceClient.GetDepartmentEmployees(_context.CurrentBox, departmentId);
            if (userList.Length == 0)
            {
                UserInput.Warning("У подразделения нет сотрудников");
                return null;
            }
            var userOption = UserInput.ChooseOption(
                "Выберите сотрудника",
                userList.Select((u, i) => new UserInput.Option(
                    (i + 1).ToString(CultureInfo.InvariantCulture),
                    string.Format("{0} {1} {2}", u.LastName, u.FirstName, u.MiddleName),
                    i == 0,
                    u)));
            return (User)userOption.Data;
        }

        /// <summary>
        /// Выбрать директорию.
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
        /// Запрашивает у пользователя тип документооборота.
        /// </summary>
        /// <returns>Тип документооборота.</returns>
        private FlowType ChooseFlowType()
        {
            return (FlowType)int.Parse(UserInput
                .ChooseOption("Выберите тип документооборота", new[]
                                                               {
                                                                   new UserInput.Option(
                                                                       ((int) FlowType.SentUnsigned).ToString(
                                                                           CultureInfo.InvariantCulture),
                                                                       "Без подписи", true),
                                                                   new UserInput.Option(
                                                                       ((int) FlowType.SentForward).ToString(
                                                                           CultureInfo.InvariantCulture),
                                                                       "Пересланный", false),
                                                                   new UserInput.Option(
                                                                       ((int) FlowType.SentInternal).ToString(
                                                                           CultureInfo.InvariantCulture),
                                                                       "Внутренний", false)
                                                               })
                .Id);
        }

        /// <summary>
        /// Отправить документы.
        /// </summary>
        private void SendDocuments(FlowType flowType)
        {
            var externalRecipients = new List<MessageRecipient>();
            var internalRecipients = new List<InternalMessageRecipient>();
            do
            {
                if (flowType != FlowType.SentInternal)
                {
                    var recipient = ChooseExternalRecipient(externalRecipients.Select(r => r.OrganizationBoxId).ToList());
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
            } while (true);

            IMessage message = null;
            switch (flowType)
            {
                case FlowType.SentSigned:
                    message = CreateMessage(externalRecipients);
                    break;

                case FlowType.SentUnsigned:
                    message = CreateUnsignedMessage(externalRecipients);
                    break;

                case FlowType.SentForward:
                    message = CreateForwardMessage(externalRecipients);
                    break;

                case FlowType.SentInternal:
                    message = CreateInternalMessage(internalRecipients);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(flowType));
            }

            if ((message is ForwardMessage && (message as ForwardMessage).ForwardDocuments.Length == 0)
                || (!(message is ForwardMessage) && message.Documents.Length == 0))
            {
                UserInput.Error("Документы для отправки не выбраны");
                return;
            }

            var sendMessageOption = new UserInput.Option("1", "Отправить сообщение", true);
            var saveToDraftOption = new UserInput.Option("2", "Сохранить как черновик", false);

            var chosenOption = UserInput.ChooseOption("Выберите действие", new[]
            {
                sendMessageOption,
                saveToDraftOption,
            });

            if (chosenOption == sendMessageOption)
            {
                if (message.Documents != null
                    && message.Documents.Any(_ => _.DocumentType.IsEdiDocument()))
                {
                    UserInput.Information("В сообщении для отправки обнаружены EDI-документы");
                    sendMessageOption = new UserInput.Option("1", "Исключить EDI-документы и отправить сообщение", false);
                    saveToDraftOption = new UserInput.Option("2", "Конвертировать EDI-документы и сохранить как черновик", true);

                    chosenOption = UserInput.ChooseOption("Выберите действие", new[]
                    {
                        sendMessageOption,
                        saveToDraftOption,
                    });

                    if (chosenOption == sendMessageOption)
                        message.Documents = message.Documents
                            .Where(_ => !_.DocumentType.IsEdiDocument())
                            .ToArray();

                    if (!(message is ForwardMessage) && message.Documents.Length == 0)
                    {
                        UserInput.Error("ЮЗЭДО-документы для отправки не выбраны");
                        return;
                    }
                }

                if (chosenOption == sendMessageOption)
                {
                    try
                    {
                        SentMessage sentMessage = null;
                        if (message is Message)
                            sentMessage = _context.ServiceClient.SendMessage(message as Message);
                        else if (message is UnsignedMessage)
                            sentMessage = _context.ServiceClient.SendUnsignedMessage(message as UnsignedMessage);
                        else if (message is ForwardMessage)
                            sentMessage = _context.ServiceClient.SendForwardMessage(message as ForwardMessage);
                        else if (message is InternalMessage)
                            sentMessage = _context.ServiceClient.SendInternalMessage(message as InternalMessage);
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
            }

            if (chosenOption == saveToDraftOption)
            {
                var draftMessage = ConvertToDraftMessage(message);
                try
                {
                    var draftMessageId = _context.ServiceClient.CreateDraftMessage(draftMessage);
                    UserInput.Success("Черновик сообщения сохранен, Id:{0}", draftMessageId);
                }
                catch (ServerException ex)
                {
                    if (ex.Code == ServiceErrorCode.InvalidFormatField)
                    {
                        UserInput.Error(ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Подписание документа.
        /// </summary>
        private void SignDocument()
        {
            var flowType = ChooseFlowType();
            var signature = ChooseSignature();

            try
            {
                if (signature is Sign)
                    _context.ServiceClient.SignDocument(flowType, (Sign)signature);
                else
                    _context.ServiceClient.SignDocumentWithSimpleSignature(flowType, (SimpleSignature)signature);
                UserInput.Success("Документ был успешно подписан");
            }
            catch (Exception ex)
            {
                UserInput.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Отказать в подписании.
        /// </summary>
        private void RejectSign()
        {
            var flowType = ChooseFlowType();
            var documentId = UserInput.ReadParameter("Введите ИД документа");
            var comment = UserInput.ReadParameter("Введите уведомление об уточнении");

            var rejectSign = new RejectSign
            {
                From = _context.CurrentBox,
                DocumentId = documentId,
                Comment = comment
            };

            try
            {
                _context.ServiceClient.RejectSign(flowType, rejectSign);
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
                    var documentId =
                        UserInput.ReadParameter("Введите ИД документа (или пустую строку для прекращения ввода)");
                    if (string.IsNullOrEmpty(documentId))
                        break;
                    documentIds.Add(documentId);
                } while (true);
            }

            var department =
                ChooseOrganizationStructureElement(_context.CurrentOrganizationId.ToString(CultureInfo.InvariantCulture));
            if (department != null)
            {
                try
                {
                    if (documentIds.Count > 1)
                    {
                        var movedIds = _context.ServiceClient.MoveDocumentsToDepartment(_context.CurrentBox,
                            documentIds.ToArray(), department.Id);
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
                        if (_context.ServiceClient.MoveDocumentToDepartment(_context.CurrentBox, documentIds[0],
                            department.Id))
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
                Comment = document.Comment
            };
        }

        /// <summary>
        /// Преобразование документа в документ черновика.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        private static DraftDocument ConvertToDraftDocument(Document document)
        {
            var draftDocument = new DraftDocument
            {
                Id = document.Id,
                DocumentType = document.DocumentType,
                UntypedKind = document.UntypedKind,
                Name = document.Name ?? document.FileName,
                FileName = document.FileName,
                FileSize = document.FileSize,
                Content = document.Content,
                Card = document.Card,
                Comment = document.Comment,
                NeedSign = document.NeedSign,
                NeedReceipt = document.NeedReceipt,
                ParentDocumentId = document.ParentDocumentId
            };

            if (!draftDocument.DocumentType.IsEdiDocument())
                return draftDocument;

            UserInput.Information(
                $"Документ '{draftDocument.Name}' является EDI-документом. " +
                "При загрузке в черновик он будет сконвертирован в ЮЗЭДО-документ.");

            draftDocument.Name = null;
            draftDocument.FileName = null;

            draftDocument.ConversionSettings = new ConversionSettings
            {
                SourceFormat = new DocumentFormat
                {
                    DocumentTypeInfo = new DocumentTypeInfo
                    {
                        DocumentType = draftDocument.DocumentType.ToEnumValue()
                    },
                },
            };

            draftDocument.DocumentType = ChooseDocumentType("Выберите тип ЮЗЭДО-документа для конвертации",
                includeUntyped: false,
                includeEdi: false);

            if (!UserInput.ChooseYesNo("Выбрать дополнительные параметры конвертации?", false))
                return draftDocument;

            if (!UserInput.ChooseYesNo("Автоматически заполнить наименование документа?", true))
            {
                draftDocument.Name = document.Name ?? document.FileName;
                draftDocument.FileName = document.FileName;
            }

            draftDocument.ConversionSettings.SourceFormat.ContentFormat = new ContentFormatEnum
            {
                Value = (ContentFormat)UserInput.ChooseOption("Выберите формат содержимого", new[]
                {
                    new UserInput.Option("1", "Определить автоматически", true, ContentFormat.Unknown),
                    new UserInput.Option("2", "Формат XML", false, ContentFormat.Xml),
                    new UserInput.Option("3", "Формат JSON", false, ContentFormat.Json),
                }).Data,
            };

            draftDocument.ConversionSettings.SourceFormat.Encoding = ((Encoding)UserInput.ChooseOption("Выберите кодировку текста", new[]
            {
                new UserInput.Option("1", "Определить автоматически", true, null),
                new UserInput.Option("2", "UTF-8", false, Encoding.UTF8),
                new UserInput.Option("3", "Windows-1251", false, Encoding.GetEncoding(1251)),
            }).Data)?.WebName;

            return draftDocument;
        }

        private static DraftMessage ConvertToDraftMessage(IMessage message)
        {
            if (message is Message)
                return ConvertToDraftMessage(message as Message);
            else if (message is UnsignedMessage)
                return ConvertToDraftMessage(message as UnsignedMessage);
            else if (message is ForwardMessage)
                return ConvertToDraftMessage(message as ForwardMessage);
            else if (message is InternalMessage)
                return ConvertToDraftMessage(message as InternalMessage);
            else
                throw new ArgumentException(nameof(message));
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
                RelatedDocuments =
                           message.Documents.Where(x => !string.IsNullOrWhiteSpace(x.ParentDocumentId))
                           .Select(x => new DraftMessageRelation { DocumentId = x.ParentDocumentId })
                           .ToArray()
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
                           .ToArray()
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
                           .ToArray()
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
                SendMode = DraftMessageSendMode.Internal
            };
        }

        private void GetDocumentFlow()
        {
            var documentId = UserInput.ReadParameter("Id документа");
            var flowDocumentInfo = _context.ServiceClient.GetFlowDocumentInfo(_context.CurrentBox, documentId);
            if (flowDocumentInfo == null)
            {
                UserInput.Error("Неправильный идентификатор документа");
                return;
            }

            Console.Out.Write("Загружен ");
            PrintDocumentFlow(flowDocumentInfo);
            SaveDocumentFlow(flowDocumentInfo);
        }

        private void PrintDocumentFlowArchive(NamedContent flowArchive)
        {
            Console.Out.WriteLine("Архив документооборота: \n {0}\n {1} байт", flowArchive.Name,
                flowArchive.Content.Length);
        }

        private void SaveDocumentFlowArchive(NamedContent flowArchive)
        {
            if (!UserInput.ChooseYesNo("Сохранить архив документооборота?"))
                return;

            var directoryPath = ChooseDirectory();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            Console.Out.WriteLine("Сохранение архива '{0}'", flowArchive.Name);
            FileHelper.WriteAllBytes(directoryPath, flowArchive.Name, flowArchive.Content);
        }

        private void DownloadDocumentFlowArchive()
        {
            var documentId = UserInput.ReadParameter("Id документа");
            var documentFlowArchive = _context.ServiceClient.DownloadDocumentFlowArchive(_context.CurrentBox, documentId);
            if (documentFlowArchive == null)
            {
                UserInput.Error("Неправильный идентификатор документа");
                return;
            }

            Console.Out.Write("Получен архив документооборота ");
            PrintDocumentFlowArchive(documentFlowArchive);
            SaveDocumentFlowArchive(documentFlowArchive);
        }

        private void GetDocumentInfo()
        {
            var documentId = UserInput.ReadParameter("Id документа");
            var fullDocumentInfo = _context.ServiceClient.GetFullDocumentInfo(_context.CurrentBox, documentId);
            if (fullDocumentInfo == null)
            {
                UserInput.Error("Неправильный идентификатор документа");
                return;
            }

            Console.Out.Write("Загружен ");
            PrintDocumentInfo(fullDocumentInfo);
            SaveDocumentInfo(fullDocumentInfo);
        }

        private EnumValue GetDocumentExecutedFunction(DocumentType documentType, string documentId)
        {
            var executedFunction = documentType.IsGeneralTransfer()
                ? _context.ServiceClient.GetDocumentExecutedFunction(_context.CurrentBox, documentId)
                : null;
            return executedFunction;
        }

        private void GetDocumentList()
        {
#pragma warning disable 618 //Отключить предупреждения насчет устаревших полей (obsolete)

            var incoming = UserInput.ChooseYesNo("Входящие");
            var documentListOptions =
                new DocumentListOptions
                {
                    BoxTo = incoming ? _context.CurrentBox : null,
                    BoxFrom = !incoming ? _context.CurrentBox : null,
                    First = 0,
                    Max = 10
                };

            if (UserInput.ChooseYesNo("Указать параметры фильтрации", false))
                FillDocumentListOptions(documentListOptions);

            var documentList = _context.ServiceClient.GetDocumentList(documentListOptions);
            Console.Out.WriteLine("Всего документов {0}", documentList.Total);

            while (true)
            {
                Console.Out.WriteLine("Документы с " +
                                      (documentListOptions.First + 1) + " по " +
                                      Math.Min(documentListOptions.First + documentListOptions.Max, documentList.Total));

                foreach (var documentListEntry in documentList.Items)
                {
                    var documentType = (DocumentType)documentListEntry.DocumentTypeEnum.Code;
                    var executedFunction = GetDocumentExecutedFunction(documentType, documentListEntry.Id);
                    var executedFunctionText = executedFunction != null
                        ? $" ({executedFunction.Name})"
                        : String.Empty;
                    Console.Out.WriteLine("{0, -60} {1, -20} {2, -20} {3, -20} {4, -20} {5}",
                        documentListEntry.Name,
                        incoming
                            ? documentListEntry.FromOrganizationName
                            : documentListEntry.ToOrganizationName,
                        documentType + executedFunctionText,
                        GetStatusText(documentListEntry.MessageFrom, documentListEntry.Status,
                            documentListEntry.DocumentFlowStatusDescription),
                        documentListEntry.Id,
                        documentListEntry.SentDate);
                }

                if (documentListOptions.First + documentListOptions.Max > documentList.Total)
                    break;
                if (!UserInput.ChooseYesNo("Далее"))
                    break;

                documentListOptions.First += documentListOptions.Max;
                documentList = _context.ServiceClient.GetDocumentList(documentListOptions);
            }
        }

        private void GetDocumentEntries()
        {
            var incoming = UserInput.ChooseYesNo("Входящие");
            var documentEntryOptions = new DocumentEntryOptions
            {
                BoxTo = incoming ? _context.CurrentBox : null,
                BoxFrom = !incoming ? _context.CurrentBox : null,
                First = 0,
                Max = 10
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

                FillDocumentListOptions(documentEntryOptions);
            }

            var documentEntries = _context.ServiceClient.GetDocumentEntries(documentEntryOptions);
            Console.Out.WriteLine("Всего вхождений документов {0}", documentEntries.Total);

            while (true)
            {
                Console.Out.WriteLine("Вхождения документов с " +
                                      (documentEntryOptions.First + 1) + " по " +
                                      Math.Min(documentEntryOptions.First + documentEntryOptions.Max,
                                          documentEntries.Total));

                foreach (var documentEntryItem in documentEntries.Items)
                {
                    var documentType = (DocumentType)documentEntryItem.DocumentTypeEnum.Code;
                    var executedFunction = GetDocumentExecutedFunction(documentType, documentEntryItem.DocumentId);
                    var executedFunctionText = executedFunction != null
                        ? $" ({executedFunction.Name})"
                        : String.Empty;
                    Console.Out.WriteLine("{0, -60} {1, -20} {2, -20} {3, -20} {4, -20} {5, -20} {6, -20} {7}",
                        documentEntryItem.Name,
                        documentEntryItem.FromOrganizationName,
                        documentEntryItem.FromDepartmentName,
                        documentEntryItem.DocumentId,
                        documentType + executedFunctionText,
                        documentEntryItem.FlowType,
                        GetStatusText(documentEntryItem.MessageFrom, documentEntryItem.Status,
                            documentEntryItem.DocumentFlowStatusDescription),
                        documentEntryItem.SentDate);
                }

                if (documentEntryOptions.First + documentEntryOptions.Max > documentEntries.Total)
                    break;
                if (!UserInput.ChooseYesNo("Далее"))
                    break;

                documentEntryOptions.First += documentEntryOptions.Max;
                documentEntries = _context.ServiceClient.GetDocumentEntries(documentEntryOptions);
            }
        }

        private void FillDocumentListOptions(DocumentListOptions documentListOptions)
        {
            if (UserInput.ChooseYesNo("Фильтровать по контрагентам?", false))
            {
                var contragentBoxes = new List<string>();
                do
                {
                    var contragentBox = ChooseContragentBox();
                    if (!string.IsNullOrWhiteSpace(contragentBox))
                    {
                        contragentBoxes.Add(contragentBox);
                        if (!UserInput.ChooseYesNo("Добавить еще одного контрагента?"))
                            break;
                    }
                } while (true);
                documentListOptions.ContragentBoxIds = contragentBoxes.ToArray();
            }

            if (UserInput.ChooseYesNo("Фильтровать по типам документов?", false))
            {
                var documentTypes = new List<DocumentType>();
                if (UserInput.ChooseYesNo("Неформализованный"))
                    documentTypes.Add(DocumentType.Untyped);
                if (UserInput.ChooseYesNo("Электронный счет-фактура"))
                    documentTypes.Add(DocumentType.Invoice);
                if (UserInput.ChooseYesNo("Товарная накладная (титул продавца)"))
                    documentTypes.Add(DocumentType.WaybillSeller);
                if (UserInput.ChooseYesNo("Акт о выполнении работ (титул исполнителя)"))
                    documentTypes.Add(DocumentType.ActOfWorkSeller);
                if (UserInput.ChooseYesNo("Исправленный счет-фактура"))
                    documentTypes.Add(DocumentType.InvoiceRevision);
                if (UserInput.ChooseYesNo("Корректировочный счет-фактура"))
                    documentTypes.Add(DocumentType.InvoiceCorrection);
                if (UserInput.ChooseYesNo("Исправленный корректировочный счет-фактура"))
                    documentTypes.Add(DocumentType.InvoiceCorrectionRevision);
                if (UserInput.ChooseYesNo("Соглашение об аннулировании"))
                    documentTypes.Add(DocumentType.RevocationOffer);
                if (UserInput.ChooseYesNo("Документ о передаче результатов работ"))
                    documentTypes.Add(DocumentType.WorksTransferSeller);
                if (UserInput.ChooseYesNo("Исправленный документ о передаче результатов работ"))
                    documentTypes.Add(DocumentType.WorksTransferRevisionSeller);
                if (UserInput.ChooseYesNo("Документ о передаче товаров"))
                    documentTypes.Add(DocumentType.GoodsTransferSeller);
                if (UserInput.ChooseYesNo("Исправленный документ о передаче товаров"))
                    documentTypes.Add(DocumentType.GoodsTransferRevisionSeller);
                if (UserInput.ChooseYesNo("Универсальный передаточный документ"))
                    documentTypes.Add(DocumentType.GeneralTransferSeller);
                if (UserInput.ChooseYesNo("Исправленный универсальный передаточный документ"))
                    documentTypes.Add(DocumentType.GeneralTransferRevisionSeller);
                if (UserInput.ChooseYesNo("Универсальный корректировочный документ"))
                    documentTypes.Add(DocumentType.GeneralTransferCorrectionSeller);
                if (UserInput.ChooseYesNo("Исправленный универсальный корректировочный документ"))
                    documentTypes.Add(DocumentType.GeneralTransferCorrectionRevisionSeller);
                documentListOptions.DocumentTypes = documentTypes.ToArray();
            }

            if (UserInput.ChooseYesNo("Фильтровать по статусам подписания?", false))
            {
                var signStatuses = new List<DocumentSignStatus>();
                if (UserInput.ChooseYesNo("Подпись не требуется"))
                    signStatuses.Add(DocumentSignStatus.NoSignNeeded);
                if (UserInput.ChooseYesNo("Подписан"))
                    signStatuses.Add(DocumentSignStatus.Signed);
                if (UserInput.ChooseYesNo("Отказано (запрошено уточнение)"))
                    signStatuses.Add(DocumentSignStatus.SignRejected);
                if (UserInput.ChooseYesNo("Требуется подпись"))
                    signStatuses.Add(DocumentSignStatus.WaitingForSign);
                documentListOptions.DocumentSignStatuses = signStatuses.ToArray();
            }

            if (UserInput.ChooseYesNo("Фильтровать по статусам счетов-фактур?", false))
            {
                var invoiceStatuses = new List<InvoiceFlowStatus>();
                if (UserInput.ChooseYesNo("Отправлен"))
                    invoiceStatuses.Add(InvoiceFlowStatus.InvoiceSent);
                if (UserInput.ChooseYesNo("Выставлен"))
                    invoiceStatuses.Add(InvoiceFlowStatus.InvoiceCharged);
                if (UserInput.ChooseYesNo("Выставлен. Запрошено уточнение"))
                    invoiceStatuses.Add(InvoiceFlowStatus.InvoiceRejected);
                if (UserInput.ChooseYesNo("Нарушен регламент"))
                    invoiceStatuses.Add(InvoiceFlowStatus.InvoiceNotValid);
                documentListOptions.InvoiceFlowStatuses = invoiceStatuses.ToArray();
            }

            if (UserInput.ChooseYesNo("Фильтровать по статусу требования подтверждения получения?", false))
            {
                documentListOptions.NeedReceipt =
                    (bool?)UserInput.ChooseOption("Требуется подтверждение получения?",
                        new[]
                        {
                            new UserInput.Option("1", "Да", true, true),
                            new UserInput.Option("2", "Нет ", true, false),
                            new UserInput.Option("3", "Оба варианта", true, null)
                        }).Data;
            }

            if (UserInput.ChooseYesNo("Фильтровать по статусам аннулирования?", false))
            {
                var revocationStatuses = new List<DocumentRevocationStatus>();
                foreach (var revocationStatus in Enum
                    .GetValues(typeof(DocumentRevocationStatus))
                    .Cast<DocumentRevocationStatus>())
                    if (UserInput.ChooseYesNo(EnumHelper.GetDescription(revocationStatus)))
                        revocationStatuses.Add(revocationStatus);
                documentListOptions.DocumentRevocationStatuses = revocationStatuses.ToArray();
            }

            if (UserInput.ChooseYesNo("Указать период отправки", false))
            {
                documentListOptions.From = ChooseDate(true);
                documentListOptions.To = ChooseDate(false);
            }
        }

        /// <summary>
        /// Обработка консольной команды:
        /// получение и отображение списка внутренних документов.
        /// </summary>
        private void GetInternalDocuments()
        {
            var internalListOptions = new InternalListOptions
            {
                BoxId = _context.CurrentBox,
                First = 0,
                Max = 10
            };

            if (UserInput.ChooseYesNo("Указать параметры фильтрации", false))
            {
                var excludeUnavailable =
                    UserInput.ChooseYesNo("Исключить из списка документы, подписание/отказ по которым недоступны", false);
                internalListOptions.ExcludeUnavailable = excludeUnavailable;

                var currentOrganizationId = _context.CurrentOrganizationId.ToString(CultureInfo.InvariantCulture);
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
                            var recipientUser = ChooseUser(recipientDepartment.Id);
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
                    internalListOptions.From = ChooseDate(true);
                    internalListOptions.To = ChooseDate(false);
                }
            }

            var internalDocuments = _context.ServiceClient.GetInternalDocuments(internalListOptions);
            Console.Out.WriteLine("Всего внутренних документов {0}", internalDocuments.Total);

            while (true)
            {
                Console.Out.WriteLine("Внутренние документов с "
                                      + (internalListOptions.First + 1) + " по "
                                      +
                                      Math.Min(internalListOptions.First + internalListOptions.Max,
                                          internalDocuments.Total));

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
                internalDocuments = _context.ServiceClient.GetInternalDocuments(internalListOptions);
            }
        }

        /// <summary>
        /// Получение текстового предстваления для статуса документооборота.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="status">>статус документооборота.</param>
        /// <param name="statusDescription"></param>
        /// <returns></returns>
        private string GetStatusText(string from, DocumentFlowStatus status,
            DocumentFlowStatusDescription statusDescription)
        {
            if (statusDescription != null)
                return GetStatusText(statusDescription);

            var invoiceDocumentFlowStatus = status as InvoiceDocumentFlowStatus;
            if (invoiceDocumentFlowStatus != null)
                return _context.CurrentBox == from
                    ? invoiceDocumentFlowStatus.SellerFlow.ToString()
                    : invoiceDocumentFlowStatus.BuyerFlow.ToString();

            var untypedDocumentFlowStatus = status as UntypedDocumentFlowStatus;
            if (untypedDocumentFlowStatus != null)
                return untypedDocumentFlowStatus.SignStatus.ToString();

            return "(null)";
        }

        /// <summary>
        /// Получение текстового предстваления для статуса документооборота.
        /// </summary>
        /// <param name="statusDescription">статус документооборота.</param>
        /// <returns></returns>
        private string GetStatusText(DocumentFlowStatusDescription statusDescription)
        {
            if (statusDescription != null)
            {
                var status = string.Format("Статус: {0}", statusDescription.Status);
                return string.IsNullOrWhiteSpace(statusDescription.AdditionalStatus)
                    ? status
                    : string.Format("{0}. Доп.статусы: {1}", status, statusDescription.AdditionalStatus);
            }
            return "(null)";
        }

        /// <summary>
        /// Получить список черновиков.
        /// </summary>
        private void GetDraftMessageList()
        {
            var settings = new FetchingSettings
            {
                Sorting = null, // Сортировка по умолчанию
                Paging = new PageSettings
                {
                    First = 0,
                    PageSize = 10
                }
            };

            ShowDraftMessageSearchResult(
                () => _context.ServiceClient.GetDraftMessageList(settings, _context.CurrentBox),
                settings.Paging);
        }

        /// <summary>
        /// Отобразить результат поиска черновиков с постраничной паджинацией.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="pageSettings"></param>
        /// <returns></returns>
        private DraftMessageSearchResult ShowDraftMessageSearchResult(Func<DraftMessageSearchResult> func,
            PageSettings pageSettings)
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
        /// Получить черновик.
        /// </summary>
        private void GetDraftMessage()
        {
            var draftMessageId = UserInput.ReadParameter("Id черновика сообщения");

            DraftMessage draftMessage;
            try
            {
                draftMessage = _context.ServiceClient.GetDraftMessage(draftMessageId, true, true);
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
        /// Удалить черновик.
        /// </summary>
        private void DeleteDraftMessage()
        {
            var draftMessageId = UserInput.ReadParameter("Id черновика сообщения");
            try
            {
                _context.ServiceClient.DeleteDraftMessage(draftMessageId);
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

            UserInput.Success(string.Format("Черновик {0} удален", draftMessageId));
        }

        /// <summary>
        /// Передать черновик.
        /// </summary>
        private void MoveDraftMessage()
        {
            var draftMessageId = UserInput.ReadParameter("Внешний Id черновика сообщения");
            var employeeId = UserInput.ReadParameter("Внешний Id сотрудника");
            try
            {
                _context.ServiceClient.MoveDraftMessage(_context.CurrentBox, draftMessageId, employeeId);
            }
            catch (ServerException ex)
            {
                UserInput.Error(ex.Message);
                return;
            }

            UserInput.Success($"Черновик {draftMessageId} успешно перемещен");
        }

        /// <summary>
        /// Добавить документ к неотправленному сообщению.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        /// <param name="sign">Подпись в формате CMS.</param>
        private Message AddDocumentToNewMessage(Message message, Document document, ISignature signature)
        {
            return MessageFactory.AddDocumentWithSignature(message, document, signature);
        }

        /// <summary>
        /// Выбрать сертификат из списка установленных и установить его текущим в клиентском контексте.
        /// </summary>
        private void ChooseAndSetContextCertificate()
        {
            var certificate = ChooseCertificateFromCertificateStores(excludeRegisteredCertificates: false); 
            _context.Certificate = certificate;
            Console.Out.WriteLine("Выбран сертификат {0}", certificate.Subject);
        }

        /// <summary>
        /// Выбрать дату.
        /// </summary>
        /// <param name="from">Начало?</param>
        /// <returns>Выбранная дата.</returns>
        private DateTime? ChooseDate(bool from)
        {
            do
            {
                var dateText = UserInput.ReadParameter(string.Format(
                    "Укажите дату {0} периода в формате ДД.ММ.ГГГГ (или пустую строку, чтобы не указывать дату)",
                    from ? "начала" : "завершения"));
                if (string.IsNullOrEmpty(dateText))
                    return null;
                DateTime dateValue;
                if (DateTime.TryParse(dateText, out dateValue))
                    return dateValue;

                UserInput.Error("Дата указана некорректно. Повторите ввод.");
            } while (true);
        }

        /// <summary>
        /// Загрузка и обработка входящих сообщений.
        /// </summary>
        private void LoadMessages()
        {
            // загружаем входящие сообщения в цикле по 100 шт маскимум
            MessageInfo[] messages;
            var count = 0;
            do
            {
                messages = _context.ServiceClient.GetMessages(_context.LastProcessedMessageId, null, _context.CurrentBox);

                foreach (var messageInfo in messages)
                {
                    UserInput.Separator();
                    var message = _context.ServiceClient.GetMessage(_context.CurrentBox, messageInfo.Id);

                    Console.Out.WriteLine("Обрабатывается сообщение");

                    PrintMessageProperties(messageInfo, message);
                    ProcessMessage(message, _context);
                    _context.LastProcessedMessageId = message.Id;
                    _context.SaveLastProcessedMessageId();
                }

                count += messages.Length;
            } while (messages.Length > 0);

            Console.Out.WriteLine("Загружено {0} сообщений из ящика {1}", count, _context.CurrentBox);
        }

        /// <summary>
        /// Вывести информацию об обрабатываемом сообщении.
        /// </summary>
        /// <param name="messageInfo">Информация о сообщении.</param>
        /// <param name="message">Сообщение.</param>
        private void PrintMessageProperties(MessageInfo messageInfo, Message message)
        {
            var organization = _context.ServiceClient.GetOrganizationBy(_context.CurrentBox,
                        OrganizationByCriteria.ByBoxAddress,
                        new OrganizationByCriteriaValues { BoxAddress = messageInfo.From });
            var department =
                _context.ServiceClient.GetOrganizationStructure(_context.CurrentBox, organization.OrganizationId)
                    .First(d => d.Id == message.FromDepartment);

            PrintProperty("Id", messageInfo.Id);
            PrintProperty("From", messageInfo.From);
            PrintProperty("FromDepartment", department.Name);
            PrintProperty("Дата", message.SentDate);
            PrintProperty("Документы", message.Documents.Length);
            PrintProperty("Усиленные подписи", message.Signs.Length);
            PrintProperty("Простые подписи", message.SimpleSignatures.Length);
        }

        /// <summary>
        /// Загрузка входящих сообщений без содержимого документов и подписей.
        /// </summary>
        private void GetMessagesWithoutDocumentsSignsContent()
        {
            MessageInfo[] messages;
            var count = 0;
            string lastMessageId = null;
            do
            {
                messages = _context.ServiceClient.GetMessages(lastMessageId, null, _context.CurrentBox);

                foreach (var messageInfo in messages)
                {
                    UserInput.Separator();

                    var messageRequestParam = new MessageRequestParams()
                    {
                        GetDocumentContent = false,
                        GetSignContent = false
                    };

                    var message = _context.ServiceClient.GetMessageWithLoadOptions(_context.CurrentBox, messageInfo.Id,
                        messageRequestParam);

                    PrintMessageProperties(messageInfo, message);
                    lastMessageId = message.Id;
                }

                count += messages.Length;
            } while (messages.Length > 0);

            Console.Out.WriteLine("Загружено {0} сообщений из ящика {1}", count, _context.CurrentBox);
        }

        private static void PrintProperty(string propertyName, object value)
        {
            Console.Out.WriteLine("\t{0,-15}{1}", string.Format("{0}:", propertyName), value);
        }

        /// <summary>
        /// Обработка входящего сообщения.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ctx"></param>
        /// <returns><c>true</c>, если сообщение было успешно обработано, иначе <c>false</c>.</returns>
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
                var strongSignaturesFromRecipient =
                    message.Signs.Where(s => message.Documents.All(d => d.Id != s.DocumentId)).ToList();
                foreach (var signature in strongSignaturesFromRecipient)
                    if (string.IsNullOrEmpty(signature.ParentId))
                    {
                        documentId = signature.DocumentId;
                        ProcessSign(signature);
                    }

                var simpleSignaturesFromRecipient =
                    message.SimpleSignatures.Where(s => message.Documents.All(d => d.Id != s.DocumentId)).ToList();
                foreach (var signature in simpleSignaturesFromRecipient)
                {
                    documentId = signature.DocumentId;
                    ProcessSign(signature);
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
                        "Нет доступа к документу {0}. Загрузка сообщения {1} пропущена.",
                        documentId,
                        message.Id);
                    return false;
                }
                throw;
            }
        }

        private void ProcessSign(Sign signature)
        {
            UserInput.Separator();

            var documentInfo = _context.ServiceClient.GetFullDocumentInfo(_context.CurrentBox, signature.DocumentId);
            Console.Out.WriteLine("Обрабатывается подпись на документ {0}", DocumentShortName(documentInfo));
            var certificate = CheckSignAndGetCertificate(documentInfo, signature);
            if (certificate != null)
            {
                UserInput.Success("Подпись корректна, контрагент подписал документ {0}",
                    certificate.GetNameInfo(X509NameType.SimpleName, false));
            }
        }

        private void ProcessSign(SimpleSignature signature)
        {
            UserInput.Separator();

            var documentInfo = _context.ServiceClient.GetFullDocumentInfo(_context.CurrentBox, signature.DocumentId);
            Console.Out.WriteLine("Обрабатывается подпись на документ {0}", DocumentShortName(documentInfo));

            var document = documentInfo.Document;
            if (document.NeedReceipt && IsNoticeRequired(documentInfo))
            {
                UserInput.Warning("Не удалось проверить подпись документа т.к. на него запрошено УОП");
                return;
            }

            if (signature.IsValid)
            {
                UserInput.Success("Подпись корректна, контрагент подписал документ {0}", DocumentShortName(documentInfo));
            }
            else
            {
                UserInput.Error("Подпись на документ {0} недействительна", document.Id);
                return;
            }
        }

        /// <summary>
        /// Обработка входящего документа.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="document"></param>
        private void ProcessIncomingDocument(Message message, Document document)
        {
            // в зависимости от типа документа показывать атрибуты
            // для СФ это карточка, статус, подпись, имя файла
            // для СД это тип (по типу разное отображение), подпись, к какому документу относится
            // для НД название, подпись, ожидается ли подпись
            var documentInfo = _context.ServiceClient.GetFullDocumentInfo(_context.CurrentBox, document.Id);
            var documentType = (DocumentType)documentInfo.Document.DocumentTypeEnum.Code;
            UserInput.Separator();
            Console.Out.Write("Обрабатывается ");
            PrintDocumentInfo(documentInfo);

            // НД
            if (documentType == DocumentType.Untyped)
                ProcessUntypedDocument(message, documentInfo);

            // НД: ИОП
            else if (documentType == DocumentType.ServiceReceipt)
                ProcessDeliveryConfirmation(document);

            // НД: УОУ
            else if (documentType == DocumentType.ServiceAmendmentRequest)
                ProcessRejectSign(document);

            // СФ
            else if (documentType.IsInvoice())
                ProcessInvoice(message, documentInfo);

            // СФ: подтверждение о дате отправки/приема 
            else if (documentType == DocumentType.ServiceInvoiceConfirmation)
                ProcessServiceInvoiceConfirmation(message, documentInfo);

            // СФ: УОУ
            else if (documentType == DocumentType.ServiceInvoiceAmendmentRequest)
                ProcessServiceInvoiceAmendmentRequest(message, documentInfo);

            // ТН / АКТ / ДПТ / ДПРР / УПД / УКД / ЭТН: корневой титул.
            else if (documentType.IsRootTitle())
                ProcessRootTitle(message, documentInfo);

            // ТН / АКТ / ДПТ / ДПРР / УПД / УКД / ЭТН: ответный титул.
            else if (documentType.IsReplyTitle())
                ProcessReplyTitle(document);

            // Предложение об аннулировании
            else if (documentType == DocumentType.RevocationOffer)
                ProcessRevocationOffer(message, documentInfo);

            // TODO сделать методы автоматической генерации служебных документов в SDK
        }

        private void PrintDocumentInfo(FullDocumentInfo fullDocumentInfo)
        {
            var document = fullDocumentInfo.Document;
            var documentType = (DocumentType)document.DocumentTypeEnum.Code;
            Console.Out.WriteLine(DocumentShortName(fullDocumentInfo));
            PrintProperty("Id", document.Id);
            PrintProperty("Тип", documentType);

            if (fullDocumentInfo.Status != null)
            {
                if (documentType.In(DocumentType.Untyped,
                    DocumentType.WaybillSeller,
                    DocumentType.ActOfWorkSeller,
                    DocumentType.RevocationOffer))
                {
                    PrintProperty("Подписание", ((UntypedDocumentFlowStatus)fullDocumentInfo.Status).SignStatus);
                }
                else if (documentType == DocumentType.Invoice)
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

            if (fullDocumentInfo.Tags != null && fullDocumentInfo.Tags.Any())
            {
                PrintProperty("Дополнительные статусы(тэги), кол-во", fullDocumentInfo.Tags.Count());
                foreach (var tag in fullDocumentInfo.Tags)
                {
                    PrintProperty("Логин пользователя, создавшего тэг", tag.Login);
                    PrintProperty("Тип тэга", tag.TagType);
                    PrintProperty("Комментарий", tag.Comment);
                    PrintProperty("Дата создания", tag.CreateDate);
                }
            }

            if (fullDocumentInfo.Signs != null)
                foreach (var signature in fullDocumentInfo.Signs)
                {
                    var certificate = CheckSignAndGetCertificate(fullDocumentInfo, signature);
                    if (certificate == null)
                        continue;

                    PrintProperty("Усиленная ЭП", certificate.GetNameInfo(X509NameType.SimpleName, false));
                    PrintProperty("Штамп времени", signature.TimeStamp != DateTime.MinValue
                        ? signature.TimeStamp
                        : (object)"отсутствует");
                }

            if (fullDocumentInfo.SimpleSignatures != null)
                foreach (var signature in fullDocumentInfo.SimpleSignatures)
                {
                    PrintProperty("Простая ЭП", GetSignatureSubject(signature));
                    PrintProperty("Подписан в", signature.SignedAt);
                }

            PrintProperty("Имя файла", document.FileName);
            PrintProperty("Размер", document.FileSize);

            if (documentType.In(DocumentType.Invoice,
                DocumentType.Untyped,
                DocumentType.WaybillSeller,
                DocumentType.ActOfWorkSeller,
                DocumentType.RevocationOffer))
            {
                if (fullDocumentInfo.ServiceDocuments != null)
                {
                    Console.Out.WriteLine("\tСлужeбные документы {0} шт.", fullDocumentInfo.ServiceDocuments.Length);
                    foreach (var serviceDocument in fullDocumentInfo.ServiceDocuments)
                        Console.Out.WriteLine("\t\t{0} {1}",
                            serviceDocument.FileName,
                            (DocumentType)serviceDocument.DocumentTypeEnum.Code);
                }
                if (fullDocumentInfo.RelatedDocuments != null)
                {
                    Console.Out.WriteLine("\tСвязные документы {0} шт.", fullDocumentInfo.RelatedDocuments.Length);
                    foreach (var relatedDocument in fullDocumentInfo.RelatedDocuments)
                        Console.Out.WriteLine("\t\t{0} {1}",
                            relatedDocument.FileName,
                            (DocumentType)relatedDocument.DocumentTypeEnum.Code);
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
                    Console.Out.WriteLine("\t\t{0} {1} {2} {3}", entry.FlowType,
                        GetStatusText(entry.DocumentFlowStatusDescription), entry.SentDate, entry.Comment);
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
                    Console.Out.WriteLine("\t\t{0} {1} {2} {3}", flow.FlowType, flow.RecipientStatus, flow.FlowDate,
                        flow.Comment);
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
            FileHelper.WriteAllBytes(directoryPath, fullDocumentInfo.Document.FileName,
                GetDocumentContent(fullDocumentInfo.Document));

            // сохраняем карточку, если есть
            if (fullDocumentInfo.Document.Card != null)
            {
                var cardFileName = Path.GetFileNameWithoutExtension(fullDocumentInfo.Document.FileName) + ".card.xml";
                Console.Out.WriteLine("Сохранение карточки документа '{0}'", cardFileName);
                FileHelper.WriteAllBytes(directoryPath, cardFileName, fullDocumentInfo.Document.Card);
            }

            // аггрегируем все подписи
            var signatures = (fullDocumentInfo.Signs ?? Enumerable.Empty<ISignature>())
                .Concat(fullDocumentInfo.SimpleSignatures ?? Enumerable.Empty<ISignature>())
                .ToList();

            // сохраняем подписи, если есть
            foreach (var signature in signatures)
            {
                var signatureFileName = GetSignatureFileName(signature);
                Console.Out.WriteLine("Сохранение подписи '{0}'", signatureFileName);
                FileHelper.WriteAllBytes(directoryPath, signatureFileName, signature.Raw);
            }

            // требуется ли получать усовершенствованные подписи
            if (fullDocumentInfo.Signs?.Any() != true || !UserInput.ChooseYesNo("Получить усовершенствованные подписи?"))
                return;

            // получение усовершенствованных подписей
            foreach (var signature in fullDocumentInfo.Signs)
            {
                var signatureFileName = GetSignatureFileName(signature);
                Console.Out.WriteLine("Получение усовершенствованной подписи для '{0}'", signatureFileName);
                EnhancedSign enhancedSign;
                try
                {
                    enhancedSign = _context.ServiceClient.GetEnhancedSignById(_context.CurrentBox, signature.Id);
                }
                catch (Exception exc)
                {
                    Console.Error.WriteLine(exc.Message);
                    continue;
                }
                if (enhancedSign.CreateStatus == EnhancedSignCreateStatus.Failed)
                    Console.Out.WriteLine(
                        "Не удалось создать усовершенствованную подпись для {0}: {1}",
                        signatureFileName, enhancedSign.FailedInfo.Message);
                else if (enhancedSign.CreateStatus == EnhancedSignCreateStatus.InProgress)
                    Console.Out.WriteLine(
                        "Усовершенствованная подпись для {0} еще не создана, запросите еще раз {1}",
                        signatureFileName, enhancedSign.CreateTime.ToString("dd.MM.yyyy hh:mm:ss UTC"));
                else
                {
                    var enhancedSignFileName = GetSignatureSubject(signature) + ".enhanced.sig";
                    Console.Out.WriteLine("Сохранение усовершенствованной подписи '{0}'", enhancedSignFileName);
                    FileHelper.WriteAllBytes(directoryPath, enhancedSignFileName, enhancedSign.Raw);
                }
            }

            // TODO сохранить служебные документы и подписи к ним
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
                if (UserInput.ChooseYesNo("Отправить извещение о получении УОУ?"))
                {
                    Console.Out.WriteLine("Генерируются извещения о получении УОУ");
                    var noticeMessage = _context.MessageFactory.CreateInvoiceReceipt(message, document, ChooseSignature);
                    SendServiceDocument(noticeMessage, "Отправлено извещение о получении УОУ");
                }
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
                if (UserInput.ChooseYesNo("Отправить извещение о получении подтверждения?"))
                {
                    Console.Out.WriteLine("Генерируются извещения о получении подтверждения");
                    var noticeMessage = _context.MessageFactory.CreateInvoiceReceipt(message, document, ChooseSignature);
                    SendServiceDocument(noticeMessage, "Отправлено извещение о получении подтверждения");
                }
            }
            else
            {
                UserInput.Information("Извещение о получении подтверждения уже было отправлено");
            }
        }

        private void ProcessRejectSign(Document document)
        {
            var documentInfo = _context.ServiceClient.GetFullDocumentInfo(_context.CurrentBox, document.ParentDocumentId);
            Console.Out.WriteLine("Отказано в подписи под документом {0}", DocumentShortName(documentInfo));
        }

        private void ProcessDeliveryConfirmation(Document document)
        {
            var documentInfo = _context.ServiceClient.GetFullDocumentInfo(_context.CurrentBox, document.ParentDocumentId);
            Console.Out.WriteLine("Документ {0} дошел до получателя", DocumentShortName(documentInfo));
        }

        private void ProcessReplyTitle(Document document)
        {
            var documentInfo = _context.ServiceClient.GetFullDocumentInfo(_context.CurrentBox, document.ParentDocumentId);
            Console.Out.WriteLine("Документ {0} подписан", DocumentShortName(documentInfo));
        }

        private void EnsureDocumentContentLoaded(Document document)
        {
            if (document.Content == null)
                GetDocumentContent(document);
        }

        private byte[] GetDocumentContent(Document document)
        {
            return document.Content ??
                   (document.Content = _context.ServiceClient.GetDocumentContent(_context.CurrentBox, document.Id));
        }

        private X509Certificate2 CheckSignAndGetCertificate(FullDocumentInfo documentInfo, Sign sign)
        {
            var document = documentInfo.Document;
            if (document.NeedReceipt && IsNoticeRequired(documentInfo))
            {
                UserInput.Warning("Не удалось проверить подпись документа т.к. на него запрошено УОП");
                return null;
            }
            var contentInfo = new ContentInfo(GetDocumentContent(document));
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
            var certificate = signedCms.Certificates[0];
            return certificate;
        }

        /// <summary>
        /// Требуется ли ИОП документа?
        /// </summary>
        /// <param name="documentInfo">Полная информация о документе.</param>
        /// <returns><c>true</c>, если ИОП требуется; иначе - <c>false</c>.</returns>
        private bool IsNoticeRequired(FullDocumentInfo documentInfo)
        {
            var untypedFlowStatus = documentInfo.Status as UntypedDocumentFlowStatus;
            return untypedFlowStatus != null
                ? untypedFlowStatus.DeliveryStatus != DocumentDeliveryStatus.DeliveredToRecipient
                : documentInfo.Document.NoticeRequired;
        }

        /// <summary>
        /// Проверить, требуется ли подписание документа.
        /// </summary>
        /// <param name="documentInfo">Полная информация о документе.</param>
        /// <returns><c>true</c>, если подписание требуется; иначе - <c>false</c>.</returns>
        private bool IsSignatureRequired(FullDocumentInfo documentInfo)
        {
            var documentType = (DocumentType)documentInfo.Document.DocumentTypeEnum.Code;
            if (documentType.IsTransportWaybillConsignorTitle())
                // TODO: Vasilev_IY: features/transport-waybill-formalized:
                // Актуализировать после добавления операций.
                return true;

            if (documentInfo.Status is UntypedDocumentFlowStatus untypedFlowStatus)
                return untypedFlowStatus.SignStatus == DocumentSignStatus.WaitingForSign;

            if (documentType.IsGeneralTransferSeller())
                return !documentInfo.ServiceDocuments.Any(serviceDocument =>
                {
                    var serviceDocumentType = (DocumentType)serviceDocument.DocumentTypeEnum.Code;
                    return serviceDocumentType.IsGeneralTransferBuyer()
                        || serviceDocumentType == DocumentType.ServiceInvoiceAmendmentRequest;
                });

            return false;
        }

        /// <summary>
        /// Выполнить обработку входящего СФ/КСФ.
        /// </summary>
        /// <param name="message">Сообщение с документом.</param>
        /// <param name="documentInfo">Полная информация о документе.</param>
        private void ProcessInvoice(Message message, FullDocumentInfo documentInfo)
        {
            var document = documentInfo.Document;
            if (document.NoticeRequired)
            {
                if (UserInput.ChooseYesNo("Отправить извещение о получении счета-фактуры?"))
                {
                    Console.Out.WriteLine("Генерируются извещения о получении счета-фактуры");
                    var noticeMessage = _context.MessageFactory.CreateInvoiceReceipt(message, document, ChooseSignature);
                    SendServiceDocument(noticeMessage, "Отправлено извещение о получении счета-фактуры отправлено");
                }
            }
            else
            {
                UserInput.Information("Извещение о получении счета-фактуры уже было отправлено");
            }

            if (((InvoiceDocumentFlowStatus)documentInfo.Status).BuyerFlow == InvoiceFlowStatus.InvoiceRejected)
            {
                UserInput.Information("Уведомление об уточнении счета-фактуры уже было отправлено");
            }
            else if (UserInput.ChooseYesNo("Запросить уточнение на счет-фактуру?"))
            {
                var text = UserInput.ReadParameter("Текст уточнения", string.Empty);
                var invoiceAmendmentRequestMessage = _context.MessageFactory.CreateInvoiceAmendmentRequest(
                    message, document, text, ChooseSignature);
                SendServiceDocument(invoiceAmendmentRequestMessage, "Отправлено уведомление об уточнении счета-фактуры");
            }
        }

        /// <summary>
        /// Выполнить обработку требуемого ИОП входящего документа.
        /// </summary>
        /// <param name="message">Сообщение с документом.</param>
        /// <param name="documentInfo">Полная информация о документе.</param>
        private void ProcessRequiredNotice(Message message, FullDocumentInfo documentInfo)
        {
            // Если требуется отправляем ИОП.
            if (IsNoticeRequired(documentInfo))
            {
                var document = documentInfo.Document;
                var documentType = (DocumentType)document.DocumentTypeEnum.Code;

                if (document.NeedReceipt)
                    UserInput.Information("Отправитель запросил подтверждение получения документа");

                if (UserInput.ChooseYesNo("Отправить извещение о получении?"))
                {
                    Console.Out.WriteLine("Отправляется извещение о получении");
                    var deliveryConfirmationMessage = documentType.IsInvoiceRegulationDocument()
                        ? _context.MessageFactory.CreateInvoiceReceipt(message, document, ChooseSignature)
                        : _context.MessageFactory.CreateReceipt(message, document, ChooseSignature);
                    SendServiceDocument(deliveryConfirmationMessage, "Извещение о получении отправлено");
                }
            }
            else
            {
                UserInput.Information("Извещение о получении уже было отправлено");
            }
        }

        /// <summary>
        /// Выполнить обработку требуемого подписания входящего документа.
        /// </summary>
        /// <param name="message">Сообщение с документом.</param>
        /// <param name="documentInfo">Полная информация о документе.</param>
        private void ProcessRequiredSignature(Message message, FullDocumentInfo documentInfo)
        {
            // Если требуется подпись, то подписываем, отказываем или пропускаем документ.
            if (IsSignatureRequired(documentInfo))
            {
                var document = documentInfo.Document;
                var documentType = (DocumentType)document.DocumentTypeEnum.Code;

                var userChoice = UserInput.ChooseOption("Требуется подписание документа. Выберите действие.", new[]
                {
                    new UserInput.Option("1", "Пропустить документ", true),
                    new UserInput.Option("2", "Подписать документ", false),
                    new UserInput.Option("3", "Отправить уведомление об уточнении", false),
                });

                switch (userChoice.Id)
                {
                    case "2":
                        // Генерируем подпись или ответный титул.
                        var isRootTitle = documentType.IsRootTitle();
                        if (!isRootTitle)
                            EnsureDocumentContentLoaded(document);
                        SendServiceDocument(
                            isRootTitle
                                ? CreateMessage(
                                    message.GetRecipientListForSender(_context.CurrentBox),
                                    documentType, document.Id)
                                : _context.MessageFactory.CreateSignature(message, document, ChooseSignature),
                            "Документ подписан");
                        break;

                    case "3":
                        // Генерируем СД УОУ.
                        var text = UserInput.ReadParameter("Текст уточнения", string.Empty);
                        var amendmentRequestMessage = documentType.IsInvoiceRegulationDocument()
                            ? _context.MessageFactory.CreateInvoiceAmendmentRequest(message, document, text, ChooseSignature)
                            : _context.MessageFactory.CreateAmendmentRequest(message, document, text, ChooseSignature);
                        SendServiceDocument(amendmentRequestMessage, "Отправлено уведомление об уточнении");
                        break;
                }
            }
        }

        /// <summary>
        /// Обработать нетипизированный документ.
        /// </summary>
        /// <param name="message">Сообщение с докуметом.</param>
        /// <param name="documentInfo">Полная информация о документе.</param>
        private void ProcessUntypedDocument(Message message, FullDocumentInfo documentInfo)
        {
            ProcessRequiredNotice(message, documentInfo);
            ProcessRequiredSignature(message, documentInfo);
        }

        /// <summary>
        /// Обработать предложение об аннулировании.
        /// </summary>
        /// <param name="message">Сообщение с докуметом.</param>
        /// <param name="documentInfo">Полная информация о документе.</param>
        private void ProcessRevocationOffer(Message message, FullDocumentInfo documentInfo)
        {
            ProcessRequiredSignature(message, documentInfo);
        }

        /// <summary>
        /// Выбрать тип документа.
        /// </summary>
        /// <param name="includeUntyped">Включить нетипизированный.</param>
        /// <param name="includeEdi">Включить EDI-документы.</param>
        /// <returns>Выбранный тип документа.</returns>
        private static DocumentType ChooseDocumentType(string chooseTitle,
            bool includeUntyped = true,
            bool includeEdi = true)
        {
            var i = 0;
            var chooseOptions = new List<UserInput.Option>();
            if (includeUntyped)
                chooseOptions.Add(new UserInput.Option($"{++i}", "Неструктурированный",
                    true, DocumentType.Untyped));

            chooseOptions.Add(new UserInput.Option($"{++i}", "Электронный счет-фактура",
                true, DocumentType.Invoice));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Товарная накладная (титул продавца)",
                true, DocumentType.WaybillSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Акт о выполнении работ (титул исполнителя)",
                true, DocumentType.ActOfWorkSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Исправленный счет-фактура",
                true, DocumentType.InvoiceRevision));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Корректировочный счет-фактура",
                true, DocumentType.InvoiceCorrection));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Исправленный корректировочный счет-фактура",
                true, DocumentType.InvoiceCorrectionRevision));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Документ о передаче результатов работ (титул исполнителя)",
                true, DocumentType.WorksTransferSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Исправленный документ о передаче результатов работ (титул исполнителя)",
                true, DocumentType.WorksTransferRevisionSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Документ о передаче товаров (титул продавца)",
                true, DocumentType.GoodsTransferSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Исправленный документ о передаче товаров (титул продавца)",
                true, DocumentType.GoodsTransferRevisionSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Универсальный передаточный документ (титул продавца)",
                true, DocumentType.GeneralTransferSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Исправленный универсальный передаточный документ (титул продавца)",
                true, DocumentType.GeneralTransferRevisionSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Универсальный корректировочный документ (титул продавца)",
                true, DocumentType.GeneralTransferCorrectionSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Исправленный универсальный корректировочный документ (титул продавца)",
                true, DocumentType.GeneralTransferCorrectionRevisionSeller));
            chooseOptions.Add(new UserInput.Option($"{++i}", "Транспортная накладная (титул грузоотправителя)",
                true, DocumentType.TransportWaybillConsignorTitle));

            if (includeEdi)
            {
                chooseOptions.Add(new UserInput.Option($"{++i}", "EDI-документ (автоматическое определение типа)",
                    true, DocumentType.EdiGeneral));
                chooseOptions.Add(new UserInput.Option($"{++i}", "EDI-документ (ORDERS) 'Заказ'",
                    true, DocumentType.EdiOrders));
                chooseOptions.Add(new UserInput.Option($"{++i}", "EDI-документ (ORDRSP) 'Подтверждение заказа'",
                    true, DocumentType.EdiOrdrsp));
                chooseOptions.Add(new UserInput.Option($"{++i}", "EDI-документ (DESADV) 'Уведомление об отгрузке'",
                    true, DocumentType.EdiDesadv));
                chooseOptions.Add(new UserInput.Option($"{++i}", "EDI-документ (RECADV) 'Уведомление о приеме'",
                    true, DocumentType.EdiRecadv));
            }

            var documentType = (DocumentType)UserInput.ChooseOption(chooseTitle, chooseOptions).Data;
            return documentType;
        }

        /// <summary>
        /// Выбрать информацию о типе документа.
        /// </summary>
        /// <param name="includeUntyped">Включить нетипизированный.</param>
        /// <param name="includeEdi">Включить EDI-документы.</param>
        /// <returns>Выбранный тип документа.</returns>
        private static DocumentTypeInfo ChooseDocumentTypeInfo(string chooseTitle,
            bool includeUntyped = true,
            bool includeEdi = true)
        {
            var documentType = ChooseDocumentType(chooseTitle, includeUntyped, includeEdi);
            var untypedKind = documentType == DocumentType.Untyped
                ? UserInput.ReadParameter("Укажите вид неформализованного документа при необходимости")
                : null;

            return new DocumentTypeInfo
            {
                DocumentType = documentType.ToEnumValue(),
                UntypedKind = untypedKind,
            };
        }

        private Message CreateMessage(
            IEnumerable<MessageRecipient> recipients,
            DocumentType? parentFocumentType = null,
            string parentId = null)
        {
            var message = new Message
            {
                Id = Guid.NewGuid().ToString(),
                From = _context.CurrentBox,
                //To = boxTo,
                Documents = new Document[0],
                Signs = new Sign[0],
                SimpleSignatures = new SimpleSignature[0],
                Recipients = recipients.ToArray()
            };

            do
            {
                DocumentType documentType;
                NamedContent namedContent = null;

                var generationOptions = new DocumentGenerationOptions
                {
                    SenderBoxId = _context.CurrentBox,
                    RecipientBoxId = recipients.First().OrganizationBoxId,
                };

                switch (parentFocumentType)
                {
                    case DocumentType.WaybillSeller:
                        Console.Out.WriteLine("Необходимо загрузить титул покупателя товарной накладной");
                        documentType = DocumentType.WaybillBuyer;
                        break;

                    case DocumentType.ActOfWorkSeller:
                        Console.Out.WriteLine("Необходимо загрузить титул заказчика акта о выполнении работ");
                        documentType = DocumentType.ActOfWorkBuyer;
                        break;

                    case DocumentType.GoodsTransferSeller:
                    case DocumentType.GoodsTransferRevisionSeller:
                        if (UserInput.ChooseYesNo("Сгенерировать титул покупателя ДПТ?"))
                            namedContent = _context.ServiceClient.GenerateGoodsTransferBuyer(
                                _context.CurrentBox, parentId,
                                CreateGoodsTransferBuyer(), generationOptions).NamedContent;
                        else
                            Console.Out.WriteLine("Необходимо загрузить титул покупателя ДПТ");
                        documentType = DocumentType.GoodsTransferBuyer;
                        break;

                    case DocumentType.WorksTransferSeller:
                    case DocumentType.WorksTransferRevisionSeller:
                        if (UserInput.ChooseYesNo("Сгенерировать титул покупателя ДПРР?"))
                            namedContent = _context.ServiceClient.GenerateWorksTransferBuyer(
                                _context.CurrentBox, parentId,
                                CreateWorksTransferBuyer(), generationOptions).NamedContent;
                        else
                            Console.Out.WriteLine("Необходимо загрузить титул покупателя ДПРР");
                        documentType = DocumentType.WorksTransferBuyer;
                        break;

                    case DocumentType.GeneralTransferSeller:
                    case DocumentType.GeneralTransferRevisionSeller:
                        if (UserInput.ChooseYesNo("Сгенерировать титул покупателя УПД?"))
                            namedContent = _context.ServiceClient.GenerateGeneralTransferBuyer(
                                _context.CurrentBox, parentId,
                                CreateGeneralTransferBuyer(), generationOptions).NamedContent;
                        else
                            Console.Out.WriteLine("Необходимо загрузить титул покупателя УПД");
                        documentType = DocumentType.GeneralTransferBuyer;
                        break;

                    case DocumentType.GeneralTransferCorrectionSeller:
                    case DocumentType.GeneralTransferCorrectionRevisionSeller:
                        if (UserInput.ChooseYesNo("Сгенерировать титул покупателя УКД?"))
                            namedContent = _context.ServiceClient.GenerateGeneralTransferCorrectionBuyer(
                                _context.CurrentBox, parentId,
                                CreateGeneralTransferCorrectionBuyer(), generationOptions).NamedContent;
                        else
                            Console.Out.WriteLine("Необходимо загрузить титул покупателя УКД");
                        documentType = DocumentType.GeneralTransferCorrectionBuyer;
                        break;

                    case DocumentType.TransportWaybillConsignorTitle:
                        documentType = (DocumentType) UserInput
                            .ChooseOption(
                                "Выберите тип ответного титула транспортной накладной",
                                new[]
                                {
                                    DocumentType.TransportWaybillCargoReceivedTitle,
                                    DocumentType.TransportWaybillCargoDeliveredTitle,
                                    DocumentType.TransportWaybillConsigneeTitle,
                                    DocumentType.TransportWaybillCarrierTitle,
                                    DocumentType.TransportWaybillDeliveryPlaceChangeTitle
                                })
                            .Data;
                        if (UserInput.ChooseYesNo("Сгенерировать ответный титул транспортной накладной?"))
                            switch (documentType)
                            {
                                case DocumentType.TransportWaybillCargoReceivedTitle:
                                    namedContent = _context.ServiceClient
                                        .GenerateTransportWaybillCargoReceivedTitle(
                                            GetCurrentCredentials(),
                                            new TransportWaybillCargoReceivedTitleGeneratingRequest
                                            {
                                                Model = CreateTransportWaybillCargoReceivedTitle(),
                                                Options = new TransportWaybillGenerationOptions(),
                                                ParentDocumentId = parentId,
                                            })
                                        .GeneratedContent.NamedContent;
                                    break;

                                case DocumentType.TransportWaybillCargoDeliveredTitle:
                                    namedContent = _context.ServiceClient
                                        .GenerateTransportWaybillCargoDeliveredTitle(
                                            GetCurrentCredentials(),
                                            new TransportWaybillCargoDeliveredTitleGeneratingRequest
                                            {
                                                Model = CreateTransportWaybillCargoDeliveredTitle(),
                                                Options = new TransportWaybillGenerationOptions(),
                                                ParentDocumentId = parentId,
                                            })
                                        .GeneratedContent.NamedContent;
                                    break;

                                case DocumentType.TransportWaybillConsigneeTitle:
                                    namedContent = _context.ServiceClient
                                        .GenerateTransportWaybillConsigneeTitle(
                                            GetCurrentCredentials(),
                                            new TransportWaybillConsigneeTitleGeneratingRequest
                                            {
                                                Model = CreateTransportWaybillConsigneeTitle(),
                                                Options = new TransportWaybillGenerationOptions(),
                                                ParentDocumentId = parentId,
                                            })
                                        .GeneratedContent.NamedContent;
                                    break;

                                case DocumentType.TransportWaybillCarrierTitle:
                                    namedContent = _context.ServiceClient
                                        .GenerateTransportWaybillCarrierTitle(
                                            GetCurrentCredentials(),
                                            new TransportWaybillCarrierTitleGeneratingRequest
                                            {
                                                Model = CreateTransportWaybillCarrierTitle(),
                                                Options = new TransportWaybillGenerationOptions(),
                                                ParentDocumentId = parentId,
                                            })
                                        .GeneratedContent.NamedContent;
                                    break;
                                case DocumentType.TransportWaybillDeliveryPlaceChangeTitle:

                                    var titleSenderType = (TransportWaybillInterchangeParticipantType)UserInput
                                        .ChooseOption(
                                            "Выберите тип отправителя титула изменения места доставки транспортной накладной",
                                            new[]
                                            {
                                                TransportWaybillInterchangeParticipantType.Driver,
                                                TransportWaybillInterchangeParticipantType.Consigee,
                                                TransportWaybillInterchangeParticipantType.Carrier
                                            })
                                        .Data;

                                    namedContent = _context.ServiceClient
                                        .GenerateTransportWaybillDeliveryPlaceChangeTitle(
                                            GetCurrentCredentials(),
                                            new TransportWaybillDeliveryPlaceChangeTitleGeneratingRequest
                                            {
                                                Model = CreateTransportWaybillDeliveryPlaceChangeTitle(),
                                                Options = new TransportWaybillGenerationOptions
                                                {
                                                    TitleSenderType = titleSenderType.ToEnumValue()
                                                },
                                                ParentDocumentId = parentId,
                                            })
                                        .GeneratedContent.NamedContent;
                                    break;
                            }
                        else
                            Console.Out.WriteLine("Необходимо загрузить ответный титул транспортной накладной");
                        break;

                    default:
                        documentType = ChooseDocumentType("Выберите тип документа");
                        break;
                }

                if (documentType != DocumentType.Invoice && documentType.IsInvoice())
                    parentId = UserInput.ReadParameter("Введите идентификатор родительского документа");

                if (namedContent == null)
                {
                    var filePath = UserInput.ReadParameter("Введите имя файла");
                    var content = TryGetFileContent(filePath);

                    if (content == null)
                        continue;

                    // TODO генерация имени файла для СФ тип документа Invoice
                    namedContent = new NamedContent
                    {
                        Content = content,
                        Name = Path.GetFileName(filePath),
                    };
                }

                string documentKindType = null;
                if (documentType == DocumentType.Untyped)
                    documentKindType = UserInput.ReadParameter("Укажите вид неформализованного документа при необходимости");

                byte[] card = null;
                if (!documentType.IsEdiDocument() && UserInput.ChooseYesNo("Прикрепить карточку?", false))
                {
                    var cardFilePath = UserInput.ReadParameter("Введите имя файла");
                    card = TryGetFileContent(cardFilePath);

                    if (card == null)
                        continue;
                }

                ISignature signature = null;

                var needSign = false;
                if (!documentType.IsEdiDocument())
                {
                    signature = ChooseSignature(namedContent.Content, documentType, documentKindType);

                    if (signature == null)
                        continue;

                    if (documentType.IsNeedSignOptional())
                        needSign = UserInput.ChooseYesNo("Запросить подпись под документом?");
                }

                AddDocumentToNewMessage(message, new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    // при интеграции с КИС здесь должен быть локальный идентификатор документа
                    DocumentType = documentType,
                    UntypedKind = documentKindType,
                    FileName = namedContent.Name,
                    Content = namedContent.Content,
                    Card = card,
                    NeedSign = needSign,
                    ParentDocumentId = parentId
                }, signature);

                if (documentType.IsRootTitle())
                {
                    if (!UserInput.ChooseYesNo("Добавить еще один документ для отправки?", false))
                        break;
                }
                else
                {
                    // При отправке ответного титула отправляется только один документ.
                    break;
                }
            } while (true);

            return message;
        }

        private UnsignedMessage CreateUnsignedMessage(IEnumerable<MessageRecipient> recipients)
        {
            var documents = new List<Document>();
            do
            {
                var filePath = UserInput.ReadParameter("Введите имя файла");

                var content = TryGetFileContent(filePath);
                if (content == null)
                    continue;

                var fileName = Path.GetFileName(filePath);
                var documentKindType = UserInput.ReadParameter("Укажите вид неформализованного документа при необходимости");
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
                    NeedSign = needSign
                });

                if (!UserInput.ChooseYesNo("Добавить еще один документ для отправки?", false))
                    break;
            } while (true);

            return new UnsignedMessage
            {
                From = _context.CurrentBox,
                Documents = documents.ToArray(),
                Recipients = recipients.ToArray()
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
                    Comment = comment
                });

                if (!UserInput.ChooseYesNo("Добавить еще один документ для пересылки?", false))
                    break;
            } while (true);

            var messageRecipients = recipients as IList<MessageRecipient> ?? recipients.ToList();
            var message = UserInput.ChooseYesNo("Добавить новые документы для отправки?", false)
                ? CreateMessage(messageRecipients)
                : null;

            return new ForwardMessage
            {
                From = _context.CurrentBox,
                ForwardDocuments = documents.ToArray(),
                Documents = message != null
                           ? message.Documents
                           : null,
                Recipients = message != null
                           ? message.Recipients
                           : messageRecipients.ToArray(),
                Signs = message != null
                           ? message.Signs
                           : null,
                SimpleSignatures = message != null
                           ? message.SimpleSignatures
                           : null
            };
        }

        private InternalMessage CreateInternalMessage(IEnumerable<InternalMessageRecipient> recipients)
        {
            var documents = new List<Document>();
            var strongSignatures = new List<Sign>();
            var simpleSignatures = new List<SimpleSignature>();
            do
            {
                var documentType = DocumentType.Untyped;
                var filePath = UserInput.ReadParameter("Введите имя файла");

                var content = TryGetFileContent(filePath);
                if (content == null)
                    continue;

                var fileName = Path.GetFileName(filePath);
                var documentKindType = UserInput.ReadParameter("Укажите вид неформализованного документа при необходимости");
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

                var signature = ChooseSignature(content, documentType, documentKindType);
                if (signature == null)
                    continue;

                var documentId = Guid.NewGuid().ToString();
                documents.Add(new Document
                {
                    Id = documentId,
                    DocumentType = documentType,
                    UntypedKind = documentKindType,
                    FileName = fileName,
                    Content = content,
                    Card = card,
                    NeedSign = needSign
                });

                signature.DocumentId = documentId;
                signature.Id = Guid.NewGuid().ToString();

                if (signature is Sign)
                    strongSignatures.Add(signature as Sign);
                else
                    simpleSignatures.Add(signature as SimpleSignature);

                if (!UserInput.ChooseYesNo("Добавить еще один документ для отправки?", false))
                    break;
            } while (true);

            return new InternalMessage
            {
                Id = Guid.NewGuid().ToString(),
                BoxId = _context.CurrentBox,
                Documents = documents.ToArray(),
                Recipients = recipients.ToArray(),
                Signs = strongSignatures.ToArray(),
                SimpleSignatures = simpleSignatures.ToArray()
            };
        }

        private void ProcessRootTitle(Message message, FullDocumentInfo documentInfo)
        {
            ProcessRequiredNotice(message, documentInfo);
            ProcessRequiredSignature(message, documentInfo);
        }

        private void ProcessAuthRequest(Contact contact)
        {
            if (UserInput.ChooseYesNo(string.Format("Авторизовать контрагента {0}", contact.ContragentName)))
            {
                var comment = UserInput.ReadParameter("Комментарий");
                _context.ServiceClient.AcceptAuthRequest(_context.CurrentOrganizationId, contact.ContragentId, comment);
                UserInput.Success(string.Format("Контрагент {0} авторизован", contact.ContragentName));
            }
            else
            {
                var comment = UserInput.ReadParameter("Комментарий");
                _context.ServiceClient.RejectAuthRequest(_context.CurrentOrganizationId, contact.ContragentId, comment);
                UserInput.Success(string.Format("Запрос авторизации от {0} отклонен", contact.ContragentName));
            }
        }

        private void SendServiceDocument(Message signMessage, string successText)
        {
            try
            {
                _context.ServiceClient.SendMessage(signMessage);
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
            var document = fullDocumentInfo.Document;
            var documentType = (DocumentType)document.DocumentTypeEnum.Code;
            switch (documentType)
            {
                case DocumentType.Invoice:
                    var invoiceDocumentFlowStatus = (InvoiceDocumentFlowStatus)fullDocumentInfo.Status;
                    return string.Format("Счет-фактура №{0} от {1}",
                        invoiceDocumentFlowStatus.Number,
                        invoiceDocumentFlowStatus.Date.ToString("dd/MM/yyyy"));
                case DocumentType.Untyped:
                    return string.Format("{0}", document.FileName);
                default:
                    return string.Format("{0}", documentType);
            }
        }

        /// <summary>
        /// Список доситупных ящиков.
        /// </summary>
        private void Boxes()
        {
            var boxInfos = _context.ServiceClient.GetBoxes();
            Console.Out.WriteLine("Доступно {0} ящиков, текущий ящик {1}", boxInfos.Length, _context.CurrentBox);
            foreach (var boxInfo in boxInfos)
            {
                Console.Out.WriteLine("ящик: {0}, название: {1}, ИНН/КПП {2}/{3}, id организации {4}", boxInfo.Address,
                    boxInfo.Name, boxInfo.Inn, boxInfo.Kpp, boxInfo.OrganizationId);
            }
        }

        /// <summary>
        /// Установить текущий ящик.
        /// </summary>
        private void SetBox()
        {
            var boxInfos = _context.ServiceClient.GetBoxes();
            var options =
                boxInfos.Select(
                    (b, i) =>
                        new UserInput.Option(i.ToString(CultureInfo.InvariantCulture), b.Address,
                            b.Address == _context.CurrentBox));
            var chooseOption = UserInput.ChooseOption("Выберите ящик", options);
            _context.CurrentBox = chooseOption.Name;
            _context.CurrentOrganizationId = boxInfos.Single(i => i.Address == _context.CurrentBox).OrganizationId;
            _context.LoadLastProcessedMessageId();
            _context.MessageFactory = new MessageFactory(_context.ServiceClient, _context.CurrentBox);
            Console.Out.WriteLine("Текущий ящик {0}", _context.CurrentBox);
        }

        /// <summary>
        /// Напечатать доступные команды.
        /// </summary>
        /// <param name="commandsMap">Доступные команды.</param>
        private void PrintAvailableCommands(Dictionary<string, Tuple<Action, string>> commandsMap)
        {
            Console.Out.WriteLine("Доступные команды:");
            foreach (var pair in commandsMap)
            {
                Console.Out.WriteLine("\t{0,-15}{1}", pair.Key, pair.Value.Item2);
            }
        }

        private void GetActiveContacts()
        {
            var contactInfos = _context.ServiceClient.SearchContacts(new ContactSearchOptions
            {
                From = 0,
                Max = 100,
                OrganizationId = _context.CurrentOrganizationId,
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
                var contact = _context.ServiceClient.GetContact(_context.CurrentOrganizationId,
                    contactInfo.ContragentId);
                PrintProperty("Контрагент", contact.ContragentName);
                PrintProperty("Авторизован", contact.Date);
            }
        }

        private void DeleteContact()
        {
            var contactInfos = _context.ServiceClient.SearchContacts(new ContactSearchOptions
            {
                From = 0,
                Max = 100,
                OrganizationId = _context.CurrentOrganizationId,
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
            if (
                !UserInput.ChooseYesNo(string.Format("Вы действительно хотите удалить контакт {0}",
                    selectedOrganization.ContragentName)))
                return;
            var comment = UserInput.ReadParameter("Комментарий");
            try
            {
                _context.ServiceClient.DeleteContact(_context.CurrentOrganizationId,
                    selectedOrganization.ContragentId,
                    comment);
            }
            catch (Exception ex)
            {
                UserInput.Error(string.Format("Не удалось удалить контакт {0}",
                    selectedOrganization.ContragentName));
                UserInput.Error(ex.ToString());
                return;
            }
            UserInput.Success(string.Format("Контакт {0} удален",
                selectedOrganization.ContragentName));
        }

        /// <summary>
        /// Авторизоваться.
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
                        if (client.Authenticate(login, password, _applicationId))
                        {
                            UserInput.Success("Аутентификация прошла успешно");
                            _context.Login = login;
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
                        ChooseAndSetContextCertificate();
                        if (client.AuthenticateWithCertificate(_context.Certificate.Thumbprint, _applicationId))
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
                        Register();
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
        /// Регистрация организации.
        /// </summary>
        private RegisterResult OldRegister()
        {
            Console.Out.WriteLine("При регистрации все поля обязательны к заполнению." +
                                  " Если у вас есть сертификат квалифицированной электронной подписи -  выберите сертификат" +
                                  " для автоматического заполнения полей формы регистрации.");
            Console.Out.WriteLine("Регистрация в сервисе Synerdocs:");

            var registerModel = new RegisterModel();

            if (UserInput.ChooseYesNo("Выбрать сертификат?", false))
            {
                // регистрация по сертификату
                ChooseAndSetContextCertificate();
            }
            else
            {
                // регистрация по паролю

                // очистим данные о сертификате, если они там есть
                _context.Certificate = null;

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
            while (pass1 == null || pass2 == null || pass1 != pass2)
            {
                pass1 = UserInput.ReadPassword("Введите пароль");
                pass2 = UserInput.ReadPassword("Подтвердите пароль");
                var passwordsNotEqualOrEmpty = pass1 == null || pass2 == null || pass1 != pass2;
                if (passwordsNotEqualOrEmpty)
                    UserInput.Error("Введённые пароли не совпадают! Повторите ввод пароля.");
            }
            registerModel.Password = pass1;

            registerModel.ServiceReglamentAccepted =
                UserInput.ChooseYesNo("Вы принимаете доступные по адресу www.synerdocs.ru Правила Synerdocs?");
            registerModel.OperatorCode = "2IG";
            registerModel.ServiceCode = Guid.NewGuid().ToString();

            var registerResult = new RegisterResult();


            while (!registerResult.Success)
            {
                registerResult = _context.ServiceClient.Register(registerModel,
                    _context.Certificate != null ? _context.Certificate.RawData : null);

                if (registerResult.Success)
                {
                    UserInput.Success(string.Format("Регистрация {0} прошла успешно",
                        registerResult.RegisterModel.OrganizationName));
                    return registerResult;
                }
                UserInput.Error("Во время регистрации обнаружены ошибки: \n" +
                                string.Join("\n", registerResult.ErrorMessages));

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
        /// Принятие Правил Synerdocs.
        /// </summary>
        private void AcceptRegulation()
        {
            var acceptRegulation =
                UserInput.ChooseYesNo("Вы принимаете доступные по адресу www.synerdocs.ru Правила Synerdocs?", false);

            if (_context.ServiceClient.AcceptRegulation(_context.CurrentBox, acceptRegulation))
            {
                UserInput.Success("Правила Synerdocs успешно приняты.");
            }
            else
                UserInput.Error("Правила Synerdocs не были приняты.");
        }

        /// <summary>
        /// Просмотр дерева орг.структуры.
        /// </summary>
        private void GetOrganizationStructure()
        {
            do
            {
                var departmentInfos = _context.ServiceClient.GetOrganizationStructure(_context.CurrentBox,
                    _context.CurrentOrganizationId.
                        ToString(CultureInfo.InvariantCulture));
                if (departmentInfos.Length == 0)
                {
                    Console.Out.WriteLine("Подразделений нет");
                    return;
                }


                _departmentsOptions = new List<UserInput.Option>();
                _index = 0;
                var depInputOptions = GetTreeOfOrganizationStructure(departmentInfos,
                    new[]
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
        /// Удалить подразделение.
        /// </summary>
        private void DeleteOrganizationStructureElement()
        {
            var departmentInfos = _context.ServiceClient.GetOrganizationStructure(_context.CurrentBox,
                _context.CurrentOrganizationId.ToString(CultureInfo.InvariantCulture));
            if (departmentInfos.Length == 0)
            {
                Console.Out.WriteLine("Подразделений нет");
                return;
            }

            _departmentsOptions = new List<UserInput.Option>();
            _index = 0;
            var depInputOptions = GetTreeOfOrganizationStructure(departmentInfos,
                new[] { departmentInfos.First(d => d.ParentId == null) }, 0);

            var chooseOption = UserInput.ChooseOption("Выберите подразделение", depInputOptions.AsEnumerable());
            var selectedDepartment = (OrganizationStructureElement)chooseOption.Data;

            if (
                !UserInput.ChooseYesNo(string.Format("Вы действительно хотите удалить подразделение {0}",
                    selectedDepartment.Name)))
                return;
            try
            {
                _context.ServiceClient.DeleteOrganizationStructureElement(
                    _context.CurrentOrganizationId.ToString(CultureInfo.InvariantCulture), selectedDepartment.Id);
            }
            catch (Exception ex)
            {
                UserInput.Error(string.Format("Не удалось удалить подразделение {0}", selectedDepartment.Name));
                UserInput.Error(ex.ToString());
                return;
            }
            UserInput.Success(string.Format("Подразделение {0} удалено", selectedDepartment.Name));
        }

        /// <summary>
        /// Добавить подразделение.
        /// </summary>
        private void AddOrganizationStructureElement()
        {
            do
            {
                var departmentInfos = _context.ServiceClient.GetOrganizationStructure(_context.CurrentBox,
                    _context.CurrentOrganizationId.ToString(CultureInfo.InvariantCulture));
                if (departmentInfos.Length == 0)
                {
                    Console.Out.WriteLine("Подразделений нет");
                    return;
                }

                _departmentsOptions = new List<UserInput.Option>();
                _index = 0;
                var depInputOptions = GetTreeOfOrganizationStructure(departmentInfos,
                    new[] { departmentInfos.First(d => d.ParentId == null) }, 0);

                var chooseOption = UserInput.ChooseOption("Выберите родительское подразделение",
                    depInputOptions.AsEnumerable());
                if (chooseOption.Data == null)
                    continue;
                var selectedDepartment = (OrganizationStructureElement)chooseOption.Data;

                var elementName = UserInput.ReadParameter("Введите наименование нового подразделения");
                var elementCode = UserInput.ReadParameter("Введите код нового подразделения");
                var elementKpp = UserInput.ReadParameter("Введите КПП нового подразделения");
                var elementAdditionalInfo = UserInput.ReadParameter("Введите примечание");

                try
                {
                    var elementId =
                        _context.ServiceClient.AddOrganizationStructureElement(new OrganizationStructureElement
                        {
                            Code = elementCode,
                            AdditionalInfo =
                                                                                       elementAdditionalInfo,
                            Kpp = elementKpp,
                            Name = elementName,
                            OrganizationId =
                                                                                       _context.CurrentOrganizationId
                                                                                       .ToString(
                                                                                           CultureInfo.InvariantCulture),
                            ParentId = selectedDepartment.Id
                        });
                }
                catch (Exception ex)
                {
                    UserInput.Error(string.Format("Не удалось добавить подразделение {0}", elementName));
                    UserInput.Error(ex.ToString());
                    return;
                }
                UserInput.Success(string.Format("Подразделение {0} добавлено", elementName));
                return;
            } while (true);
        }

        /// <summary>
        /// Редактировать подразделение.
        /// </summary>
        private void EditOrganizationStructureElement()
        {
            do
            {
                var departmentInfos = _context.ServiceClient.GetOrganizationStructure(_context.CurrentBox,
                    _context.CurrentOrganizationId.ToString(CultureInfo.InvariantCulture));
                if (departmentInfos.Length == 0)
                {
                    Console.Out.WriteLine("Подразделений нет");
                    return;
                }

                _departmentsOptions = new List<UserInput.Option>();
                _index = 0;
                var depInputOptions = GetTreeOfOrganizationStructure(departmentInfos,
                    new[] { departmentInfos.First(d => d.ParentId == null) }, 0);

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
                    chooseOption = UserInput.ChooseOption("Выберите новое родительское подразделение",
                        depInputOptions.AsEnumerable());
                    if (chooseOption.Data == null)
                        continue;
                    if (selectedDepartment.Id != ((OrganizationStructureElement)chooseOption.Data).Id)
                        selectedDepartment.ParentId = ((OrganizationStructureElement)chooseOption.Data).Id;
                    else
                    {
                        UserInput.Error(string.Format("Подразделение {0} не может быть родительским для самого себя",
                            selectedDepartment.Name));
                        return;
                    }
                }

                try
                {
                    _context.ServiceClient.ModifyOrganizationStructureElement(selectedDepartment);
                }
                catch (Exception ex)
                {
                    UserInput.Error(string.Format("Не удалось изменить подразделение {0}", selectedDepartment.Name));
                    UserInput.Error(ex.ToString());
                    return;
                }
                UserInput.Success(string.Format("Изменения по подразделению {0} сохранены", selectedDepartment.Name));
                return;
            } while (true);
        }

        /// <summary>
        /// Возвращает отступы для дерева орг.структуры.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private string GetSpace(int count)
        {
            var space = string.Empty;
            while (count > 0)
            {
                space = space + "  ";
                count = count - 1;
            }
            return space;
        }

        /// <summary>
        /// Возвращает дерево орг.структуры.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="elements"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<UserInput.Option> GetTreeOfOrganizationStructure(OrganizationStructureElement[] data,
            IEnumerable<OrganizationStructureElement> elements,
            int count)
        {
            foreach (var element in elements)
            {
                var label = GetSpace(count) + element.Name + " КПП: " + element.Kpp;
                _departmentsOptions.Add(new UserInput.Option((_index + 1).ToString(CultureInfo.InvariantCulture), label,
                    _index == 0, element));
                _index++;
                var childElements = data.Where(d => d.ParentId == element.Id);
                var organizationStructureElements = childElements as OrganizationStructureElement[] ??
                                                    childElements.ToArray();
                if (organizationStructureElements.Length != 0)
                    GetTreeOfOrganizationStructure(data, organizationStructureElements, count + 1);
            }

            return _departmentsOptions;
        }

        /// <summary>
        /// Добавляет промокод в организацию.
        /// </summary>
        private void AddOrganizationPromoCode()
        {
            var promoCodeName = UserInput.ReadParameter("Введите промокод");

            var boxId = _context.CurrentBox;

            try
            {
                _context.ServiceClient.AddOrganizationPromoCode(boxId, promoCodeName);
            }
            catch (Exception e)
            {
                UserInput.Error("Не удалось добавить промокод");
                UserInput.Error(e.Message);
                return;
            }

            UserInput.Success("Промокод успешно добавлен");
        }

        /// <summary>
        /// Вывод данных о промокоде.
        /// </summary>
        /// <param name="organizationPromoCode"></param>
        private void PrintPromoCodeInfo(OrganizationPromoCode organizationPromoCode)
        {
            UserInput.Separator();
            PrintProperty("ИД промокода", organizationPromoCode.OrganizationPromoCodeId);
            PrintProperty("Наименование", organizationPromoCode.Name);
            PrintProperty("Описание", organizationPromoCode.Description);
            PrintProperty("Бессрочный", organizationPromoCode.IsValidityNotLimited);
            if (!organizationPromoCode.IsValidityNotLimited)
            {
                PrintProperty("Начало действия", organizationPromoCode.StartDate);
                PrintProperty("Окончание действия", organizationPromoCode.ExpiryDate);
            }
        }

        /// <summary>
        ///  Возвращает список промокодов организации.
        /// </summary>
        private void GetOrganizationPromoCodeList()
        {
            var boxId = _context.CurrentBox;
            var promoCodes = _context.ServiceClient.GetOrganizationPromoCodeList(boxId);

            if (promoCodes.Length == 0)
            {
                UserInput.Error("Организация не имеет промокодов");
                return;
            }

            foreach (var item in promoCodes)
            {
                PrintPromoCodeInfo(item);
            }

            return;
        }

        /// <summary>
        /// Возвращает промокод по наименованию.
        /// </summary>
        private void GetPromoCodeByName()
        {
            var promoCodeName = UserInput.ReadParameter("Введите промокод");

            var promoCode = _context.ServiceClient.GetPromoCodeByName(promoCodeName);

            if (promoCode == null)
            {
                UserInput.Error("Промокода не существует");
                return;
            }

            PrintProperty("Наименование", promoCode.Name);
            PrintProperty("Описание", promoCode.Description);
            PrintProperty("Бессрочный", promoCode.IsValidityNotLimited);
            if (!promoCode.IsValidityNotLimited)
            {
                PrintProperty("Начало действия", promoCode.StartDate);
                PrintProperty("Окончание действия", promoCode.ExpiryDate);
            }

            return;
        }

        /// <summary>
        /// Логическое удаление связи промокод-организация.
        /// </summary>
        /// <param name="organizationPromoCodeId">Внешний идентификатор связи промокод-организация.</param>
        private void DeleteOrganizationPromoCode()
        {
            var boxId = _context.CurrentBox;

            var organizationPromoCodeId = UserInput.ReadParameter("Введите глобальный ИД промокода организации");

            try
            {
                _context.ServiceClient.DeleteOrganizationPromoCode(boxId, organizationPromoCodeId);
            }
            catch (Exception e)
            {
                UserInput.Error("не удалось удалить промокод");
                UserInput.Error(e.Message);
                return;
            }
            UserInput.Success("Промокод успешно удален");

        }

        /// <summary>
        /// Добавить тэг.
        /// </summary>
        private void AddDocumentTag()
        {
            do
            {
                var documentId = UserInput.ReadParameter("Введите идентификатор документа");
                var tagType =
                    (DocumentTagType)UserInput.ChooseOption("Выберите тип дополнительного статуса (тэга)", new[]
                        {
                            new UserInput.Option("1", "Согласовать", true, DocumentTagType.Approved),
                            new UserInput.Option("2", "Отказать в согласовании", true, DocumentTagType.Disapproved)
                        }).Data;

                var comment = UserInput.ReadParameter("Введите комментарий");

                string documentTagId;
                try
                {
                    documentTagId = _context.ServiceClient.CreateDocumentTag(
                        new DocumentTag
                        {
                            DocumentId = documentId,
                            Login = _context.Login.ToString(CultureInfo.InvariantCulture),
                            OrganizationBoxId = _context.CurrentBox.ToString(CultureInfo.InvariantCulture),
                            TagType = tagType,
                            Comment = comment
                        });
                }
                catch (Exception ex)
                {
                    UserInput.Error(String.Format("Не удалось добавить дополнительный статус (тэг) на документ ИД {0}",
                        documentId));
                    UserInput.Error(ex.ToString());
                    return;
                }
                UserInput.Success(String.Format("Дополнительный статус (тэг) добавлен. ИД: {0}", documentTagId));
                return;
            } while (true);
        }

        /// <summary>
        /// Удалить тэг.
        /// </summary>
        private void DeleteDocumentTag()
        {
            var documentTagId = UserInput.ReadParameter("Введите идентификатор дополнительного статуса (тэга)");
            if (!UserInput.ChooseYesNo("Вы действительно хотите удалить дополнительный статус (тэг)"))
                return;
            try
            {
                _context.ServiceClient.DeleteDocumentTag(documentTagId);
            }
            catch (Exception ex)
            {
                UserInput.Error(String.Format("Не удалось удалить дополнительный статус (тэг) с ИД {0}", documentTagId));
                UserInput.Error(ex.ToString());
                return;
            }
            UserInput.Success(String.Format("Дополнительный статус (тэг) с ИД {0} удален", documentTagId));
        }

        /// <summary>
        /// Получить тэг.
        /// </summary>
        private void GetDocumentTag()
        {
            var documentTagId = UserInput.ReadParameter("Введите идентификатор дополнительного статуса (тэга)");
            DocumentTag documentTag;
            try
            {
                documentTag = _context.ServiceClient.GetDocumentTag(documentTagId);
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

            PrintProperty("Логин", documentTag.Login);
            if (documentTag.User != null)
            {
                PrintProperty("Должность", documentTag.User.Position);
                PrintProperty("ФИО",
                    string.Format("{0} {1} {2}", documentTag.User.LastName, documentTag.User.FirstName,
                        documentTag.User.MiddleName));
            }
            PrintProperty("Ящик организации", documentTag.OrganizationBoxId);
            PrintProperty("ИД документа", documentTag.DocumentId);
            PrintProperty("Тип тэга", documentTag.TagType);
            PrintProperty("Комментарий", documentTag.Comment);
            PrintProperty("Дата создания", documentTag.CreateDate);
        }

        /// <summary>
        /// Отправить ПОА.
        /// </summary>
        private void SendRevocationOffer()
        {
            var certificate = _context.Certificate;
            var boxId = _context.CurrentBox;

            // ввод данных по ПОА
            var documentId = UserInput.ReadParameter("Введите ИД документа, который предлагается аннулировать");

            try
            {
                var fullDocumentInfo = _context.ServiceClient.GetFullDocumentInfo(boxId, documentId);

                if (fullDocumentInfo == null)
                {
                    UserInput.Error(String.Format("Не удалось получить документ с ИД {0}", documentId));
                    return;
                }

                // получим сообщение
                var documentMessage = _context.ServiceClient.GetMessage(boxId, fullDocumentInfo.MessageId);

                var comment = UserInput.ReadParameter("Введите комментарий для предложения об аннулировании");

                // создадим ПОА
                var revocationOfferDocumentType = DocumentType.RevocationOffer;
                var revocationOfferNamedContent = _context.ServiceClient.GenerateRevocationOffer(boxId, documentId,
                    comment, null);
                byte[] revokeContent = revocationOfferNamedContent.Content;
                var revokeRequestFileName = revocationOfferNamedContent.Name;

                // подпишем ПОА
                var signature = ChooseSignature(revocationOfferNamedContent.Content, revocationOfferDocumentType);
                if (signature == null)
                {
                    UserInput.Error("Не удалось подписать соглашение об аннулировании");
                    return;
                }

                // найдем получателей ПОА
                var recipients = documentMessage.GetRecipientListForSender(boxId);

                // отправим сообщение с ПОА
                var message = new Message
                {
                    Id = Guid.NewGuid().ToString(),
                    From = _context.CurrentBox,
                    Documents = new Document[0],
                    Signs = new Sign[0],
                    SimpleSignatures = new SimpleSignature[0],
                    Recipients = recipients.ToArray()
                };

                AddDocumentToNewMessage(message, new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    DocumentType = revocationOfferDocumentType,
                    FileName = revokeRequestFileName,
                    Content = revokeContent,
                    ParentDocumentId = documentId
                }, signature);

                _context.ServiceClient.SendMessage(message);

                UserInput.Success("ПОА успешно отправлено!");
            }
            catch (ServerException ex)
            {
                UserInput.Error(ex.Message);
                return;
            }

        }

        /// <summary>
        /// Отправка заявления об участии в ЭДО СФ.
        /// </summary>
        public void SendStatementOfInvoiceReglament()
        {
            try
            {
                // создадим заявление
                var documentType = DocumentType.Untyped;
                var statement = _context.ServiceClient.GenerateStatementOfInvoiceReglament(_context.CurrentBox);

                // создадим документ
                var document = new Document
                {
                    Id = Guid.NewGuid().ToString(),
                    DocumentType = documentType,
                    UntypedKind = UntypedKind.StatementOfInvoiceReglament,
                    FileName = statement.Name,
                    Content = statement.Content
                };

                // подпишем заявление
                var signature = ChooseSignature(document);
                if (signature == null)
                {
                    UserInput.Error("Не удалось подписать заявление об участии в ЭДО счетов-фактур");
                    return;
                }
                // отправим сообщение с заявлением
                var message = new MessageOfStatement
                {
                    Id = Guid.NewGuid().ToString(),
                    FromBoxId = _context.CurrentBox,
                    Statement = document,
                    Sign = new Sign
                    {
                        Id = Guid.NewGuid().ToString(),
                        DocumentId = document.Id,
                        Raw = signature.Raw
                    }
                };

                _context.ServiceClient.SendStatementOfInvoiceReglament(message);
                UserInput.Success("Заявление об участии в ЭДО счетов-фактур успешно отправлено!");
            }
            catch (ServerException ex)
            {
                UserInput.Error(ex.Message);
                return;
            }
        }

        private void ParseDocumentContentFromFile(UserInput.Option choise, byte[] content)
        {
            object model = null;
            if (choise.Id == "1")
                model = _context.ServiceClient.ParseGeneralTransferSeller(content);
            else if (choise.Id == "2")
                model = _context.ServiceClient.ParseGeneralTransferBuyer(content);
            else if (choise.Id == "3")
                model = _context.ServiceClient.ParseGeneralTransferCorrectionSeller(content);
            else if (choise.Id == "4")
                model = _context.ServiceClient.ParseGeneralTransferCorrectionBuyer(content);
            else if (choise.Id == "5")
                model = _context.ServiceClient.ParseGoodsTransferSeller(content);
            else if (choise.Id == "6")
                model = _context.ServiceClient.ParseGoodsTransferBuyer(content);
            else if (choise.Id == "7")
                model = _context.ServiceClient.ParseWorksTransferSeller(content);
            else if (choise.Id == "8")
                model = _context.ServiceClient.ParseWorksTransferBuyer(content);
            UserInput.FormatAndOutputObjectFields(model);
        }

        private void TryParseDocumentContentFromFile()
        {
            var cancel = new UserInput.Option("9", "Отмена", false);

            var userChoice = UserInput.ChooseOption("Выберите тип документа", new[]
                                                                              {
                                                                                  new UserInput.Option("1",
                                                                                      "Титул продавца УПД", true),
                                                                                  new UserInput.Option("2",
                                                                                      "Титул покупателя УДП", false),
                                                                                  new UserInput.Option("3",
                                                                                      "Титул продавца УКД", false),
                                                                                  new UserInput.Option("4",
                                                                                      "Титул покупателя УКД", false),
                                                                                  new UserInput.Option("5",
                                                                                      "Титул продавца ДПТ", false),
                                                                                  new UserInput.Option("6",
                                                                                      "Титул покупателя ДПТ", false),
                                                                                  new UserInput.Option("7",
                                                                                      "Титул продавца ДПРР", false),
                                                                                  new UserInput.Option("8",
                                                                                      "Титул покупателя ДПРР", false),
                                                                                  cancel
                                                                              });

            if (userChoice == cancel)
                return;

            var filePath = UserInput.ReadParameter("полный путь к файлу с документом, включая имя файла и расширение");

            if (!FileHelper.FileExists(filePath))
            {
                UserInput.Error("Файла по указанному пути не существует");
                return;
            }

            var content = FileHelper.GetFileContent(filePath);
            if (content.Length == 0)
            {
                UserInput.Error("Не удалось считать данные файла");
                return;
            }

            try
            {
                ParseDocumentContentFromFile(userChoice, content);
            }
            catch (Exception ex)
            {
                UserInput.Error("Произошла ошибка");
                UserInput.Error(ex.ToString());
            }
        }

        private void DownloadPdfDocument()
        {
            var documentId = UserInput.ReadParameter("Id документа");
            var pdfDocument = _context.ServiceClient.DownloadPdfDocument(_context.CurrentBox, documentId);
            if (pdfDocument == null)
            {
                UserInput.Error("Неправильный идентификатор документа");
                return;
            }

            Console.Out.Write("Получен документ в формате pdf. ");
            SaveFile(pdfDocument);
        }

        private void PrintDocument()
        {
            var documentId = UserInput.ReadParameter("Id документа");
            var response = _context.ServiceClient.PrintDocument(
                GetCurrentCredentials(), 
                new DocumentPrintingRequest {DocumentId = documentId });
            if (response == null)
            {
                UserInput.Error("Неправильный идентификатор документа");
                return;
            }

            Console.Out.Write("Получен документ в формате pdf.");
            SaveFile(response.NamedContent);
        }

        private void SaveFile(NamedContent namedContent)
        {
            if (!UserInput.ChooseYesNo("Сохранить файл?"))
                return;

            var directoryPath = ChooseDirectory();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            Console.Out.WriteLine("Сохранение файла: '{0}'", namedContent.Name);
            FileHelper.WriteAllBytes(directoryPath, namedContent.Name, namedContent.Content);
        }

        /// <summary>
        /// Регистрация организации.
        /// </summary>
        private void Register()
        {
            Console.Out.WriteLine("Если у вас есть сертификат квалифицированной электронной подписи - выберите сертификат" +
                                  " для автоматического заполнения полей формы регистрации.");
            Console.Out.WriteLine("Регистрация в сервисе Synerdocs:");

            var registrationRequest = new RegistrationRequest
            {
                ApplicationId = _applicationId
            };

            var organizationRegistrationData = new OrganizationRegistrationData();

            QualifiedX509Name subjectInfo = null;
            byte[] certRaw = null;
            if (UserInput.ChooseYesNo("Взять данные из сертификата?"))
            {
                var certificate = ChooseCertificateFromCertificateStores(true);
                certRaw = certificate.RawData;
                subjectInfo = _context.ServiceClient.GetCertificateSubjectInfo(certRaw);
            }

            UserRegistrationData certUser = null;
            var organizationTypeCode = subjectInfo?.Type?.Code;
            if (organizationTypeCode != null && (OrganizationType)organizationTypeCode != OrganizationType.LegalEntity)
            {
                if (!UserInput.ChooseYesNo(
                    $"Корректно ли определился тип абонента: {((OrganizationType)organizationTypeCode).GetDescription()} ?"))
                    organizationRegistrationData.OrganizationType = ChooseOrganizationType().ToEnumValue();
                else
                    organizationRegistrationData.OrganizationType = ((OrganizationType)organizationTypeCode).ToEnumValue();

                //заполним данные из сертификата
                FillOrganizationInfo(organizationRegistrationData, subjectInfo);
                certUser = new UserRegistrationData();
                FillUserInfo(certUser, subjectInfo);
                certUser.Certificate = certRaw;
            }
            else
            {
                organizationRegistrationData.OrganizationType = ChooseOrganizationType().ToEnumValue();
            }

            var organizationType = (OrganizationType)organizationRegistrationData.OrganizationType.Code;
            if (organizationType == OrganizationType.LegalEntity)
            {
                if (subjectInfo == null || !UserInput.ChooseYesNo($"Корректно ли наименование абонента: {organizationRegistrationData.Name} ?"))
                    organizationRegistrationData.Name = UserInput.ReadParameter("Введите наименование организации");
            }
            else
            {
                organizationRegistrationData.LastName = FillField(organizationRegistrationData.LastName, "Введите фамилию");
                organizationRegistrationData.FirstName = FillField(organizationRegistrationData.FirstName, "Введите имя");
                organizationRegistrationData.MiddleName = FillField(organizationRegistrationData.MiddleName, "Введите отчество");
            }

            if (organizationType.In(OrganizationType.LegalEntity,
                                    OrganizationType.IndividualEntrepreneur))
            {
                organizationRegistrationData.LegalName = FillField(organizationRegistrationData.LegalName, "Введите юридическое наименование");
            }

            organizationRegistrationData.Inn = FillField(organizationRegistrationData.Inn, "Введите ИНН");

            if (organizationType == OrganizationType.LegalEntity)
            {
                if (string.IsNullOrWhiteSpace(organizationRegistrationData.Kpp) || !UserInput.ChooseYesNo($"Корректно ли КПП абонента: {organizationRegistrationData.Kpp} ?"))
                    organizationRegistrationData.Kpp = UserInput.ReadParameter("Введите КПП");

                organizationRegistrationData.Ogrn = FillField(organizationRegistrationData.Ogrn, "Введите ОГРН");
            }
            else if (organizationType == OrganizationType.IndividualEntrepreneur)
            {
                organizationRegistrationData.Ogrn = FillField(organizationRegistrationData.Ogrn, "Введите ОГРНИП");
                organizationRegistrationData.StateRegistrationCert =
                   FillField(organizationRegistrationData.StateRegistrationCert, "Введите дату внесения записи об ИП в ЕГРИП");
            }

            //TODO synerman: хорошо бы здесь проверку сделать на существование абонента в сервисе. Пока не позволяет это сделать невозможность аутентификации приложения 
            //            var existingOrganizations =
            //                _context.ServiceClient.GetOrganizationListByInnKpp(organizationRegistrationData.Inn, organizationRegistrationData.Kpp);
            //            var operatorInfo = _context.ServiceClient.GetSpecialOperatorInfo();
            //            var existingOrganization = existingOrganizations.Single(o => o.OperatorCode.Equals(operatorInfo.OperatorServiceCode));
            //            if (existingOrganization != null)
            //                UserInput.Error("Данная организация {0} уже зарегистрирована в сервисе ", existingOrganization.GetCommonInfo());

            if (organizationType != OrganizationType.Individual)
                organizationRegistrationData.Ifns = UserInput.ReadParameter("Введите код ИФНС");

            organizationRegistrationData.Phone = UserInput.ReadParameter("Введите телефон");
            organizationRegistrationData.Fax = UserInput.ReadParameter("Введите факс");

            FillBankAccount(organizationRegistrationData);

            var isForeign = UserInput.ChooseYesNo("Иностранная организация?", false);
            organizationRegistrationData.IsForeignCompany = isForeign;

            FillAddress(organizationRegistrationData, isForeign);

            organizationRegistrationData.ContactAuthType = ((ContactAuthType)Enum
                .Parse(typeof(ContactAuthType),
                    UserInput.ChooseOption("Выберите тип авторизации контактов",
                        new[]
                        {
                            new UserInput.Option("1", "По выбору пользователя", true),
                            new UserInput.Option("2", "Принимать все приглашения", false),
                            new UserInput.Option("3", "Отклонять все приглашения", false)
                        }).Id)).ToEnumValue();

            registrationRequest.Organization = organizationRegistrationData;

            if (organizationType != OrganizationType.Individual
                && UserInput.ChooseYesNo("Ввести оргструктуру?", false))
            {
                var departments = new List<DepartmentRegistrationData>();
                do
                {
                    CreateDepartment(departments);
                    if (!UserInput.ChooseYesNo("Добавить еще одно подразделение?", false))
                        break;

                } while (true);

                registrationRequest.Departments = departments;
            }

            CreateUsers(registrationRequest, certUser);

            if (UserInput.ChooseYesNo("Ввести промокоды?", false))
            {
                var promoCodes = new List<string>();
                do
                {
                    var promoCode = UserInput.ReadParameter("Введите промокод");
                    //TODO synerman: Пока не позволяет это сделать невозможность аутентификации приложения 
                    //                    try
                    //                    {
                    //                        _context.ServiceClient.GetPromoCodeByName(promoCode);
                    //                    }
                    //                    catch (Exception ex)
                    //                    {
                    //                        UserInput.Error($"Промокода {promoCode} не существует.");
                    //                        if (UserInput.ChooseYesNo("Повторить попытку?"))
                    //                            promoCode = UserInput.ReadParameter("Введите промокод");
                    //                    }

                    promoCodes.Add(promoCode);
                    if (!UserInput.ChooseYesNo("Добавить еще один промокод?", false))
                        break;
                } while (true);

                registrationRequest.PromoCodes = promoCodes;
            }

            registrationRequest.ServiceReglamentAccepted =
                UserInput.ChooseYesNo("Вы принимаете Правила Synerdocs и подтверждаете, что ознакомились с Лиценционным договором (публичная оферта) по ссылке http://www.synerdocs.ru/dogovor_EDO.PDF?");

            var registrationResponse = _context.ServiceClient.RegisterSubscriber(registrationRequest);
            if (registrationResponse.Code.Code == (int)RegistrationResponseCode.Success)
            {
                UserInput.Success($"Регистрация {registrationResponse.Result.Organization.Name} прошла успешно");
                var user = registrationRequest.Users.First();
                _context.ServiceClient.Authenticate(user.Login, user.Password, _applicationId);
            }
            else
            {
                var validationResult = registrationResponse.ValidationResult;
                var flatResult = validationResult.GetFlatResults();
                UserInput.Error("Во время регистрации обнаружены ошибки: \n" +
                                string.Join("\n", flatResult.Values.SelectMany(v => v.Messages).Select(m => m.Text).ToList()));
            }
        }

        private DepartmentRegistrationData CreateDepartment(IList<DepartmentRegistrationData> departments)
        {
            var departmentRegistrationData = new DepartmentRegistrationData();
            var autoGeneration = new UserInput.Option("1", "Сгенерировать автоматически", true);
            var manuallyEntry = new UserInput.Option("2", "Ввести вручную", false);

            var chooseOption =
                UserInput.ChooseOption("Выбрать способ ввода идентификатора подразделения",
                    new[]
                    {
                        autoGeneration,
                        manuallyEntry
                    });

            departmentRegistrationData.Id = chooseOption == autoGeneration
                ? Guid.NewGuid().ToString()
                : UserInput.ReadParameter("Введите идентификатор подразделения");

            var guidResult = new Guid();
            while (!Guid.TryParse(departmentRegistrationData.Id, out guidResult))
            {
                UserInput.Error($"Некорректный формат идентификатора. Должен быть Guid формата {Guid.Empty}");

                departmentRegistrationData.Id = chooseOption == autoGeneration
                    ? Guid.NewGuid().ToString()
                    : UserInput.ReadParameter("Введите идентификатор подразделения");
            }

            departmentRegistrationData.Name = UserInput.ReadParameter("Введите наименование");
            departmentRegistrationData.Code = UserInput.ReadParameter("Введите код подразделения");

            if (UserInput.ChooseYesNo("Ввести КПП?", false))
                departmentRegistrationData.Kpp = UserInput.ReadParameter("Введите КПП");

            if (UserInput.ChooseYesNo("Ввести дополнительную информацию?", false))
                departmentRegistrationData.AdditionalInfo = UserInput.ReadParameter("Введите дополнительную информацию");

            if (UserInput.ChooseYesNo("Указать идентификатор родительского подразделения?", false))
            {
                if (!departments.Any())
                {
                    if (UserInput.ChooseYesNo("Список доступных подразделений пуст. Добавить новое подразделение?", false))
                    {
                        var parentDepartment = CreateDepartment(departments);
                        departmentRegistrationData.ParentId = parentDepartment.Id;
                    }
                }
                else
                {
                    var fromList = new UserInput.Option("1", "Выбрать из списка доступных", true);
                    manuallyEntry = new UserInput.Option("2", "Добавить новое", false);

                    chooseOption =
                        UserInput.ChooseOption("Выбрать подразделение",
                            new[]
                            {
                                fromList,
                                manuallyEntry
                            });

                    if (chooseOption == fromList)
                    {
                        var departmentOption = UserInput.ChooseOption
                            ("Выберите родительское подразделение",
                                departments.Select(
                                    (c, i) =>
                                        new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture), c.Name,
                                            i == 0, c)));

                        var parentDepartment = ((DepartmentRegistrationData)departmentOption.Data);
                        departmentRegistrationData.ParentId = parentDepartment.Id;
                    }
                    else
                    {
                        var parentDepartment = CreateDepartment(departments);
                        departmentRegistrationData.ParentId = parentDepartment.Id;
                    }
                }
            }

            departments.Add(departmentRegistrationData);
            return departmentRegistrationData;
        }

        private void UploadCertificate(UserRegistrationData userRegistrationData)
        {
            var loadFromRegisterOption = new UserInput.Option("1", "Из реестра установленных", true);
            var loadFromFileOption = new UserInput.Option("2", "Из файла", false);
            var option =
                UserInput.ChooseOption("Выберите способ загрузки сертификата",
                    new[]
                    {
                        loadFromRegisterOption,
                        loadFromFileOption
                    });

            if (option == loadFromRegisterOption)
            {
                userRegistrationData.Certificate = ChooseCertificateFromCertificateStores(true)?.RawData;
            }
            else
            {
                string filePath = null;
                while (!File.Exists(filePath))
                {
                    filePath = UserInput.ReadParameter("Введите имя файла");
                    // если путь не абсолютный, то пытаемся найти файл из текущей директории
                    if (!Path.IsPathRooted(filePath))
                        filePath = Path.Combine(Environment.CurrentDirectory, filePath);
                    if (!File.Exists(filePath))
                        UserInput.Error("Файл не найден {0}", filePath);
                }

                var content = File.ReadAllBytes(filePath);
                var certificateValidationResult = _context.ServiceClient.CheckQualifiedCertificate(content);

                if (certificateValidationResult.CommonStatus == CertificateValidationStatus.Error)
                {
                    UserInput.Error("Указан некорректный сертификат. Ошибки: {0}",
                        string.Join(";",
                            certificateValidationResult.FieldValidationResults.Where(
                                r => r.Status == CertificateValidationStatus.Error).Select(p => p.Message)));
                    UploadCertificate(userRegistrationData);
                }
                else
                    userRegistrationData.Certificate = File.ReadAllBytes(filePath);
            }
        }

        /// <summary>
        /// Выбрать сертификат из списка установленных в системе.
        /// </summary>
        private X509Certificate2 ChooseCertificateFromCertificateStores(bool excludeRegisteredCertificates = false)
        {
            // The following code gets the cert from the keystore
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            var certificates =
                store.Certificates.Cast<X509Certificate2>()
                    // выбираем только сертификаты с закрытым ключем
                    .Where(c => c.HasPrivateKey)
                    .Where(c => _supportedSignatureAlgorithms.Contains(c.SignatureAlgorithm.Value))
                    .ToList();

            if (excludeRegisteredCertificates)
            {
                var registeredCertificates =
                    _context.ServiceClient.CheckCertificateList(certificates.Select(c => c.Thumbprint).ToArray());
                certificates.RemoveAll(c => registeredCertificates.Any(p => p.Thumbprint.Equals(c.Thumbprint)));
            }

            var chooseOption = UserInput.ChooseOption("Выберите сертификат", certificates
                .Select((c, i) => new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture),
                    // получаем Common Name (CN) из сертификата
                    c.GetNameInfo(X509NameType.SimpleName, false),
                    i == 0, c)));
            return (X509Certificate2)chooseOption.Data;
        }

        private void CreateAddressRF(AddressType type, List<OrganizationAddress> addresses)
        {
            var address = new OrganizationAddress
            {
                AddressType = type,
                AddressLocationType = new EnumValue
                {
                    Name = "AddressRF",
                    Code = 0,
                    Description = "Адрес в РФ"
                }
            };

            address.RegionCode = UserInput.ReadParameter("Введите код региона");
            address.PostalCode = UserInput.ReadParameter("Введите почтовый индекс");
            if (type == AddressType.Mailing)
                address.PostOfficeBox = UserInput.ReadParameter("Введите абонентский ящик");

            if (UserInput.ChooseYesNo("Ввести город?"))
                address.City = UserInput.ReadParameter("Введите город");
            else
            {
                address.Locality = UserInput.ReadParameter("Введите населенный пункт");
                address.District = UserInput.ReadParameter("Введите район");
            }

            address.Street = UserInput.ReadParameter("Введите улицу");
            address.Apartment = UserInput.ReadParameter("Введите номер дома");
            address.Building = UserInput.ReadParameter("Введите строение");
            address.Apartment = UserInput.ReadParameter("Введите номер квартиры");
            addresses.Add(address);
        }

        private void CreateForeignAddress(AddressType type, List<OrganizationAddress> addresses)
        {
            var address = new OrganizationAddress
            {
                AddressType = type,
                IsForeign = true,
                AddressLocationType = new EnumValue
                {
                    Name = "UnstructuredAddress",
                    Code = 1,
                    Description = "Неструктурированный адрес"
                }
            };

            address.CountryCode = UserInput.ReadParameter("Введите код страны");
            address.ForeignStreetAddress = UserInput.ReadParameter("Введите адрес");
            addresses.Add(address);
        }

        private void CreateAddress(AddressType type, List<OrganizationAddress> addresses, bool isForeign = false)
        {
            if (isForeign)
                CreateForeignAddress(type, addresses);
            else
                CreateAddressRF(type, addresses);
        }

        private void FillOrganizationInfo(OrganizationRegistrationData organizationRegistrationData, QualifiedX509Name fullSubjectInfo)
        {
            organizationRegistrationData.Name = fullSubjectInfo.OrganizationName;
            organizationRegistrationData.Inn = fullSubjectInfo.Inn;
            organizationRegistrationData.Kpp = fullSubjectInfo.Kpp;
            organizationRegistrationData.Ogrn = fullSubjectInfo.Ogrn;
            organizationRegistrationData.LastName = fullSubjectInfo.LastName;
            organizationRegistrationData.FirstName = fullSubjectInfo.FirstName;
            organizationRegistrationData.MiddleName = fullSubjectInfo.MiddleName;

            var address = new OrganizationAddress
            {
                AddressType = AddressType.Legal,
                City = fullSubjectInfo.Location,
                RegionCode = fullSubjectInfo.Region.Code,
                Street = fullSubjectInfo.Street,
                House = fullSubjectInfo.House,
                Building = fullSubjectInfo.Building,
                Apartment = fullSubjectInfo.Apartment,
                PostalCode = fullSubjectInfo.PostalCode,
                AddressLocationType = new EnumValue
                {
                    Name = "AddressRF",
                    Code = 0,
                    Description = "Адрес в РФ"
                }
            };

            organizationRegistrationData.Addresses = new[] { address };
        }

        private void FillUserInfo(UserRegistrationData userRegistrationData, QualifiedX509Name fullSubjectInfo)
        {
            userRegistrationData.LastName = fullSubjectInfo.LastName;
            userRegistrationData.FirstName = fullSubjectInfo.FirstName;
            userRegistrationData.MiddleName = fullSubjectInfo.MiddleName;
            userRegistrationData.Email = fullSubjectInfo.Email;
            userRegistrationData.Position = fullSubjectInfo.Position;
        }

        private string FillField(string value, string text)
        {
            return string.IsNullOrWhiteSpace(value) ? UserInput.ReadParameter(text) : value;
        }

        private void FillBankAccount(OrganizationRegistrationData organizationRegistrationData)
        {
            if (UserInput.ChooseYesNo("Ввести банковские реквизиты?", false))
            {
                organizationRegistrationData.BankAccount = new BankAccount();
                organizationRegistrationData.BankAccount.Bank = new Bank();
                organizationRegistrationData.BankAccount.Bank.Name =
                    UserInput.ReadParameter("Введите наименование банка");
                organizationRegistrationData.BankAccount.Bank.Bik =
                    UserInput.ReadParameter("Введите банковский идентификационный код");
                organizationRegistrationData.BankAccount.PaymentAccount =
                    UserInput.ReadParameter("Введите расчетный счет");
                organizationRegistrationData.BankAccount.CorrespondentAccount =
                    UserInput.ReadParameter("Введите корреспондентский счет");
            }
        }

        private void FillAddress(OrganizationRegistrationData organizationRegistrationData, bool isForeign = false)
        {
            var addresses = new List<OrganizationAddress>();
            if (organizationRegistrationData.OrganizationType.Code != (int)OrganizationType.Individual)
            {
                if (organizationRegistrationData.Addresses?.Any() == true)
                {
                    addresses.Add(organizationRegistrationData.Addresses.First());
                }
                else
                {
                    Console.Out.WriteLine("Заполните юридический адрес.");
                    CreateAddress(AddressType.Legal, addresses, isForeign);
                }

                if (addresses.Any(a => a.AddressType == AddressType.Legal)
                    && UserInput.ChooseYesNo("Почтовый адрес тот же?"))
                {
                    var legalAddress = addresses.First();
                    addresses.Add(new OrganizationAddress
                    {
                        AddressType = AddressType.Mailing,
                        AddressLocationType = legalAddress.AddressLocationType,
                        Apartment = legalAddress.Apartment,
                        Building = legalAddress.Building,
                        City = legalAddress.City,
                        CountryCode = legalAddress.CountryCode,
                        District = legalAddress.District,
                        ForeignStreetAddress = legalAddress.ForeignStreetAddress,
                        House = legalAddress.House,
                        IsForeign = legalAddress.IsForeign,
                        Locality = legalAddress.Locality,
                        PostalCode = legalAddress.PostalCode,
                        RegionCode = legalAddress.RegionCode,
                        StateRegistryCode = legalAddress.StateRegistryCode,
                        Street = legalAddress.Street
                    });
                }
                else
                {
                    if (UserInput.ChooseYesNo("Ввести почтовый адрес?", false))
                        CreateAddress(AddressType.Mailing, addresses, isForeign);
                }
            }
            else
            {
                if (organizationRegistrationData.Addresses != null && organizationRegistrationData.Addresses.Any())
                {
                    var address = organizationRegistrationData.Addresses.First();
                    address.AddressType = AddressType.Registration;
                    addresses.Add(address);
                }
                else
                {
                    Console.Out.WriteLine("Заполните адрес регистрации.");
                    CreateAddress(AddressType.Registration, addresses, isForeign);
                }
            }

            if (addresses.Any())
                organizationRegistrationData.Addresses = addresses.ToArray();
        }

        private OrganizationType ChooseOrganizationType()
        {
            return (OrganizationType)Enum
                   .Parse(typeof(OrganizationType),
                       UserInput.ChooseOption("Выберите тип организации", new[]
                           {
                                new UserInput.Option("1", "Юридическое лицо", true),
                                new UserInput.Option("2", "Индивидуальный предприниматель", false),
                                new UserInput.Option("3", "Физическое лицо", false)
                           }).Id);
        }

        private void CreateUsers(RegistrationRequest registrationRequest, UserRegistrationData certUser = null)
        {
            var organization = registrationRequest.Organization;
            var users = new List<UserRegistrationData>();
            if (registrationRequest.Organization.OrganizationType.Code != (int)OrganizationType.Individual)
                Console.Out.WriteLine("Добавление пользователей");

            do
            {
                var userRegistrationData = !users.Any() && certUser != null ? certUser : new UserRegistrationData();
                userRegistrationData.Login = UserInput.ReadParameter("Введите логин");

                string pass1 = null, pass2 = null;
                while (string.IsNullOrWhiteSpace(pass1) || string.IsNullOrWhiteSpace(pass2) || pass1 != pass2)
                {
                    pass1 = UserInput.ReadPassword("Введите пароль");
                    pass2 = UserInput.ReadPassword("Подтвердите пароль");
                    var passwordsNotEqualOrEmpty = pass1 == null || pass2 == null || pass1 != pass2;
                    if (passwordsNotEqualOrEmpty)
                        UserInput.Error("Введённые пароли не совпадают! Повторите ввод пароля.");
                }
                userRegistrationData.Password = pass1;

                if (registrationRequest.Organization.OrganizationType.Code != (int)OrganizationType.Individual)
                {
                    userRegistrationData.LastName = FillField(userRegistrationData.LastName, "Введите фамилию");
                    userRegistrationData.FirstName = FillField(userRegistrationData.FirstName, "Введите имя");
                    userRegistrationData.MiddleName = FillField(userRegistrationData.MiddleName, "Введите отчество");
                    userRegistrationData.Position = FillField(userRegistrationData.Position, "Введите должность");
                }
                else
                {
                    userRegistrationData.LastName = organization.LastName;
                    userRegistrationData.FirstName = organization.FirstName;
                    userRegistrationData.MiddleName = organization.MiddleName;
                }

                userRegistrationData.Phone = FillField(userRegistrationData.Phone, "Введите телефон");
                userRegistrationData.Skype = FillField(userRegistrationData.Skype, "Введите номер скайпа");
                userRegistrationData.Email = FillField(userRegistrationData.Email, "Введите email");
                userRegistrationData.Snils = FillField(userRegistrationData.Snils, "Введите СНИЛС");
                userRegistrationData.Comment = UserInput.ReadParameter("Введите комментарий");
                userRegistrationData.IsAdmin = organization.OrganizationType.Code == (int)OrganizationType.Individual || UserInput.ChooseYesNo("Является администратором организации?");

                if (userRegistrationData.Certificate == null && UserInput.ChooseYesNo("Указать сертификат?", false))
                    UploadCertificate(userRegistrationData);

                var simpleSignatureEnabled = UserInput.ChooseYesNo("Включить возможность использования простой ЭП?", false);
                userRegistrationData.Settings.Add(new SettingData
                {
                    SettingType = new EnumValue
                    {
                        Code = (int)SettingType.SimpleSignature,
                    },
                    Value = new SettingValue
                    {
                        ValueText = simpleSignatureEnabled.ToString(),
                    }
                });

                if (registrationRequest.Departments != null
                    && registrationRequest.Departments.Any()
                    && organization.OrganizationType.Code != (int)OrganizationType.Individual
                    && UserInput.ChooseYesNo("Привязать пользователя к подразделению?", false))
                {
                    var departmentOption = UserInput.ChooseOption
                        ("Выберите подразделение",
                            registrationRequest.Departments.Select(
                                (c, i) =>
                                    new UserInput.Option((i + 1).ToString(CultureInfo.InvariantCulture), c.Name,
                                        i == 0, c)));

                    var department = ((DepartmentRegistrationData)departmentOption.Data);
                    userRegistrationData.DepartmentId = department.Id;
                }

                users.Add(userRegistrationData);
                if (organization.OrganizationType.Code == (int)OrganizationType.Individual
                    || !UserInput.ChooseYesNo("Добавить еще одного пользователя?", false))
                    break;

            } while (true);

            registrationRequest.Users = users;
        }

        /// <summary>
        /// Регистрация неактивного абонента.
        /// </summary>
        private void CreateNonActiveSubscriber()
        {
            var creationRequest = new NonActiveSubscriberCreationRequest();
            var organizationTypeOption = ChooseOrganizationType();

            creationRequest.OrganizationType = organizationTypeOption.ToEnumValue();

            if (organizationTypeOption == OrganizationType.LegalEntity)
            {
                creationRequest.Name = UserInput.ReadParameter("Введите наименование организации");
            }
            else
            {
                creationRequest.LastName = UserInput.ReadParameter("Введите фамилию");
                creationRequest.FirstName = UserInput.ReadParameter("Введите имя");
                creationRequest.MiddleName = UserInput.ReadParameter("Введите отчество");
            }

            var existingOrganization = new Organization();
            while (existingOrganization != null)
            {
                creationRequest.Inn = UserInput.ReadParameter("Введите ИНН");
                if (organizationTypeOption == OrganizationType.LegalEntity)
                    creationRequest.Kpp = UserInput.ReadParameter("Введите КПП");

                var existingOrganizations =
                    _context.ServiceClient.GetOrganizationListByInnKpp(creationRequest.Inn, creationRequest.Kpp);
                var operatorInfo = _context.ServiceClient.GetSpecialOperatorInfo();
                existingOrganization = existingOrganizations?.FirstOrDefault(o => o.OperatorCode.Equals(operatorInfo.OperatorServiceCode));

                if (existingOrganization != null)
                    UserInput.Error("Данная организация {0} уже зарегистрирована в сервисе ", existingOrganization.GetCommonInfo());
            }

            creationRequest.Phone = UserInput.ReadParameter("Введите телефон");
            creationRequest.ContactPerson = UserInput.ReadParameter("Введите контактное лицо");

            var emails = new List<string>();
            do
            {
                var email = UserInput.ReadParameter("Введите email");
                emails.Add(email);

                if (!UserInput.ChooseYesNo("Добавить еще один email?", false))
                    break;

            } while (true);

            creationRequest.Emails = emails;

            var response = _context.ServiceClient.CreateNonActiveSubscriber(creationRequest);
            if (response.Code.Code == (int)RegistrationResponseCode.Success)
            {
                UserInput.Success($"Неактивный абонент {response.Result.Name} с ящиком {response.Result.OrganizationBoxId} успешно создан. ");
            }
            else
            {
                var validationResult = response.ValidationResult;
                var flatResult = validationResult.GetFlatResults();

                UserInput.Error("Во время регистрации обнаружены ошибки: \n" +
                                string.Join("\n",
                                    flatResult.Values.SelectMany(v => v.Messages).Select(m => m.Text)));
            }
        }

        /// <summary>
        /// Проверить доступность использования простой ЭП.
        /// </summary>
        private void CheckSimpleSignatureAvailability()
        {
            try
            {
                var request = new SimpleSignatureAvailabilityCheckingRequest();

                var userChoice = UserInput.ChooseOption("Выберите способ получения документа", new[]
                {
                    new UserInput.Option("1", "По ИД документа из сервиса", true),
                    new UserInput.Option("2", "По типу документа", false),
                    new UserInput.Option("3", "По имени файла", false),
                    new UserInput.Option("4", "Не указывать документ", false)
                });

                switch (userChoice.Id)
                {
                    case "1":
                        request.Document = new SimpleSignatureAvailabilityCheckingDocumentId
                        {
                            Id = UserInput.ReadParameter("Введите идентификатор документа")
                        };
                        break;

                    case "2":
                        var documentTypeInfo = ChooseDocumentTypeInfo("Выберите тип документа");
                        request.Document = new SimpleSignatureAvailabilityCheckingDocumentType
                        {
                            DocumentTypeInfo = documentTypeInfo,
                        };
                        break;

                    case "3":
                        var filePath = UserInput.ReadParameter("Введите имя файла");
                        request.Document = new SimpleSignatureAvailabilityCheckingDocumentContent
                        {
                            Content = TryGetFileContent(filePath)
                        };
                        break;
                }

                var credentials = GetCurrentCredentials();
                var response = _context.ServiceClient.CheckSimpleSignatureAvailability(credentials, request);

                Console.Out.WriteLine(response.AvailabilityStatus.Description);
            }
            catch (Exception ex)
            {
                UserInput.Error("При выполнении команды произошла ошибка");
                UserInput.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Принять регламент использования простой ЭП.
        /// </summary>
        private void AcceptSimpleSignatureRegulation()
        {
            try
            {
                var acceptRegulation =
                    UserInput.ChooseYesNo("Принять регламент использования простой ЭП?", false);

                if (!acceptRegulation)
                    return;

                var credentials = GetCurrentCredentials();
                var request = new SimpleSignatureRegulationAcceptingRequest();

                _context.ServiceClient.AcceptSimpleSignatureRegulation(credentials, request);
                UserInput.Success("Регламент использования простой ЭП успешно принят");
            }
            catch (ServerException ex) when (ex.Code.In(
                ServiceErrorCode.SimpleSignatureRegulationAlreadyAccepted,
                ServiceErrorCode.SimpleSignatureRegulationOrganizationIsNotActive))
            {
                UserInput.Error(ex.Message);
            }
            catch (Exception ex)
            {
                UserInput.Error("При выполнении команды произошла ошибка");
                UserInput.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Предварительный просмотр реквизитов простой ЭП.
        /// </summary>
        private void PreviewSimpleSignatureRequisites()
        {
            try
            {
                var request = new SimpleSignatureRequisitesPreviewingRequest();

                request.Comment = UserInput.ReadParameter("Введите комментарий к подписи");
                if (string.IsNullOrEmpty(request.Comment))
                    request.Comment = null;

                var credentials = GetCurrentCredentials();
                var response = _context.ServiceClient.PreviewSimpleSignatureRequisites(credentials, request);

                PrintSimpleSignatureRequisites(response.Requisites);
            }
            catch (ServerException ex) when (ex.Code.In(
                ServiceErrorCode.SimpleSignatureDisabled,
                ServiceErrorCode.SimpleSignatureRegulationNotAccepted,
                ServiceErrorCode.SimpleSignatureSnilsNotSpecified))
            {
                UserInput.Error(ex.Message);
            }
            catch (Exception ex)
            {
                UserInput.Error("При выполнении команды произошла ошибка");
                UserInput.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Создать простую ЭП.
        /// </summary>
        private void CreateSimpleSignature()
        {
            try
            {
                var signature = ChooseSimpleSignature();

                PrintSimpleSignatureInfo(signature);

                SaveFile(new NamedContent
                {
                    Name = GetSignatureFileName(signature),
                    Content = signature.Raw,
                });
            }
            catch (ServerException ex) when (ex.Code.In(
                ServiceErrorCode.SimpleSignatureDisabled,
                ServiceErrorCode.SimpleSignatureRegulationNotAccepted,
                ServiceErrorCode.SimpleSignatureDocumentTypeNotAllowed,
                ServiceErrorCode.SimpleSignatureSnilsNotSpecified))
            {
                UserInput.Error(ex.Message);
            }
            catch (Exception ex)
            {
                UserInput.Error("При выполнении команды произошла ошибка");
                UserInput.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Выбрать подпись.
        /// </summary>
        /// <param name="document">Документ.</param>
        /// <returns>Подпись.</returns>
        private ISignature ChooseSignature(Document document)
            => ChooseSignature(
                document.Content,
                (DocumentType)(document.DocumentTypeEnum?.Code ?? (int)document.DocumentType),
                document.UntypedKind);

        /// <summary>
        /// Выбрать подпись.
        /// </summary>
        /// <param name="documentContent">Содержимое документа.</param>
        /// <param name="documentType">Тип документа.</param>
        /// <param name="untypedKind">Вид неформализованного документа.</param>
        /// <returns>Подпись.</returns>
        private ISignature ChooseSignature(byte[] documentContent, DocumentType documentType, string untypedKind = null)
            => ChooseSignature(documentContent, new DocumentTypeInfo
            {
                DocumentType = documentType.ToEnumValue(),
                UntypedKind = untypedKind,
            });

        /// <summary>
        /// Выбрать подпись.
        /// </summary>
        /// <param name="documentContent">Содержимое документа.</param>
        /// <param name="documentTypeInfo">Информация о типе документа.</param>
        /// <returns>Подпись.</returns>
        private ISignature ChooseSignature(byte[] documentContent = null, DocumentTypeInfo documentTypeInfo = null)
        {
            var userChoices = new[]
            {
                new UserInput.Option("1", "Усиленная ЭП", true),
                new UserInput.Option("2", "Простая ЭП", false)
            };

            do
            {
                byte[] signatureContent = null;
                var userChoice = UserInput.ChooseOption("Выберите тип подписи", userChoices);

                if (UserInput.ChooseYesNo("Загрузить подпись из файла", false))
                {
                    var filePath = UserInput.ReadParameter("Введите имя файла, содержащего подпись");
                    signatureContent = TryGetFileContent(filePath);

                    if (signatureContent == null)
                        continue;
                }

                switch (userChoice.Id)
                {
                    case "1":
                        var strongSignature =  signatureContent != null
                            ? new Sign { Raw = signatureContent }
                            : ChooseStrongSignature(documentContent);
                        strongSignature.From = _context.CurrentBox;
                        return strongSignature;

                    case "2":
                        var simpleSignature = signatureContent != null
                            ? new SimpleSignature { Raw = signatureContent }
                            : ChooseSimpleSignature(documentContent, documentTypeInfo);
                        simpleSignature.SenderBoxId = _context.CurrentBox;
                        return simpleSignature;
                }
            }
            while (true);
        }

        /// <summary>
        /// Выбрать усиленную ЭП.
        /// </summary>
        /// <param name="documentContent">Содержимое документа.</param>
        /// <param name="documentTypeInfo">Информация о типе документа.</param>
        /// <returns>Усиленная ЭП.</returns>
        private Sign ChooseStrongSignature(byte[] documentContent = null, DocumentTypeInfo documentTypeInfo = null)
        {
            if (_context.Certificate == null)
                ChooseAndSetContextCertificate();

            string documentId = string.Empty;

            if (documentContent == null)
            {
                documentId = UserInput.ReadParameter("Введите ИД документа");
                documentContent = _context.ServiceClient.GetDocumentContent(_context.CurrentBox, documentId);
            }

            var signatureContent = CryptoApiHelper.Sign(_context.Certificate, documentContent, true);

            return new Sign
            {
                Raw = signatureContent,
                From = _context.CurrentBox,
                DocumentId = documentId,
            };
        }

        /// <summary>
        /// Выбрать простую ЭП.
        /// </summary>
        /// <param name="documentContent">Содержимое документа.</param>
        /// <param name="documentTypeInfo">Информация о типе документа.</param>
        /// <returns>Простая ЭП.</returns>
        private SimpleSignature ChooseSimpleSignature(byte[] documentContent = null, DocumentTypeInfo documentTypeInfo = null)
        {
            var request = new SimpleSignatureCreationRequest();

            request.Comment = UserInput.ReadParameter("Введите комментарий к подписи");
            if (string.IsNullOrEmpty(request.Comment))
                request.Comment = null;

            var userChoices = new[]
            {
                new UserInput.Option("1", "По ИД документа из сервиса",true),
                new UserInput.Option("2", "По имени файла и типу", false)
            };

            do
            {
                var userChoice = documentContent == null
                    ? UserInput.ChooseOption("Выберите способ подписания документа", userChoices)
                    : userChoices[1];

                switch (userChoice.Id)
                {
                    case "1":
                        var documentId = UserInput.ReadParameter("Введите идентификатор документа");
                        request.Document = new SimpleSignatureCreationDocumentId
                        {
                            Id = documentId
                        };
                        break;

                    case "2":
                        if (documentContent == null)
                        {
                            var filePath = UserInput.ReadParameter("Введите имя файла");
                            documentContent = TryGetFileContent(filePath);

                            if (documentContent == null)
                                continue;
                        }

                        if (documentTypeInfo == null)
                            documentTypeInfo = ChooseDocumentTypeInfo("Выберите тип документа");

                        request.Document = new SimpleSignatureCreationDocumentData
                        {
                            Content = documentContent,
                            DocumentTypeInfo = documentTypeInfo,
                        };
                        break;
                }

                if (request.Document != null)
                    break;
            }
            while (true);

            var credentials = GetCurrentCredentials();
            var response = _context.ServiceClient.CreateSimpleSignature(credentials, request);
            return response.Signature;
        }

        /// <summary>
        /// Вывести информацию о простой подписи.
        /// </summary>
        /// <param name="signature">Простая подпись.</param>
        private void PrintSimpleSignatureInfo(SimpleSignature signature)
        {
            Console.Out.WriteLine($"ИД подписи: {signature.Id}");
            Console.Out.WriteLine($"ИД документа: {signature.DocumentId}");
            Console.Out.WriteLine($"Дата подписания: {signature.SignedAt}");
            Console.Out.WriteLine($"Версия подписи: {signature.Version}");

            PrintSimpleSignatureRequisites(signature.Requisites);

            Console.Out.WriteLine($"Хеш проверяемых атрибутов: {Convert.ToBase64String(signature.AttributesHash)}");
            Console.Out.WriteLine($"Хеш подписанного документа: {Convert.ToBase64String(signature.DocumentHash)}");
            Console.Out.WriteLine($"Код проверки подписи: {Convert.ToBase64String(signature.ValidationCode)}");
            Console.Out.WriteLine($"Статус валидности: {signature.IsValid}");
        }

        /// <summary>
        /// Вывести реквизиты простой ЭП.
        /// </summary>
        /// <param name="requisites">Реквизиты простой ЭП.</param>
        private void PrintSimpleSignatureRequisites(SimpleSignatureRequisites requisites)
        {
            var organization = requisites.Organization;
            Console.Out.WriteLine($"Наименования организации: {organization.Name}");
            Console.Out.WriteLine($"ИНН: {organization.Inn}");
            Console.Out.WriteLine($"КПП: {organization.Kpp}");
            Console.Out.WriteLine($"ОГРН: {organization.Ogrn}");
            Console.Out.WriteLine($"Сведения о государственной регистрации: {organization.StateRegistrationCert}");

            var employee = requisites.Employee;
            Console.Out.WriteLine($"Должность подписанта: {employee.Position}");
            Console.Out.WriteLine($"Email: {employee.Email}");
            Console.Out.WriteLine($"СНИЛС: {employee.Snils}");

            var fullName = employee.FullName;
            Console.Out.WriteLine($"ФИО: {fullName.FirstName} {fullName.MiddleName} {fullName.LastName}");

            Console.Out.WriteLine($"Комментарий к подписи: {requisites.Comment}");
        }

        /// <summary>
        /// Получить текущие учетные данные работника.
        /// </summary>
        /// <returns>Учетные данные работника.</returns>
        private EmployeeOperationCredentials GetCurrentCredentials()
            => new EmployeeOperationCredentials
            {
                AuthToken = _context.ServiceClient.Token,
                BoxAddress = _context.CurrentBox
            };

        /// <summary>
        /// Попытаться получить содержимое файла.
        /// </summary>
        /// <returns>Содержимое файла.</returns>
        private static byte[] TryGetFileContent(string filePath)
        {
            if (!Path.IsPathRooted(filePath))
                filePath = Path.Combine(Environment.CurrentDirectory, filePath);

            if (!File.Exists(filePath))
            {
                UserInput.Error("Файл не найден {0}", filePath);
                return null;
            }

            return FileHelper.GetFileContent(filePath);
        }

        /// <summary>
        /// Получить субъект подписи.
        /// </summary>
        /// <param name="signature">Подпись.</param>
        /// <returns>Субъект подписи.</returns>
        private static string GetSignatureSubject(ISignature signature)
        {
            if (signature is Sign)
                return (signature as Sign).Subject;

            var fullName = ((SimpleSignature)signature).Requisites.Employee.FullName;
            var subject = $"{fullName.LastName} {fullName.FirstName} {fullName.MiddleName}";
            return subject.Trim();
        }

        /// <summary>
        /// Получить имя файла подписи.
        /// </summary>
        /// <param name="signature">Подпись.</param>
        /// <returns>Имя файла подписи.</returns>
        private static string GetSignatureFileName(ISignature signature)
        {
            var subject = GetSignatureSubject(signature);
            var extension = signature is Sign ? ".sig" : ".xml";
            return subject + extension;
        }

        /// <summary>
        /// Создать модель титула покупателя ДПТ.
        /// </summary>
        /// <returns>Модель титула покупателя ДПТ.</returns>
        private static GoodsTransferBuyer CreateGoodsTransferBuyer()
            => new GoodsTransferBuyer
            {
                GoodsAcceptanceInfo = new AcceptanceInfo
                {
                    Description = "Содержание операции",
                },
                Drafter = new Drafter
                {
                    OrganizationName = "Наименование экономического субъекта",
                },
                Signers = CreateTransferDocumentSigners(),
            };

        /// <summary>
        /// Создать модель титула покупателя ДПРР.
        /// </summary>
        /// <returns>Модель титула покупателя ДПРР.</returns>
        private static WorksTransferBuyer CreateWorksTransferBuyer()
            => new WorksTransferBuyer
            {
                WorksAcceptanceInfo = new AcceptanceInfo
                {
                    Description = "Содержание операции",
                },
                Drafter = new Drafter
                {
                    OrganizationName = "Наименование экономического субъекта",
                },
                Signers = CreateTransferDocumentSigners(),
            };

        /// <summary>
        /// Создать модель титула покупателя УПД.
        /// </summary>
        /// <returns>Модель титула покупателя УПД.</returns>
        private static GeneralTransferBuyer CreateGeneralTransferBuyer()
            => new GeneralTransferBuyer
            {
                GoodsAcceptanceInfo = new AcceptanceInfo
                {
                    Description = "Содержание операции",
                },
                Drafter = new Drafter
                {
                    OrganizationName = "Наименование экономического субъекта",
                },
                Signers = CreateTransferDocumentSigners(),
            };

        /// <summary>
        /// Создать модель титула покупателя УКД.
        /// </summary>
        /// <returns>Модель титула покупателя УКД.</returns>
        private static GeneralTransferCorrectionBuyer CreateGeneralTransferCorrectionBuyer()
            => new GeneralTransferCorrectionBuyer
            {
                ApprovalInfo = new ApprovalInfo
                {
                    Description = "Содержание операции",
                },
                Drafter = new Drafter
                {
                    OrganizationName = "Наименование экономического субъекта",
                },
                Signers = CreateTransferDocumentSigners(),
            };

        /// <summary>
        /// Создать список подписантов для документов ДПТ, ДПРР, УПД и УКД.
        /// </summary>
        /// <returns>Список подписантов.</returns>
        private static Signer[] CreateTransferDocumentSigners()
            => new[]
            {
                // TODO: Добавить ввод этих значений или взятие их из текущей организации.
                new Signer
                {
                    Inn = "1234567890",
                    Position = "Директор",
                    AuthorityBase = "Основание полномочий",
                    OrganizationName = "ООО Нефтепродукт",
                    FullName = new FullName
                    {
                        LastName = "Иванов",
                        FirstName = "Иван",
                    },
                    OrganizationType = new EnumValue
                    {
                        Code = 1,
                    },
                    AuthorityArea = new EnumValue
                    {
                        Code = 1,
                    },
                    SignerType = new EnumValue
                    {
                        Code = 1,
                    },
                },
            };

        /// <summary>
        /// Создать модель титула водителя (прием груза) транспортной накладной.
        /// </summary>
        /// <returns>Модель титула водителя (прием груза) транспортной накладной.</returns>
        private static TransportWaybillCargoReceivedTitle CreateTransportWaybillCargoReceivedTitle()
            => new TransportWaybillCargoReceivedTitle
            {
                FormatVersion = EnumHelper.ToEnumValue(TransportWaybillCargoReceivedTitleFormatVersion.V100),
            };

        /// <summary>
        /// Создать модель титула водителя (сдача груза) транспортной накладной.
        /// </summary>
        /// <returns>Модель титула водителя (сдача груза) транспортной накладной.</returns>
        private static TransportWaybillCargoDeliveredTitle CreateTransportWaybillCargoDeliveredTitle()
            => new TransportWaybillCargoDeliveredTitle
            {
                FormatVersion = EnumHelper.ToEnumValue(TransportWaybillCargoDeliveredTitleFormatVersion.V100),
            };

        /// <summary>
        /// Создать модель титула грузополучателя транспортной накладной.
        /// </summary>
        /// <returns>Модель титула грузополучателя транспортной накладной.</returns>
        private static TransportWaybillConsigneeTitle CreateTransportWaybillConsigneeTitle()
            => new TransportWaybillConsigneeTitle
            {
                FormatVersion = EnumHelper.ToEnumValue(TransportWaybillConsigneeTitleFormatVersion.V100),
            };

        /// <summary>
        /// Создать модель титула перевозчика транспортной накладной.
        /// </summary>
        /// <returns>Модель титула перевозчика транспортной накладной.</returns>
        private static TransportWaybillCarrierTitle CreateTransportWaybillCarrierTitle()
            => new TransportWaybillCarrierTitle
            {
                FormatVersion = EnumHelper.ToEnumValue(TransportWaybillCarrierTitleFormatVersion.V100),
            };

        /// <summary>
        /// Создать модель титула изменения места доставки транспортной накладной.
        /// </summary>
        /// <returns>Модель титула изменения места доставки транспортной накладной.</returns>
        private static TransportWaybillDeliveryPlaceChangeTitle CreateTransportWaybillDeliveryPlaceChangeTitle()
            => new TransportWaybillDeliveryPlaceChangeTitle
            {
                FormatVersion = EnumHelper.ToEnumValue(TransportWaybillDeliveryPlaceChangeTitleFormatVersion.V100),
            };
    }
}
