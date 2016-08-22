using System;
using Midway.ObjectModel;
using Midway.ObjectModel.Common;

namespace Midway.ServiceClient
{
    public interface IExchangeServiceClient
    {
        bool IsAuthorized { get; }

        EventHandler<ClientAutorizedEventArgs> Authorized { get; set; }

        string Token { get; set; }
        
        string EncryptedToken { get; }

        System.ServiceModel.Description.ServiceEndpoint Endpoint { get; }

        /// <summary>
        /// Получение токена при авторизации по паролю
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        bool Authenticate(string login, string password, string applicationId = null);

        /// <summary>
        /// Получение токена при авторизации по сертификату
        /// </summary>
        /// <param name="certHash">отпечаток сертификата</param>
        bool AuthenticateWithCertificate(string certHash, string applicationId = null);

        IAsyncResult BeginAuthenticate(string login, string password, string applicationId, AsyncCallback asyncCallback);

        string EndAuthenticate(IAsyncResult asyncResult);

        /// <summary>
        /// Возвращает список доступных ящиков пользователя
        /// </summary>
        BoxInfo[] GetBoxes();

        IAsyncResult BeginGetBoxes(AsyncCallback asyncCallback);

        BoxInfo[] EndGetBoxes(IAsyncResult asyncResult);

        /// <summary>
        /// Получить список сообщений из ящика
        /// </summary>
        /// <param name="afterMessageId">последнее полученное сообщение</param>
        /// <param name="fromBox">ящик отправителя</param>
        /// <param name="toBox">ящик получателя</param>
        MessageInfo[] GetMessages(string afterMessageId, string fromBox, string toBox);

        //IAsyncResult BeginGetMessages(string afterMessageId, string fromBox, string toBox, AsyncCallback asyncCallback);

        //MessageInfo[] EndGetMessages(IAsyncResult asyncResult);

        /// <summary>
        /// Возвращает информацию по сообщению
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="messageId">ID сообщения</param>
        Message GetMessage(string boxId, string messageId);

        /// <summary>
        /// Возвращает информацию по сообщению c возможностью не загружать контент подписей и документов
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="messageId">ID сообщения</param>
        /// <param name="requestParams">Параметры загрузки сообщения</param>
        Message GetMessageWithLoadOptions(string boxId, string messageId, MessageRequestParams requestParams);

        //IAsyncResult BeginGetMessage(string boxId, string messageId, AsyncCallback asyncCallback);

        //Message EndGetMessage(IAsyncResult asyncResult);

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns>возвращает результат отправки</returns>
        SentMessage SendMessage(Message message);

        //IAsyncResult BeginSendMessage(Message message, AsyncCallback asyncCallback);

        #region Черновики

        /// <summary>
        /// Создать черновик сообщения
        /// Если не указан ИД, то он генерируется
        /// </summary>
        /// <param name="draftMessage">Черновик</param>
        /// <returns>ИД черновика</returns>
        string CreateDraftMessage(DraftMessage draftMessage);

        /// <summary>
        /// Изменить черновик сообщения
        /// </summary>
        /// <param name="draftMessage">Черновик</param>
        void UpdateDraftMessage(DraftMessage draftMessage);

        /// <summary>
        /// Удалить черновик сообщения
        /// </summary>
        /// <param name="messageId">ИД сообщения</param>
        void DeleteDraftMessage(string messageId);

        /// <summary>
        /// Получить черновик сообщения по ИД
        /// </summary>
        /// <param name="messageId">ИД сообщения</param>
        /// <param name="getContent">Возвращать ли контент документов в черновике</param>
        /// <param name="getCard">Возвращать ли карточку документов в черновике</param>
        /// <returns>Черновик сообщения</returns>
        DraftMessage GetDraftMessage(string messageId, bool getContent, bool getCard);

        /// <summary>
        /// Получить список черновиков сообщений
        /// </summary>
        /// <param name="settings">Настройки выборки</param>
        /// <param name="boxId">Ящик организации</param>
        /// <returns>Результат поиска черновиков сообщений</returns>
        DraftMessageSearchResult GetDraftMessageList(FetchingSettings settings, string boxId);

//        /// <summary>
//        /// Выполнить поиск черновиков сообщений
//        /// </summary>
//        /// <param name="settings">Настройки поиска</param>
//        /// <param name="boxId">Ящик организации</param>
//        /// <returns>Результат поиска черновиков сообщений</returns>
//        DraftMessageSearchResult SearchDraftMessages(SearchSettings settings, string boxId);

