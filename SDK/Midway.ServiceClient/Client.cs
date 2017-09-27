using System;
using System.Linq;
using System.ServiceModel;
using Midway.ObjectModel;
using Midway.ObjectModel.Common;
using Midway.ServiceClient.Model;

namespace Midway.ServiceClient
{
    /// <summary>
    /// Класс клиент для вызова методов сервиса обмена.
    /// 
    /// Исключения которые могут генерировать методы сервиса:
    /// ServerException - ошибка сервера
    /// InvalidOperationException - ошибка обработки ответа сервиса
    /// TimeoutException - ошибка таймаута подключения или ответа сервиса
    /// CommunicationException  - ошибка на уровне транспорта
    /// </summary>
    public class Client : BaseClient, IExchangeServiceClient
    {
        private readonly string serviceUrl;
        private readonly ExchangeServiceClient client;
        private static PerformanceCounterInterceptorInserter performanceCounterInterceptorInserter;
        
        public System.ServiceModel.Description.ServiceEndpoint Endpoint
        {
            get { return client.Endpoint; }
        }

        protected static PerformanceCounterInterceptorInserter GetPerformanceCounterInterceptorInserter(string[] operations)
        {
            if (performanceCounterInterceptorInserter == null)
            {
                lock (typeof(PerformanceCounterInterceptorInserter))
                {
                    if (performanceCounterInterceptorInserter == null)
                        performanceCounterInterceptorInserter = new PerformanceCounterInterceptorInserter(operations);
                }
            }

            return performanceCounterInterceptorInserter;
        }