        /// <summary>
        /// Получить кол-во черновиков сообщений у пользователя указанной организации
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <returns>Кол-во черновиков сообщений</returns>
        int GetDraftMessageCount(string boxId);

        /// <summary>
        /// Получить контент документа черновика сообщения
        /// </summary>
        /// <param name="documentId">ИД документа черновика сообщения</param>
        /// <returns>Контент документа черновика сообщения</returns>
        byte[] GetDraftDocumentContent(string documentId);

        #endregion Черновики


        /// <summary>
        /// Генерирует уведомление о получении документа (регламент ЭСФ)
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор документа</param>
        /// <returns>контент документа-уведомления</returns>
        NamedContent GenerateInvoiceReceipt(string boxId, string documentId);

        //IAsyncResult BeginGenerateInvoiceReceipt(string boxId, string documentId, AsyncCallback asyncCallback);

        //NamedContent EndGenerateInvoiceReceipt(IAsyncResult asyncResult);

        /// <summary>
        /// Генерирует уведомление о получении документа (регламент ЭСФ)
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор документа</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns>контент документа-уведомления</returns>
        NamedContent GenerateInvoiceReceiptV2(string boxId, string documentId, string certThumbprint);

        //IAsyncResult BeginGenerateInvoiceReceiptV2(string boxId, string documentId, string certThumbprint, AsyncCallback asyncCallback);

        //NamedContent EndGenerateInvoiceReceiptV2(IAsyncResult asyncResult);

        /// <summary>
        /// Генерирует ИОП
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <returns>контент документа коррекции</returns>
        NamedContent GenerateDeliveryConfirmation(string boxId, string documentId);

        //IAsyncResult BeginGenerateDeliveryConfirmation(string boxId, string documentId, AsyncCallback asyncCallback);

        //NamedContent EndGenerateDeliveryConfirmation(IAsyncResult asyncResult);

        /// <summary>
        /// Генерирует ИОП
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns>контент документа коррекции</returns>
        NamedContent GenerateDeliveryConfirmationV2(string boxId, string documentId, string certThumbprint);

        //IAsyncResult BeginGenerateDeliveryConfirmationV2(string boxId, string documentId, string certThumbprint, AsyncCallback asyncCallback);

        //NamedContent EndGenerateDeliveryConfirmationV2(IAsyncResult asyncResult);

        /// <summary>
        /// Генерирует УОУ для ЭСФ
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <returns>контент документа коррекции</returns>
        NamedContent GenerateInvoiceAmendmentRequest(string boxId, string documentId, string text);

        //IAsyncResult BeginGenerateInvoiceAmendmentRequest(string boxId, string documentId, string text,
        //                                                 AsyncCallback asyncCallback);

        //NamedContent EndGenerateInvoiceAmendmentRequest(IAsyncResult asyncResult);

        /// <summary>
        /// Генерирует УОУ для ЭСФ
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns>контент документа коррекции</returns>
        NamedContent GenerateInvoiceAmendmentRequestV2(string boxId, string documentId, string certThumbprint, string text);

        //IAsyncResult BeginGenerateInvoiceAmendmentRequestV2(string boxId, string documentId, string certThumbprint, string text, AsyncCallback asyncCallback);

        //NamedContent EndGenerateInvoiceAmendmentRequestV2(IAsyncResult asyncResult);


        /// <summary>
        /// Генерирует УОУ
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <returns>контент документа коррекции</returns>
        NamedContent GenerateAmendmentRequest(string boxId, string documentId, string text);

        //IAsyncResult BeginGenerateAmendmentRequest(string boxId, string documentId, string text,
        //                                          AsyncCallback asyncCallback);

        //NamedContent EndGenerateAmendmentRequest(IAsyncResult asyncResult);

        /// <summary>
        /// Генерирует УОУ
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор счета-фактуры</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns>контент документа коррекции</returns>
        NamedContent GenerateAmendmentRequestV2(string boxId, string documentId, string certThumbprint, string text);

        //IAsyncResult BeginGenerateAmendmentRequestV2(string boxId, string documentId, string certThumbprint, string text, AsyncCallback asyncCallback);

        //NamedContent EndGenerateAmendmentRequestV2(IAsyncResult asyncResult);

        /// <summary>
        /// Генерирует титул покупателя (заказчика)
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId">идентификатор документа</param>
        /// <returns></returns>
        NamedContent GenerateTitleBuyer(string boxId, string documentId, TitleBuyer text);

        //IAsyncResult BeginGenerateTitleBuyer(string boxId, string documentId, TitleBuyer text,
        //                                     AsyncCallback asyncCallback);

        //NamedContent EndGenerateTitleBuyer(IAsyncResult asyncResult);

        /// <summary>
        /// Получить содержимое документа
        /// </summary>
        /// <param name="boxId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        byte[] GetDocumentContent(string boxId, string documentId);

        //IAsyncResult BeginGetDocumentContent(string boxId, string documentId, AsyncCallback asyncCallback);

        //byte[] EndGetDocumentContent(IAsyncResult asyncResult);

        /// <summary>
        /// Получить полную информацию о документе
        /// </summary>
        /// <returns></returns>
        FullDocumentInfo GetFullDocumentInfo(string boxId, string documentId,
                                             FullDocumentInfoRequestParams requestParams = null);

        //IAsyncResult BeginGetFullDocumentInfo(string boxId, string documentId,
        //                                      FullDocumentInfoRequestParams requestParams, AsyncCallback asyncCallback);

        //FullDocumentInfo EndGetFullDocumentInfo(IAsyncResult asyncResult);

        /// <summary>
        /// Возвращает ИНН, КПП и наименование организации
        /// </summary>
        /// <param name="boxId">ящик</param>
        InnKppName GetInnKppNameByBoxId(string boxId);

        /// <summary>
        /// Поиск контрагентов
        /// </summary>
        /// <param name="contactSearchOptions">параметры поиска контакта</param>
        /// <returns>результат поиска, возвращает общее число и информацию по контрагентам</returns>
        ContactSearchResult SearchContacts(ContactSearchOptions contactSearchOptions);

        /// <summary>
        /// Возвращает информацию по контрагенту
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        Contact GetContact(int organizationId, int contragentId);

        /// <summary>
        /// Установить отношения по обмену с контрагентом
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        ContactStatus AcceptAuthorization(int organizationId, int contragentId, string comment);

        /// <summary>
        /// Прекратить отношения по обмену с контрагентом
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        ContactStatus RejectAuthorization(int organizationId, int contragentId, string comment);

        /// <summary>
        /// Запрос авторизации
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        void SendAuthRequest(int organizationId, int contragentId, string comment);

        /// <summary>
        /// Отмена авторизации
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        void CancelAuthRequest(int organizationId, int contragentId, string comment);

        /// <summary>
        /// Подтверждение авторизации
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        void AcceptAuthRequest(int organizationId, int contragentId, string comment);

        /// <summary>
        /// Отклонение авторизации
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        void RejectAuthRequest(int organizationId, int contragentId, string comment);

        /// <summary>
        /// Удаление контрагента из списка активных
        /// </summary>
        /// <param name="organizationId">Id текущей организации</param>
        /// <param name="contragentId">Id контрагента</param>
        /// <param name="comment">комментарий</param>
        void DeleteContact(int organizationId, int contragentId, string comment);

        /// <summary>
        /// Получение информации об организации по ИНН/КПП
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="inn"></param>
        /// <param name="kpp"></param>
        Organization GetOrganizationByInnKpp(string inn, string kpp);

        /// <summary>
        /// Получение информации об организации
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="criteria">критерии для выборки информации по организации</param>
        /// <param name="values">параметры поиска по критерию</param>
        Organization GetOrganizationBy(string boxId, OrganizationByCriteria criteria,
                                       OrganizationByCriteriaValues values);

        /// <summary>
        /// Возвращает информацию о субъекте документооборота
        /// </summary>
        /// <param name="subjectBoxId"> </param>
        /// <returns></returns>
        SubjectInfo GetSubjectInfo(string subjectBoxId);

        /// <summary>
        /// Возвращает информацию о субъекте документооборота (спецоператоре)
        /// </summary>
        /// <returns></returns>
        SubjectInfo GetSpecialOperatorInfo();