        public static void ResetPerformanceCounters()
        {
            var operations = (new ExchangeServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost/stub.asmx"))).Endpoint.Contract.Operations.Select(op => op.Name).ToArray();
            GetPerformanceCounterInterceptorInserter(operations).performanceCounterInterceptor.ResetPerformanceCounters();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceUrl">адрес веб-сервиса</param>
        public Client(string serviceUrl)
            : this(serviceUrl, false, false)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceUrl">адрес веб-сервиса</param>
        /// <param name="enableTracing">включить счетчики производительнтсти</param>
        /// <param name="useStreamRequest">использовать потоковую передачу данных</param>
        /// <param name="configEndpointName">использовать другое имя конечной точки при конфига</param>
        public Client(string serviceUrl, bool enableTracing, bool useStreamRequest, string configEndpointName = "WSHttpBinding_IExchangeService")
        {
            if (serviceUrl == null)
                throw new ArgumentNullException();
            this.serviceUrl = serviceUrl;
            this.client = new ExchangeServiceClient(configEndpointName, serviceUrl);
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="serviceUrl">адрес веб-сервиса</param>
        /// <param name="enableTracing">включить счетчики производительнтсти</param>
        /// <param name="useStreamRequest">использовать потоковую передачу данных</param>
        ///  <param name="applicationVersionValue">Приложение-версия которые будут вставлены в заголовок</param>
        /// <param name="configEndpointName">использовать другое имя конечной точки при конфига</param>
        public Client(string serviceUrl, bool enableTracing, bool useStreamRequest, string applicationVersionValue, string configEndpointName = "WSHttpBinding_IExchangeService")
        {
            if (serviceUrl == null)
                throw new ArgumentNullException();
            this.serviceUrl = serviceUrl;
            this.client = new ExchangeServiceClient(configEndpointName, serviceUrl);
            client.Endpoint.Behaviors.Add(new ApplicationVersionEndpointBehavior(applicationVersionValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceUrl">игнорируется, оставлен чтобы не было совпадения сигнатуры</param>
        /// <param name="configSectionName">название секции конфига, откуда необходимо взять настройки</param>
        public Client(string serviceUrl, string configSectionName)
        {
            this.client = new ExchangeServiceClient(configSectionName);
            this.serviceUrl = this.client.Endpoint.Address.Uri.OriginalString;
        }
        
        /// <summary>
        /// Получение токена при авторизации по паролю
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        public bool Authenticate(string login, string password, string applicationId = null)
        {
            var token = client.Authenticate(login, password, applicationId);
            TakeToken(token);

            return IsAuthorized;
        }

        /// <summary>
        /// Получение токена при авторизации по сертификату
        /// </summary>
        /// <param name="certHash">отпечаток сертификата</param>
        public bool AuthenticateWithCertificate(string certHash, string applicationId = null)
        {
            var encryptedToken = client.AuthenticateWithCertificate(certHash, applicationId);
            if (encryptedToken == null)
                return false;
            EncryptedToken = encryptedToken;
            var token = Crypto.CryptoApiHelper.Decrypt(Convert.FromBase64String(encryptedToken));
            var tokenId = new Guid(token).ToString();
            TakeToken(tokenId);
            if (!IsAuthorized)
                return false;
            return true;
        }

        public bool OrganizationStructureHasSingleElement(string organizationId)
        {
            return CheckAutorizedInvoke(() => client.OrganizationStructureHasSingleElement(Token, organizationId));
        }

        public OrganizationStructureElement[] GetOrganizationStructureElementChildren(string organizationId,
                                                                                      string orgStructureElementId)
        {
            return CheckAutorizedInvoke(() => client.GetOrganizationStructureElementChildren(Token, organizationId, orgStructureElementId));
        }

        /// <summary>
        /// Получение токена при авторизации по сертификату
        /// </summary>
        /// <param name="certHash">отпечаток сертификата</param>
        public string GetEncryptedToken(string certHash, string applicationId = null)
        {
            return Invoke(() => client.AuthenticateWithCertificate(certHash, applicationId));
        }

        public IAsyncResult BeginAuthenticate(string login, string password, string applicationId, AsyncCallback asyncCallback)
        {
            return client.BeginAuthenticate(login, password, applicationId, asyncCallback, null);
        }

        public string EndAuthenticate(IAsyncResult asyncResult)
        {
            TakeToken(EndInvoke(client.EndAuthenticate, asyncResult));
            return Token;
        }

        /// <summary>
        /// Возвращает список доступных ящиков пользователя
        /// </summary>
        public BoxInfo[] GetBoxes()
        {
            return CheckAutorizedInvoke(() => client.GetBoxes(Token));
        }

        public IAsyncResult BeginGetBoxes(AsyncCallback asyncCallback)
        {
            var result = client.BeginGetBoxes(Token, asyncCallback, null);
            return result;
        }

        public BoxInfo[] EndGetBoxes(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGetBoxes, asyncResult);
        }

        /// <summary>
        /// Получить список сообщений из ящика
        /// </summary>
        /// <param name="afterMessageId">последнее полученное сообщение</param>
        /// <param name="fromBox">ящик отправителя</param>
        /// <param name="toBox">ящик получателя</param>
        public MessageInfo[] GetMessages(string afterMessageId, string fromBox, string toBox)
        {
            return CheckAutorizedInvoke(() => client.GetMessages(Token, afterMessageId, fromBox, toBox));
        }

        public IAsyncResult BeginGetMessages(string afterMessageId, string fromBox, string toBox, AsyncCallback asyncCallback)
        {
            CheckAutorized();
            var result = client.BeginGetMessages(Token, afterMessageId, fromBox, toBox, asyncCallback, null);
            return result;
        }

        public MessageInfo[] EndGetMessages(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGetMessages, asyncResult);
        }

        /// <summary>
        /// Возвращает информацию по сообщению
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="messageId">ID сообщения</param>
        public Message GetMessage(string boxId, string messageId)
        {
            return CheckAutorizedInvoke(() => client.GetMessage(Token, boxId, messageId));
        }

        public IAsyncResult BeginGetMessage(string boxId, string messageId, AsyncCallback asyncCallback)
        {
            return client.BeginGetMessage(Token, boxId, messageId, asyncCallback, null);
        }

        public Message EndGetMessage(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGetMessage, asyncResult);
        }

        /// <summary>
        /// Возвращает информацию по сообщению c возможностью не загружать контент подписей и документов
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="messageId">ID сообщения</param>
        /// <param name="requestParams">Параметры загружки сообщения</param>
        public Message GetMessageWithLoadOptions(string boxId, string messageId, MessageRequestParams requestParams)
        {
            return CheckAutorizedInvoke(() => client.GetMessageWithLoadOptions(Token, boxId, messageId, requestParams));
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns>возвращает результат отправки</returns>
        public virtual SentMessage SendMessage(Message message)
        {
            return CheckAutorizedInvoke(() => client.SendMessage(Token, message));
        }

        public IAsyncResult BeginSendMessage(Message message, AsyncCallback asyncCallback)
        {
            return client.BeginSendMessage(Token, message, asyncCallback, null);
        }

        public SentMessage EndSendMessage(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndSendMessage, asyncResult);
        }


        #region Черновики

        public string CreateDraftMessage(DraftMessage draftMessage)
        {
            return CheckAutorizedInvoke(() => client.CreateDraftMessage(Token, draftMessage));
        }

        public void UpdateDraftMessage(DraftMessage draftMessage)
        {
            CheckAutorizedInvoke(() =>
                {
                    client.UpdateDraftMessage(Token, draftMessage);
                    return true;
                });
        }

        public void DeleteDraftMessage(string messageId)
        {
            CheckAutorizedInvoke(() =>
                {
                    client.DeleteDraftMessage(Token, messageId);
                    return true;
                });
        }

        public DraftMessage GetDraftMessage(string messageId, bool getContent, bool getCard)
        {
            return CheckAutorizedInvoke(() => client.GetDraftMessage(Token, messageId, getContent, getCard));
        }

        public DraftMessageSearchResult GetDraftMessageList(FetchingSettings settings, string boxId)
        {
            return CheckAutorizedInvoke(() => client.GetDraftMessageList(Token, boxId, settings));
        }

//        public DraftMessageSearchResult SearchDraftMessages(SearchSettings settings, string boxId)
//        {
//            return CheckAutorizedInvoke(() => client.SearchDraftMessages(Token, boxId, settings));
//        }

        public int GetDraftMessageCount(string boxId)
        {
            return CheckAutorizedInvoke(() => client.GetDraftMessageCount(Token, boxId));
        }

        public byte[] GetDraftDocumentContent(string draftDocumentId)
        {
            return CheckAutorizedInvoke(() => client.GetDraftDocumentContent(Token, draftDocumentId));
        }

        public byte[] GetDraftDocumentCard(string draftDocumentId)
        {
            return CheckAutorizedInvoke(() => client.GetDraftDocumentCard(Token, draftDocumentId));
        }
        
        #endregion Черновики


        /// <summary>
        /// Генерирует уведомление о получении документа (регламент ЭСФ)
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор документа</param>
        /// <returns>контент документа-уведомления</returns>
        public NamedContent GenerateInvoiceReceipt(string boxId, string documentId)
        {
            return CheckAutorizedInvoke(() => client.GenerateInvoiceReceipt(Token, boxId, documentId));
        }
        public IAsyncResult BeginGenerateInvoiceReceipt(string boxId, string documentId, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateInvoiceReceipt(Token, boxId, documentId, asyncCallback, null);
        }
        public NamedContent EndGenerateInvoiceReceipt(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateInvoiceReceipt, asyncResult);
        }

        /// <summary>
        /// Генерирует уведомление о получении документа (регламент ЭСФ)
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор документа</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns>контент документа-уведомления</returns>
        public NamedContent GenerateInvoiceReceiptV2(string boxId, string documentId, string certThumbprint)
        {
            return CheckAutorizedInvoke(() => client.GenerateInvoiceReceiptV2(Token, boxId, documentId, certThumbprint));
        }
        public IAsyncResult BeginGenerateInvoiceReceiptV2(string boxId, string documentId, string certThumbprint, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateInvoiceReceiptV2(Token, boxId, documentId, certThumbprint, asyncCallback, null);
        }
        public NamedContent EndGenerateInvoiceReceiptV2(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateInvoiceReceiptV2, asyncResult);
        }


        /// <summary>
        /// Генерирует ИОП
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <returns>контент документа коррекции</returns>
        public NamedContent GenerateDeliveryConfirmation(string boxId, string documentId)
        {
            return CheckAutorizedInvoke(() => client.GenerateDeliveryConfirmation(Token, boxId, documentId));            
        }
        public IAsyncResult BeginGenerateDeliveryConfirmation(string boxId, string documentId, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateDeliveryConfirmation(Token, boxId, documentId, asyncCallback, null);            
        }
        public NamedContent EndGenerateDeliveryConfirmation(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateDeliveryConfirmation, asyncResult);            
        }