        /// <summary>
        /// Добавляет подразделение в орг. структуру
        /// </summary>
        /// <param name="element">Подразделение</param>
        string AddOrganizationStructureElement(OrganizationStructureElement element);

        /// <summary>
        /// Удаляет подразделение из организационной структуры
        /// </summary>
        /// <param name="elementId">Идентификатор подразделения</param>
        void DeleteOrganizationStructureElement(string organizationId, string elementId);

        /// <summary>
        /// Изменение данных о подразделении
        /// </summary>
        /// <param name="element">Подразделение</param>
        void ModifyOrganizationStructureElement(OrganizationStructureElement element);

        /// <summary>
        /// Возвращает данные об организационной структуре
        /// </summary>
        /// <param name="organizationId">идентификатор организации</param>
        /// <returns>массив элементов орг. структуры</returns>
        OrganizationStructureElement[] GetOrganizationStructure(string boxId, string organizationId);

        /// <summary>
        /// Возвращает, имеет ли оргструктура один единственный элемент
        /// </summary>
        /// <param name="organizationId">идентификатор организации</param>
        /// <returns></returns>
        bool OrganizationStructureHasSingleElement(string organizationId);

        /// <summary>
        /// Возвращает дочерние элементы подразделения оргструктуры
        /// </summary>
        /// <param name="organizationId">ИД организации</param>
        /// <param name="orgStructureElementId">ИД элемента оргструктуры</param>
        /// <returns>массив элементов орг. структуры</returns>
        OrganizationStructureElement[] GetOrganizationStructureElementChildren(string organizationId, string orgStructureElementId);

        /// <summary>
        /// Получение токена при авторизации по сертификату
        /// </summary>
        /// <param name="certHash">отпечаток сертификата</param>
        string GetEncryptedToken(string certHash, string applicationId = null);

        /// <summary>
        /// Проверка квалифицированного сертификата
        /// </summary>
        /// <param name="certificate">сертификат в DER-кодировке</param>
        /// <returns>Результат проверки сертификата</returns>
        CertificateValidationResult CheckQualifiedCertificate(byte[] certificate);

        /// <summary>
        /// Возвращает список сертификатов ассоциированных с ящиками
        /// </summary>
        BoxCertificate[] GetBoxCertificates();

        /// <summary>
        /// Получение списка служебных документов, которые необходимо подписать и отправить
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="certThumbprint">отпечаток сертификата</param>
        /// <returns></returns>
        ServiceNotice[] GetRequiredNotices(string boxId, string certThumbprint = null);

        /// <summary>
        /// Получение усовершенствованной подписи
        /// по оригинальной
        /// </summary>
        /// <param name="boxId">Идентификатор ящика организации</param>
        /// <param name="sign">Подпись, на которую необходимо получить усовершенствованную</param>
        /// <returns>Усовершенствованная подпись</returns>
        EnhancedSign GetEnhancedSign(string boxId, byte[] sign);

        /// <summary>
        /// Получение усовершенствованной подписи
        /// по идентификатору
        /// </summary>
        /// <param name="boxId">Идентификатор ящика организации</param>
        /// <param name="signId">Идентификатор подписи</param>
        /// <returns>Усовершенствованная подпись</returns>
        EnhancedSign GetEnhancedSignById(string boxId, string signId);

        /// <summary>
        /// Возвращает zip-архив со всей цепочкой документооборота
        /// </summary>
        /// <param name="boxId">ящик</param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        NamedContent DownloadDocumentFlowArchive(string boxId, string documentId);

        /// <summary>
        /// Получить все организации по указанному ИНН (+ КПП).
        /// В случае поиска ИП, ФЛ или организации со списком филиалов - КПП не указывается.
        /// </summary>
        /// <param name="inn"></param>
        /// <param name="kpp"></param>
        /// <returns>Внимание! Возможен возврат одной и той же организации в нескольких записях, 
        /// если она зарегистрирована сразу у нескольких операторов</returns>
        Organization[] GetOrganizationListByInnKpp(string inn, string kpp = null);

        /// <summary>
        /// Проверить список отпечатков на возможность авторизации в сервисе.
        /// Возвращает список отпечатков сертификатов, по которым возможна авторизация.
        /// </summary>
        /// <param name="thumbprints"></param>
        string[] CheckCertificates(string[] thumbprints);

        /// <summary>
        /// Получение информации о пользователе
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        User GetUserInfo(string boxId);

        /// <summary>
        /// Регистрация пользователя из внешних систем
        /// </summary>
        /// <param name="registerModel"> Информация о регистрируемом пользователе </param>
        /// <param name="certificate">Сертификат</param>
        /// <returns>Информация о зарегистрированном пользователе</returns>
        RegisterResult Register(RegisterModel registerModel, byte[] certificate = null);

        /// <summary>
        /// Принятие Правил работы в Synerdocs организацией
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="acceptRegulation">Признак принятия регламента организацией</param>
        /// <returns>Возвращает true, если Правила работы в Synerdocs приняты, инче вернёт false</returns>
        bool AcceptRegulation(string boxId, bool acceptRegulation);

        /// <summary>
        /// Проверяет наличие у контрагента действующих квалифицированных сертификатов
        /// </summary>
        /// <param name="contragerntBoxId">Ящик контрагента</param>
        /// <returns>
        /// Возвращает true если у контрагента есть хотя бы один действующий квалифицированный сертификат , иначе вернет false
        /// </returns>
        bool HasQualifiedCertificate(string contragerntBoxId);

        /// <summary>
        /// Создать дополнительный статус(тэг) документа
        /// </summary>
        /// <param name="documentTag"></param>
        string CreateDocumentTag(DocumentTag documentTag);

        /// <summary>
        /// Удалить дополнительный статус(тэг), прикрепленный к документу
        /// </summary>
        /// <param name="documentTagId"></param>
        void DeleteDocumentTag(string documentTagId);

        /// <summary>
        /// Возвращает дополнительный статус(тэг) документа
        /// </summary>
        /// <param name="documentTagId"></param>
        /// <returns></returns>
        DocumentTag GetDocumentTag(string documentTagId);

        /// <summary>
        /// Возвращает список дополнительных статусов(тэгов), прикрепленных к документу
        /// </summary>
        /// <param name="boxId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        DocumentTag[] GetDocumentTagList(string boxId, string documentId);

        /// <summary>
        /// Добавляет промокод в организацию
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <param name="promoCodeName">Наименование промокода</param>
        void AddOrganizationPromoCode(string boxId, string promoCodeName);

        /// <summary>
        ///  Возвращает список промокодов организации
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <returns>Список промокодов организации</returns>
        OrganizationPromoCode[] GetOrganizationPromoCodeList(string boxId);
    
        /// <summary>
        /// Возвращает промокод по наименованию
        /// </summary>
        /// <param name="promoCodeName">Наименование промокода</param>
        /// <returns></returns>
        PromoCode GetPromoCodeByName(string promoCodeName);

        /// <summary>
        /// Логическое удаление связи промокод-организация
        /// </summary>
        /// <param name="organizationPromoCodeId">Внешний идентификатор связи промокод-организация</param>
        void DeleteOrganizationPromoCode(string boxId, string organizationPromoCodeId);

        /// <summary>
        /// Проверить список отпечатков сертификатов на возможность авторизации в сервисе.
        /// Возвращает информацию о сертификатах, по которым возможна авторизация.
        /// </summary>
        /// <param name="thumbprints">Массив отпечатков сертификатов</param>
        CertificateCheckInfo[] CheckCertificateList(string[] thumbprints);

        /// <summary>
        /// Генерирует заявление об участии в ЭДО СФ 
        /// </summary>
        /// <param name="boxId">Ящик организации</param>
        /// <returns></returns>
        NamedContent GenerateStatementOfInvoiceReglament(string boxId);

        /// <summary>
        /// Отправляет сообщение с заявлением об участии в ЭДО СФ
        /// </summary>
        /// <param name="message">Сообщение с заявлением об участии в ЭДО СФ</param>
        /// <returns>Отправленное сообщение</returns>
        SentMessage SendStatementOfInvoiceReglament(MessageOfStatement message);

        /// <summary>
        /// Проверяет необходимость отправки заявления об участии в ЭДО СФ
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        bool CheckNeedToStatementOfInvoiceReglament(string boxId);
    }
}