        /// <summary>
        /// Генерирует ИОП
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns>контент документа коррекции</returns>
        public NamedContent GenerateDeliveryConfirmationV2(string boxId, string documentId, string certThumbprint)
        {
            return CheckAutorizedInvoke(() => client.GenerateDeliveryConfirmationV2(Token, boxId, documentId, certThumbprint));
        }
        public IAsyncResult BeginGenerateDeliveryConfirmationV2(string boxId, string documentId, string certThumbprint, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateDeliveryConfirmationV2(Token, boxId, documentId, certThumbprint, asyncCallback, null);
        }
        public NamedContent EndGenerateDeliveryConfirmationV2(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateDeliveryConfirmationV2, asyncResult);
        }

        /// <summary>
        /// Генерирует УОУ для ЭСФ
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <returns>контент документа коррекции</returns>
        public NamedContent GenerateInvoiceAmendmentRequest(string boxId, string documentId, string text)
        {
            return CheckAutorizedInvoke(() => client.GenerateInvoiceAmendmentRequest(Token, boxId, documentId, text));            
        }
        public IAsyncResult BeginGenerateInvoiceAmendmentRequest(string boxId, string documentId, string text, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateInvoiceAmendmentRequest(Token, boxId, documentId, text, asyncCallback, null);            
        }
        public NamedContent EndGenerateInvoiceAmendmentRequest(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateInvoiceAmendmentRequest, asyncResult);            
        }

        /// <summary>
        /// Генерирует УОУ для ЭСФ
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns>контент документа коррекции</returns>
        public NamedContent GenerateInvoiceAmendmentRequestV2(string boxId, string documentId, string certThumbprint, string text)
        {
            return CheckAutorizedInvoke(() => client.GenerateInvoiceAmendmentRequestV2(Token, boxId, documentId, certThumbprint, text));
        }
        public IAsyncResult BeginGenerateInvoiceAmendmentRequestV2(string boxId, string documentId, string certThumbprint, string text, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateInvoiceAmendmentRequestV2(Token, boxId, documentId, certThumbprint, text, asyncCallback, null);
        }
        public NamedContent EndGenerateInvoiceAmendmentRequestV2(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateInvoiceAmendmentRequestV2, asyncResult);
        }

        /// <summary>
        /// Генерирует УОУ
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <returns>контент документа коррекции</returns>
        public NamedContent GenerateAmendmentRequest(string boxId, string documentId, string text)
        {
            return CheckAutorizedInvoke(() => client.GenerateAmendmentRequest(Token, boxId, documentId, text));            
        }
        public IAsyncResult BeginGenerateAmendmentRequest(string boxId, string documentId, string text, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateAmendmentRequest(Token, boxId, documentId, text, asyncCallback, null);            
        }
        public NamedContent EndGenerateAmendmentRequest(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateAmendmentRequest, asyncResult);            
        }


        /// <summary>
        /// Генерирует УОУ
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns>контент документа коррекции</returns>
        public NamedContent GenerateAmendmentRequestV2(string boxId, string documentId, string certThumbprint, string text)
        {
            return CheckAutorizedInvoke(() => client.GenerateAmendmentRequestV2(Token, boxId, documentId, certThumbprint, text));
        }
        public IAsyncResult BeginGenerateAmendmentRequestV2(string boxId, string documentId, string certThumbprint, string text, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateAmendmentRequestV2(Token, boxId, documentId, text, certThumbprint, asyncCallback, null);
        }
        public NamedContent EndGenerateAmendmentRequestV2(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateAmendmentRequestV2, asyncResult);
        }

        /// <summary>
        /// Генерирует титул покупателя (заказчика)
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор документа</param>
        /// <returns></returns>
        public NamedContent GenerateTitleBuyer(string boxId, string documentId, TitleBuyer text)
        {
            return CheckAutorizedInvoke(() => client.GenerateTitleBuyer(Token, boxId, documentId, text, null));
        }
        public IAsyncResult BeginGenerateTitleBuyer(string boxId, string documentId, TitleBuyer text, AsyncCallback asyncCallback)
        {
            return client.BeginGenerateTitleBuyer(Token, boxId, documentId, text, null, asyncCallback, null);
        }
        public NamedContent EndGenerateTitleBuyer(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGenerateTitleBuyer, asyncResult);
        }
        
        /// <summary>
        /// Получить содержимое документа
        /// </summary>
        /// <param name="boxId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public byte[] GetDocumentContent(string boxId, string documentId)
        {
            return CheckAutorizedInvoke(() => client.GetDocumentContent(Token, boxId, documentId));            
        }

        public IAsyncResult BeginGetDocumentContent(string boxId, string documentId, AsyncCallback asyncCallback)
        {
            return client.BeginGetDocumentContent(Token, boxId, documentId, asyncCallback, null);
        }
        
        public byte[] EndGetDocumentContent(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGetDocumentContent, asyncResult);            
        }

        public DocumentList GetDocumentList(DocumentListOptions options)
        {
            return CheckAutorizedInvoke(() => client.GetDocumentList(Token, options));
        }

        /// <summary>
        /// Получить полную информацию о документе
        /// </summary>
        /// <returns></returns>
        public FullDocumentInfo GetFullDocumentInfo(string boxId, string documentId, FullDocumentInfoRequestParams requestParams = null)
        {
            return CheckAutorizedInvoke(() => client.GetFullDocumentInfo(Token, boxId, documentId, requestParams));
        }

        public IAsyncResult BeginGetFullDocumentInfo(string boxId, string documentId, FullDocumentInfoRequestParams requestParams, AsyncCallback asyncCallback)
        {
            return client.BeginGetFullDocumentInfo(Token, boxId, documentId, requestParams, asyncCallback, null);
        }

        public FullDocumentInfo EndGetFullDocumentInfo(IAsyncResult asyncResult)
        {
            return EndInvoke(client.EndGetFullDocumentInfo, asyncResult);
        }

        /// <summary>
        /// Возвращает ИНН, КПП и наименование организации
        /// </summary>
        /// <param name="boxId">ящик</param>
        public InnKppName GetInnKppNameByBoxId(string boxId)
        {
            return CheckAutorizedInvoke(() => client.GetInnKppNameByBoxId(Token, boxId));
        }

        /// <summary>
        /// Поиск контрагентов
        /// </summary>
        /// <param name="contactSearchOptions">параметры поиска контакта</param>
        /// <returns>результат поиска, возвращает общее число и информацию по контрагентам</returns>
        public ContactSearchResult SearchContacts(ContactSearchOptions contactSearchOptions)
        {
            return CheckAutorizedInvoke(() => client.SearchContacts(Token, contactSearchOptions));
        }

        /// <summary>
        /// Возвращает информацию по контрагенту
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        public Contact GetContact(int organizationId, int contragentId)
        {
            return CheckAutorizedInvoke(() => client.GetContact(Token, organizationId, contragentId));
        }

        /// <summary>
        /// Установить отношения по обмену с контрагентом
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        public ContactStatus AcceptAuthorization(int organizationId, int contragentId, string comment)
        {
            return CheckAutorizedInvoke(() => client.AcceptAuthorization(Token, organizationId, contragentId, comment));
        }

        /// <summary>
        /// Прекратить отношения по обмену с контрагентом
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        public ContactStatus RejectAuthorization(int organizationId, int contragentId, string comment)
        {
            return CheckAutorizedInvoke(() => client.RejectAuthorization(Token, organizationId, contragentId, comment));
        }

        /// <summary>
        /// Запрос авторизации
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        public void SendAuthRequest(int organizationId, int contragentId, string comment)
        {
            CheckAutorizedInvoke(() => 
            { 
                client.SendAuthRequest(Token, organizationId, contragentId, comment);
                return true;
            });
        }

        /// <summary>
        /// Отмена авторизации
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        public void CancelAuthRequest(int organizationId, int contragentId, string comment)
        {
            CheckAutorizedInvoke(() =>
            {
                client.CancelAuthRequest(Token, organizationId, contragentId, comment);
                return true;
            });
        }

        /// <summary>
        /// Подтверждение авторизации
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        public void AcceptAuthRequest(int organizationId, int contragentId, string comment)
        {
            CheckAutorizedInvoke(() =>
            {
                client.AcceptAuthRequest(Token, organizationId, contragentId, comment);
                return true;
            });
        }

        /// <summary>
        /// Отклонение авторизации
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        public void RejectAuthRequest(int organizationId, int contragentId, string comment)
        {
            CheckAutorizedInvoke(() =>
            {
                client.RejectAuthRequest(Token, organizationId, contragentId, comment);
                return true;
            });
        }

        /// <summary>
        /// Удаление контрагента из списка активных
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        public void DeleteContact(int organizationId, int contragentId, string comment)
        {
            CheckAutorizedInvoke(() =>
            {
                client.DeleteContact(Token, organizationId, contragentId, comment);
                return true;
            });
        }

        /// <summary>
        /// Получение информации об организации по ИНН/КПП
        /// </summary>
        /// <param name="inn"></param>
        /// <param name="kpp"></param>
        public Organization GetOrganizationByInnKpp(string inn, string kpp)
        {
            return CheckAutorizedInvoke(() => client.GetOrganizationByInnKpp(Token, inn, kpp));
        }

        /// <summary>
        /// Получение информации об организации
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="criteria">критерии для выборки информации по организации</param>
        /// <param name="values">параметры поиска по критерию</param>
        public Organization GetOrganizationBy(string boxId, OrganizationByCriteria criteria, OrganizationByCriteriaValues values)
        {
            return CheckAutorizedInvoke(() => client.GetOrganizationBy(Token, boxId, criteria, values));
        }

        /// <summary>
        /// Возвращает информацию о субъекте документооборота
        /// </summary>
        /// <param name="subjectBoxId"> </param>
        /// <returns></returns>
        public SubjectInfo GetSubjectInfo(string subjectBoxId)
        {
            return CheckAutorizedInvoke(() => client.GetSubjectInfo(Token, subjectBoxId));
        }

        /// <summary>
        /// Возвращает информацию о субъекте документооборота (спецоператоре)
        /// </summary>
        /// <returns></returns>
        public SubjectInfo GetSpecialOperatorInfo()
        {
            return CheckAutorizedInvoke(() => client.GetSpecialOperatorInfo(Token));
        }

        /// <summary>
        /// Добавляет подразделение в орг. структуру
        /// </summary>
        /// <param name="element">Подразделение</param>
        public string AddOrganizationStructureElement(OrganizationStructureElement element)
        {
            return CheckAutorizedInvoke(() => client.AddOrganizationStructureElement(Token, element));
        }

        /// <summary>
        /// Удаляет подразделение из организационной структуры
        /// </summary>
        /// <param name="elementId">Идентификатор подразделения</param>
        public void DeleteOrganizationStructureElement(string organizationId, string elementId)
        {
            CheckAutorizedInvoke(() =>
            {
                client.DeleteOrganizationStructureElement(Token, organizationId, elementId);
                return true;
            });
        }

        /// <summary>
        /// Изменение данных о подразделении
        /// </summary>
        /// <param name="element">Подразделение</param>
        public void ModifyOrganizationStructureElement(OrganizationStructureElement element)
        {
            CheckAutorizedInvoke(() =>
            {
                client.ModifyOrganizationStructureElement(Token, element);
                return true;
            });
        }

        /// <summary>
        /// Возвращает данные об организационной структуре
        /// </summary>
        /// <param name="organizationId">идентификатор организации</param>
        /// <returns>массив элементов орг. структуры</returns>
        public OrganizationStructureElement[] GetOrganizationStructure(string boxId, string organizationId)
        {
            return CheckAutorizedInvoke(() => client.GetOrganizationStructure(Token, boxId, organizationId));
        }

        /// <summary>
        /// Проверяет можно ли с помощью указанного сертификата отправлять легитимные ЭСФ
        /// </summary>
        /// <param name="certHash"></param>
        /// <returns></returns>
        private bool CanSendInvoice(string certHash)
        {
            return CheckAutorizedInvoke(() => client.CanSendInvoice(Token, certHash));
        }

        /// <summary>
        /// Проверка квалифицированного сертификата
        /// </summary>
        /// <param name="certificate">сертификат в DER-кодировке</param>
        /// <returns>Результат проверки сертификата</returns>
        public CertificateValidationResult CheckQualifiedCertificate(byte[] certificate)
        {
            return Invoke(() => client.CheckQualifiedCertificate(certificate));
        }

        /// <summary>
        /// Возвращает список сертификатов ассоциированных с ящиками
        /// </summary>
        public BoxCertificate[] GetBoxCertificates()
        {
            return CheckAutorizedInvoke(() => client.GetBoxCertificates(Token));
        }

        /// <summary>
        /// Получение списка служебных документов, которые необходимо подписать и отправить
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns></returns>
        public ServiceNotice[] GetRequiredNotices(string boxId, string certThumbprint = null)
        {
            return CheckAutorizedInvoke(() => client.GetRequiredNotices(Token, boxId, certThumbprint));
        }

        /// <summary>
        /// Получение усовершенствованной подписи
        /// по оригинальной
        /// </summary>
        /// <param name="boxId">Идентификатор ящика организации</param>
        /// <param name="sign">Подпись, на которую необходимо получить усовершенствованную</param>
        /// <returns>Усовершенствованная подпись</returns>
        public ObjectModel.EnhancedSign GetEnhancedSign(string boxId, byte[] sign)
        {
            return CheckAutorizedInvoke(() => client.GetEnhancedSign(Token, boxId, sign));
        }

        /// <summary>
        /// Получение усовершенствованной подписи
        /// по идентификатору
        /// </summary>
        /// <param name="boxId">Идентификатор ящика организации</param>
        /// <param name="signId">Идентификатор подписи</param>
        /// <returns>Усовершенствованная подпись</returns>
        public ObjectModel.EnhancedSign GetEnhancedSignById(string boxId, string signId)
        {
            return CheckAutorizedInvoke(() => client.GetEnhancedSignById(Token, boxId, signId));
        }

        /// <summary>
        /// Возвращает zip-архив со всей цепочкой документооборота
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public NamedContent DownloadDocumentFlowArchive(string boxId, string documentId)
        {
            return CheckAutorizedInvoke(() => client.DownloadDocumentFlowArchive(Token, boxId, documentId));
        }

        /// <summary>
        /// Получить все организации по указанному ИНН (+ КПП).
        /// В случае поиска ИП, ФЛ или организации со списком филиалов - КПП не указывается.
        /// </summary>
        /// <param name="inn"></param>
        /// <param name="kpp"></param>
        /// <returns>Внимание! Возможен возврат одной и той же организации в нескольких записях, 
        /// если она зарегистрирована сразу у нескольких операторов</returns>
        public Organization[] GetOrganizationListByInnKpp(string inn, string kpp = null)
        {
            return CheckAutorizedInvoke(() => client.GetOrganizationListByInnKpp(Token, inn, kpp));
        }

        /// <summary>
        /// Проверить список отпечатков на возможность авторизации в сервисе.
        /// Возвращает список отпечатков сертификатов, по которым возможна авторизация.
        /// </summary>
        /// <param name="thumbprints"></param>
        public string[] CheckCertificates(string[] thumbprints)
        {
            return Invoke(() => client.CheckCertificates(thumbprints));
        }

        /// <summary>
        /// Получение информации о пользователе
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public User GetUserInfo(string boxId)
        {
            return CheckAutorizedInvoke(() => client.GetUserInfo(Token, boxId));
        }

        /// <summary>
        /// Регистрация пользователя из внешних систем
        /// </summary>
        /// <param name="registerModel"> Информация о регистрируемом пользователе </param>
        /// <param name="certificate">Сертификат</param>
        /// <returns>Информация о зарегистрированном пользователе</returns>
        public RegisterResult Register(RegisterModel registerModel, byte[] certificate = null)
        {
            return Invoke(() => client.Register(registerModel, certificate));
        }

        /// <summary>
        /// Принятие правил работы в Synerdocs организацией
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="acceptRegulation">Признак принятия регламента организацией</param>
        /// <returns>Возвращает true, если правила работы в Synerdocs приняты, иначе вернёт false</returns>
        public bool AcceptRegulation(string boxId, bool acceptRegulation)
        {
            return Invoke(() => client.AcceptRegulation(Token, boxId, acceptRegulation));
        }

        /// <summary>
        /// Проверяет наличие у контрагента действующих квалифицированных сертификатов
        /// </summary>
        /// <param name="contragentBoxId">Ящик контрагента</param>
        /// <returns>
        /// Возвращает true если у контрагента есть хотя бы один действующий квалифицированный сертификат , иначе вернет false
        /// </returns>
        public bool HasQualifiedCertificate(string contragentBoxId)
        {
            return CheckAutorizedInvoke(() => client.HasQualifiedCertificate(Token, contragentBoxId));
        }

        /// <summary>
        /// Отправляет сообщение с документами без подписи
        /// </summary>
        /// <param name="message">сообщение с документами без подписи</param>
        /// <returns>Отправленное сообщение</returns>
        public SentMessage SendUnsignedMessage(UnsignedMessage message)
        {
            return CheckAutorizedInvoke(() => client.SendUnsignedMessage(Token, message));
        }

        /// <summary>
        /// Отправляет сообщение с пересылаемыми документами
        /// </summary>
        /// <param name="message">Сообщение с пересылаемыми документами</param>
        /// <returns>Отправленное сообщение</returns>
        public SentMessage SendForwardMessage(ForwardMessage message)
        {
            return CheckAutorizedInvoke(() => client.SendForwardMessage(Token, message));
        }
        
        public void SignDocument(FlowType flowType, Sign signature)
        {
            CheckAutorizedInvoke(() => 
            {
                client.SignDocument(Token, flowType, signature);
                return true;
            });
        }
        
        public void SignDocumentWithSimpleSignature(FlowType flowType, SimpleSignature signature)
        {
            CheckAutorizedInvoke(() =>
            {
                client.SignDocumentWithSimpleSignature(Token, flowType, signature);
                return true;
            });
        }

        /// <summary>
        /// Отказывает в подписании документа, отправленного ранее (для пересланных и документов без подписи)
        /// </summary>
        /// <param name="flowType">Тип документооборота</param>
        /// <param name="rejectSign">Отказ от подписания</param>
        public void RejectSign(FlowType flowType, RejectSign rejectSign)
        {
            CheckAutorizedInvoke(() => 
            {
                client.RejectSign(Token, flowType, rejectSign);
                return true;
            });
        }

        /// <summary>
        /// Получить список вхождений документов
        /// </summary>
        /// <param name="options">параметры поиска/фильтрации вхождений документов</param>
        /// <returns>Cписок вхождений документов</returns>
        public DocumentEntryList GetDocumentEntries(DocumentEntryOptions options)
        {
            return CheckAutorizedInvoke(() => client.GetDocumentEntries(Token, options));
        }

        /// <summary>
        /// Получить полную информацию о документе
        /// включая информацию документооборотам и вхождениям
        /// </summary>
        /// <returns>Полную информация о документе</returns>
        public FlowDocumentInfo GetFlowDocumentInfo(
            string boxId,
            string documentId,
            FlowDocumentInfoRequestParams requestParams = null)
        {
            return CheckAutorizedInvoke(() => client.GetFlowDocumentInfo(Token, boxId, documentId, requestParams));
        }

        /// <summary>
        /// Отправляет сообщение с внутренними документами
        /// </summary>
        /// <param name="message">Сообщение с внутренними документами</param>
        /// <returns>Отправленное сообщение</returns>
        public SentMessage SendInternalMessage(InternalMessage message)
        {
            return CheckAutorizedInvoke(() => client.SendInternalMessage(Token, message));
        }

        /// <summary>
        /// Получить список внутренних документов
        /// </summary>
        /// <param name="options">параметры поиска/фильтрации внутренних документов</param>
        /// <returns>Cписок внутренних документов</returns>
        public DocumentEntryList GetInternalDocuments(InternalListOptions options)
        {
            return CheckAutorizedInvoke(() => client.GetInternalDocuments(Token, options));
        }

        /// <summary>
        /// Перемещает документ в другое подразделение
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="documentId">ИД документа</param>
        /// <param name="departmentId">ИД подразделения</param>
        /// <returns>
        /// <c>true</c>, если документ был перемещен
        /// <c>false</c>, если документ уже находится в этом подразделении
        /// </returns>
        public bool MoveDocumentToDepartment(string boxId, string documentId, string departmentId)
        {
            return CheckAutorizedInvoke(() => client.MoveDocumentToDepartment(Token, boxId, documentId, departmentId));
        }

        /// <summary>
        /// Перемещает документы в другое подразделение
        /// </summary>
        /// <param name="authToken">Токен</param>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="documentIds">ИД документов</param>
        /// <param name="departmentId">ИД подразделения</param>
        /// <returns>ИД перемещенных документов</returns>
        public string[] MoveDocumentsToDepartment(string boxId, string[] documentIds, string departmentId)
        {
            return CheckAutorizedInvoke(() => client.MoveDocumentsToDepartment(Token, boxId, documentIds, departmentId));
        }

        /// <summary>
        /// Возвращает сотрудников заданного подразделения
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="departmentId">ИД подразделения</param>
        /// <returns>Список пользователей</returns>
        public User[] GetDepartmentEmployees(string boxId, string departmentId)
        {
            return CheckAutorizedInvoke(() => client.GetDepartmentEmployees(Token, boxId, departmentId));
        }

        /// <summary>
        /// Создать дополнительный статус(тэг) документа
        /// </summary>
        /// <param name="documentTag"></param>
        public string CreateDocumentTag(DocumentTag documentTag)
        {
            return CheckAutorizedInvoke(() => client.CreateDocumentTag(Token, documentTag));
        }

        /// <summary>
        /// Удалить дополнительный статус(тэг), прикрепленный к документу
        /// </summary>
        /// <param name="documentTagId"></param>
        public void DeleteDocumentTag(string documentTagId)
        {
            CheckAutorizedInvoke(() =>
                                     {
                                         client.DeleteDocumentTag(Token, documentTagId);
                                         return true;
                                     });
        }

        /// <summary>
        /// Возвращает дополнительный статус(тэг) документа
        /// </summary>
        /// <param name="documentTagId"></param>
        /// <returns></returns>
        public DocumentTag GetDocumentTag(string documentTagId)
        {
            return CheckAutorizedInvoke(() => client.GetDocumentTag(Token, documentTagId));
        }

        /// <summary>
        /// Возвращает список дополнительных статусов(тэгов), прикрепленных к документу
        /// </summary>
        /// <param name="boxId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public DocumentTag[] GetDocumentTagList(string boxId, string documentId)
        {
            return CheckAutorizedInvoke(() => client.GetDocumentTagList(Token, boxId, documentId));
        }

        /// <summary>
        /// Добавляет промокод в организацию
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="promoCodeName">Наименование промокода</param>
        public void AddOrganizationPromoCode(string boxId, string promoCodeName)
        {
            client.AddOrganizationPromoCode(Token, boxId, promoCodeName);
        }

        /// <summary>
        ///  Возвращает список промокодов организации
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <returns>Список промокодов организации</returns>
        public OrganizationPromoCode[] GetOrganizationPromoCodeList(string boxId)
        {
            return client.GetOrganizationPromoCodeList(Token, boxId);
        }

        /// <summary>
        /// Возвращает промокод по наименованию
        /// </summary>
        /// <param name="promoCodeName">Наименование промокода</param>
        /// <returns></returns>
        public PromoCode GetPromoCodeByName(string promoCodeName)
        {
            return client.GetPromoCodeByName(Token, promoCodeName);
        }

        /// <summary>
        /// Логическое удаление связи промокод-организация
        /// </summary>
        /// <param name="organizationPromoCodeId">Внешний идентификатор связи промокод-организация</param>
        /// <param name="boxId">Ящик организации</param>
        public void DeleteOrganizationPromoCode(string boxId, string organizationPromoCodeId)
        {
            client.DeleteOrganizationPromoCode(Token, boxId, organizationPromoCodeId);
        }

        /// <summary>
        /// Проверить список отпечатков сертификатов на возможность авторизации в сервисе.
        /// Возвращает информацию о сертификатах, по которым возможна авторизация.
        /// </summary>
        /// <param name="thumbprints">Массив отпечатков сертификатов</param>
        public CertificateCheckInfo[] CheckCertificateList(string[] thumbprints)
        {
            return Invoke(() => client.CheckCertificateList(thumbprints));
        }

        /// <summary>
        /// Сгенерировать ПОА
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="documentId">ИД документа</param>
        /// <param name="comment">Комментарий к ПОА</param>
        /// <param name="signerInfo">Информация о подписанте</param>
        /// <returns></returns>
        public NamedContent GenerateRevocationOffer(string boxId, string documentId, string comment, SignerInfo signerInfo)
        {
            return client.GenerateRevocationOffer(Token, boxId, documentId, comment, signerInfo);
        }

        /// <summary>
        /// Генерирует заявление об участии в ЭДО СФ 
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <returns></returns>
        public NamedContent GenerateStatementOfInvoiceReglament(string boxId)
        {
            return client.GenerateStatementOfInvoiceReglament(Token, boxId);
        }

        /// <summary>
        /// Отправляет сообщение с заявлением об участии в ЭДО СФ
        /// </summary>
        /// <param name="message">Сообщение с заявлением об участии в ЭДО СФ</param>
        /// <returns>Отправленное сообщение</returns>
        public SentMessage SendStatementOfInvoiceReglament(MessageOfStatement message)
        {
            return CheckAutorizedInvoke(() => client.SendStatementOfInvoiceReglament(Token, message));
        }

        /// <summary>
        /// Проверяет необходимость отправки заявления об участии в ЭДО СФ
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public bool CheckNeedToStatementOfInvoiceReglament(string boxId)
        {
            return client.CheckNeedToStatementOfInvoiceReglament(Token, boxId);
        }

        /// <summary>
        /// Получить модель титула продавца УПД из контента
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public GeneralTransferSeller ParseGeneralTransferSeller(byte[] content)
        {
            return client.ParseGeneralTransferSeller(Token, content);
        }

        /// <summary>
        /// Получить модель титула покупателя УПД из контента
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public GeneralTransferBuyer ParseGeneralTransferBuyer(byte[] content)
        {
            return client.ParseGeneralTransferBuyer(Token, content);
        }

        /// <summary>
        /// Получить модель титула продавца ДПРР из контента
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public WorksTransferSeller ParseWorksTransferSeller(byte[] content)
        {
            return client.ParseWorksTransferSeller(Token, content);
        }

        /// <summary>
        /// Получить модель титула покупателя ДПРР из контента
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public WorksTransferBuyer ParseWorksTransferBuyer(byte[] content)
        {
            return client.ParseWorksTransferBuyer(Token, content);
        }

        /// <summary>
        /// Получить модель титула продавца ДПТ из контента
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public GoodsTransferSeller ParseGoodsTransferSeller(byte[] content)
        {
            return client.ParseGoodsTransferSeller(Token, content);
        }

        /// <summary>
        /// Получить модель титула покупателя ДПТ из контента
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public GoodsTransferBuyer ParseGoodsTransferBuyer(byte[] content)
        {
            return client.ParseGoodsTransferBuyer(Token, content);
        }

        /// <summary>
        /// Получить модель титула продавца УКД из контента
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public GeneralTransferCorrectionSeller ParseGeneralTransferCorrectionSeller(byte[] content)
        {
            return client.ParseGeneralTransferCorrectionSeller(Token, content);
        }

        /// <summary>
        /// Получить модель титула покупателя УКД из контента
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public GeneralTransferCorrectionBuyer ParseGeneralTransferCorrectionBuyer(byte[] content)
        {
            return client.ParseGeneralTransferCorrectionBuyer(Token, content);
        }

        /// <summary>
        /// Сгенерировать контент титула продавца универсального корректировочного документа
        /// </summary>
        /// <param name="model">Модель титула продавца</param>
        /// <param name="options">Опции генерации</param>
        /// <returns></returns>
        public GeneratedContent GenerateGeneralTransferCorrectionSeller(
            GeneralTransferCorrectionSeller model,
            DocumentGenerationOptions options)
        {
            return client.GenerateGeneralTransferCorrectionSeller(Token, model, options);
        }

        /// <summary>
        /// Сгенерировать контент титула продавца универсального передаточного документа
        /// </summary>
        /// <param name="model">Модель титула покупателя</param>
        /// <param name="options">Опции генерации</param>
        /// <returns></returns>
        public GeneratedContent GenerateGeneralTransferSeller(GeneralTransferSeller model, DocumentGenerationOptions options)
        {
            return client.GenerateGeneralTransferSeller(Token, model, options);
        }

        /// <summary>
        /// Сгенерировать контент титула продавца документа передачи товаров
        /// </summary>
        /// <param name="model">Модель титула продавца</param>
        /// <param name="options">Опции генерации</param>
        /// <returns></returns>
        public GeneratedContent GenerateGoodsTransferSeller(GoodsTransferSeller model, DocumentGenerationOptions options)
        {
            return client.GenerateGoodsTransferSeller(Token, model, options);
        }

        /// <summary>
        /// Сгенерировать контент титула исполнителя документа передачи результатов работ (услуг)
        /// </summary>
        /// <param name="model">Модель титула исполнителя</param>
        /// <param name="options">Опции генерации</param>
        /// <returns></returns>
        public GeneratedContent GenerateWorksTransferSeller(WorksTransferSeller model, DocumentGenerationOptions options)
        {
            return client.GenerateWorksTransferSeller(Token, model, options);
        }

        /// <summary>
        /// Сгенерировать контент титула заказчика документа передачи результатов работ (услуг)
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="documentId">Ид титула заказчика</param>
        /// <param name="model">Модель</param>
        /// <param name="options">Опции генерации</param>
        /// <returns></returns>
        public GeneratedContent GenerateWorksTransferBuyer(string boxId,
                                                    string documentId,
                                                    ObjectModel.WorksTransferBuyer model,
                                                    DocumentGenerationOptions options)
        {
            return client.GenerateWorksTransferBuyer(Token, boxId, documentId, model, options);
        }

        /// <summary>
        /// Сгенерировать контент титула покупателя документа передачи товаров
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="documentId">Ид титула покупателя</param>
        /// <param name="model">Модель</param>
        /// <param name="options">Опции генерации</param>
        /// <returns></returns>
        public GeneratedContent GenerateGoodsTransferBuyer(string boxId,
                                                    string documentId,
                                                    ObjectModel.GoodsTransferBuyer model,
                                                    DocumentGenerationOptions options)
        {
            return client.GenerateGoodsTransferBuyer(Token, boxId, documentId, model, options);
        }

        /// <summary>
        /// Сгенерировать контент титула покупателя универсального передаточного документа
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="documentId">Ид титула покупателя</param>
        /// <param name="model">Модель</param>
        /// <param name="options">Опции генерации</param>
        /// <returns></returns>
        public GeneratedContent GenerateGeneralTransferBuyer(string boxId,
                                                    string documentId,
                                                    ObjectModel.GeneralTransferBuyer model,
                                                    DocumentGenerationOptions options)
        {
            return client.GenerateGeneralTransferBuyer(Token, boxId, documentId, model, options);
        }

        /// <summary>
        /// Сгенерировать контент титула покупателя универсального корректировочного документа
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="documentId">Ид титула покупателя</param>
        /// <param name="model">Модель</param>
        /// <param name="options">Опции генерации</param>
        /// <returns></returns>
        public GeneratedContent GenerateGeneralTransferCorrectionBuyer(string boxId,
                                                    string documentId,
                                                    ObjectModel.GeneralTransferCorrectionBuyer model,
                                                    DocumentGenerationOptions options)
        {
            return client.GenerateGeneralTransferCorrectionBuyer(Token, boxId, documentId, model, options);
        }

        public NamedContent DownloadPdfDocument(string boxId, string documentId)
        {
            return CheckAutorizedInvoke(() => client.DownloadPdfDocument(Token, boxId, documentId));
        }

        public RegistrationResponse RegisterSubscriber(RegistrationRequest request)
        {
            return Invoke(() => client.RegisterSubscriber(request));
        }

        public NonActiveSubscriberCreationResponse CreateNonActiveSubscriber(NonActiveSubscriberCreationRequest request)
        {
            return CheckAutorizedInvoke(() => client.CreateNonActiveSubscriber(Token, request));
        }

        public QualifiedX509Name GetCertificateSubjectInfo(byte[] certificate)
        {
            return Invoke(() => client.GetCertificateSubjectInfo(certificate));
        }

        public EnumValue GetDocumentExecutedFunction(string boxId, string documentId)
        {
            return CheckAutorizedInvoke(() => client.GetDocumentExecutedFunction(Token, boxId, documentId));
        }
        
        public SimpleSignatureRegulationAcceptingResponse AcceptSimpleSignatureRegulation(
            EmployeeOperationCredentials credentials,
            SimpleSignatureRegulationAcceptingRequest request)
            => Invoke(credentials, () => client.AcceptSimpleSignatureRegulation(credentials, request));

        public SimpleSignatureAvailabilityCheckingResponse CheckSimpleSignatureAvailability(
            EmployeeOperationCredentials credentials,
            SimpleSignatureAvailabilityCheckingRequest request)
            => Invoke(credentials, () => client.CheckSimpleSignatureAvailability(credentials, request));

        public SimpleSignatureCreationResponse CreateSimpleSignature(
            EmployeeOperationCredentials credentials,
            SimpleSignatureCreationRequest request)
            => Invoke(credentials, () => client.CreateSimpleSignature(credentials, request));

        public SimpleSignatureRequisitesPreviewingResponse PreviewSimpleSignatureRequisites(
            EmployeeOperationCredentials credentials,
            SimpleSignatureRequisitesPreviewingRequest request)
            => Invoke(credentials, () => client.PreviewSimpleSignatureRequisites(credentials, request));
    }
}
