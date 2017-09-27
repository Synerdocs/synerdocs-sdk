using System.ComponentModel;

namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// Типы ошибок сервиса:
    /// превышен максимальный размер сообщения
    ///	ошибка доступа к ящику
    ///	неправильно указан отправитель 
    ///	неправильно указан получатель
    ///	неправильно заполнено сообщение (нет обязательных параметров, неправильная ссылка на объект и пр.)
    /// неправильная ссылка на сообщение
    ///	[СФ] некорректный формат служебного документа
    ///	[СФ] некорректный формат счета-фактуры
    ///	[ЭП] некорректный формат подписи (CMS)
    ///	[ЭП] подпись не содержит информацию о сертификатах
    ///	[ЭП] использован неправильный криптографический алгоритм в подписи
    ///	[ЭП] Недействительная подпись, код подразумевает несоответствие хеша.
    ///	ошибка доставки сообщения стороннему спец. оператору (у спец оператора свои ошибки, их надо транслировать)
    ///	контрагент не авторизован (не установлены взаимоотношения)
    ///	внутренняя ошибка сервиса
    /// 
    /// 
    /// Коды относящиеся к ЭП начинаются с 50
    /// 
    /// </summary>
    public enum ServiceErrorCode
    {
        /// <summary>
        /// Внутренняя ошибка сервера
        /// </summary>
        [Description("Внутренняя ошибка сервера")]
        UnexpectedError = 0,

        // Не заполнено обязательное поле
        [Description("Не заполнено обязательное поле")]
        NotFilledRequiredField = 1,

        /// TODO@Не используется
        /// <summary>
        /// Сообщение не содержит документ
        /// </summary>
        [Description("Сообщение не содержит документ")]
        MessageDoesNotContainReference = 2,

        /// <summary>
        /// Неправильный формат значения поля
        /// </summary>
        [Description("Неправильный формат значения поля")]
        InvalidFormatField = 3,

        /// <summary>
        /// Неправильно указан получатель
        /// </summary>
        [Description("Неправильно указан получатель")]
        InvalidDestinationAddress = 4,

        /// <summary>
        /// Неправильный токен аутентификации
        /// </summary>
        [Description("Неправильный токен аутентификации")]
        Unauthorized = 5,

        /// <summary>
        /// Неверная ссылка на документ
        /// </summary>
        [Description("Неверная ссылка на документ")]
        InvalidDocumentReference = 6,

        /// <summary>
        /// Некорректный контент карточки документа
        /// </summary>
        [Description("Некорректный контент карточки документа")]
        InvalidCardContent = 7,

        /// <summary>
        /// Данные не найдены
        /// </summary>
        [Description("Данные не найдены")]
        NoDataFound = 8,

        /// <summary>
        /// Ошибка доступа к абонентскому  ящику
        /// </summary>
        [Description("Ошибка доступа к абонентскому ящику")]
        BoxAccessError = 10,

        #region Контакты (11, 12, 41-50)

        /// TODO@Не используется
        /// <summary>
        /// Контрагент не авторизован
        /// </summary>
        [Description("Контрагент не авторизован")]
        ContragentIsNotAuthorized = 11,

        /// <summary>
        /// Ошибка работы со списком активных контрагентов
        /// </summary>
        [Description("Ошибка работы со списком активных контрагентов")]
        ContactListError = 12,

        /// <summary>
        /// Контрагент не авторизован
        /// </summary>
        [Description("Контрагент не авторизован")]
        ContactIsNotAuthorized = 41,

        /// <summary>
        /// Контрагент уже авторизован
        /// </summary>
        [Description("Контрагент уже авторизован")]
        ContactIsAlreadyAuthorized = 42,

        /// <summary>
        /// Приглашение к обмену с контрагентом уже есть
        /// </summary>
        [Description("Приглашение к обмену с контрагентом уже есть")]
        ContactAuthIsAlreadyRequested = 43,

        /// <summary>
        /// Контрагент запретил обмен
        /// </summary>
        [Description("Контрагент запретил обмен")]
        ContactHasRejectedAuth = 44,

        /// <summary>
        /// Приглашение к обмену с контрагентом не существует
        /// </summary>
        [Description("Приглашение к обмену с контрагентом не существует")]
        ContactAuthRequestNotFound = 45,

        /// <summary>
        /// Активная организация может быть приглашена только активной организацией
        /// </summary>
        [Description("Активная организация может быть приглашена только активной организацией")]
        OrganizationMustBeActive = 46,

        /// <summary>
        /// Обмен с контрагентом заблокирован
        /// </summary>
        [Description("Обмен с контрагентом заблокирован")]
        ContactAuthIsRejected = 47,

        #endregion Контакты

        /// <summary>
        /// Доступ запрещен
        /// </summary>
        [Description("Доступ запрещен")]
        AccessDeniedError = 13,

        /// <summary>
        /// Возможность отключена
        /// </summary>
        [Description("Возможность отключена")]
        FeatureDisabled = 14,

        #region Сертификаты и подписи (51-60)

        /// <summary>
        /// Некорректный формат подписи (CMS)
        /// </summary>
        [Description("Некорректный формат подписи (CMS)")]
        InvalidCMS = 51,

        /// <summary>
        /// Подпись не содержит информацию о сертификате
        /// </summary>
        [Description("Подпись не содержит информацию о сертификате")]
        SignDoesNotContainCertificate = 52,

        /// <summary>
        /// Подпись недействительна, нарушена целостность
        /// </summary>
        [Description("Подпись недействительна, нарушена целостность")]
        SignIsNotValid = 53,

        /// <summary>
        /// Истек или еще не наступил срок действия сертификата
        /// </summary>
        [Description("Истек или еще не наступил срок действия сертификата")]
        CertificatePeriodIsNotValid = 54,

        /// <summary>
        /// Сертификат не входит в зону доверия
        /// </summary>
        [Description("Сертификат не входит в зону доверия")]
        CertificateIsNotTrusted = 55,

        /// <summary>
        /// Сертификат отозван
        /// </summary>
        [Description("Сертификат отозван")]
        CertificateIsRevoked = 56,

        /// <summary>
        /// Некорректный состав атрибутов и дополнений сертификата
        /// </summary>
        [Description("Некорректный состав атрибутов и дополнений сертификата")]
        CertificateHasNotValidAttributesAndExtensions = 58,

        /// <summary>
        /// Усовершенствованная подпись не найдена
        /// </summary>
        [Description("Усовершенствованная подпись не найдена")]
        EnhancedSignNotFound = 59,

        #endregion Сертификаты и подписи

        #region Оргструктура (61-70)

        /// <summary>
        /// Элемент организационной структуры удален
        /// </summary>
        [Description("Элемент организационной структуры удален")]
        DepartmentDeleted = 61,

        /// <summary>
        /// Родительский элемент организационной структуры удален
        /// </summary>
        [Description("Родительский элемент организационной структуры удален")]
        ParentDepartmentDeleted = 62,

        /// <summary>
        /// Элемент организационной структуры имеет дочерние элементы
        /// </summary>
        [Description("Элемент организационной структуры имеет дочерние элементы")]
        DepartmentHasChild = 63,

        /// <summary>
        /// Попытка указать несуществующее или удаленное подразделение в сообщении
        /// </summary>
        [Description("Попытка указать несуществующее или удаленное подразделение в сообщении")]
        DepartmentDoesNotExist = 64,

        /// <summary>
        /// Циклическая зависимость между элементами орг. структуры
        /// </summary>
        [Description("Циклическая зависимость между элементами оргструктуры")]
        DepartmentCyclicDependency = 65,

        /// <summary>
        /// Родительское подразделение указано неверно
        /// </summary>
        [Description("Родительское подразделение указано неверно")]
        IncorrectParentDepartment = 66,

        /// TODO@Не используется
        /// <summary>
        /// Подразделение является головным, удалить нельзя
        /// </summary>
        [Description("Подразделение является головным, удалить нельзя")]
        DepartmentIsHead = 67,

        #endregion оргструктура

        #region Права пользователей (71-79)

        ///// <summary>
        ///// Попытка сохранения в базе уже существующего разрешения
        ///// </summary>
        //DublicatePermission = 70,

        /// <summary>
        /// Запись уже удалена
        /// </summary>
        [Description("Запись уже удалена")]
        PermissionAlreadyDeleted = 71,

        /// <summary>
        /// Несуществующая запись
        /// </summary>
        [Description("Несуществующая запись")]
        PermissionDoesNotExist = 72,

        #endregion права пользователей

        /// <summary>
        /// Пользователь уже существует
        /// </summary>
        [Description("Пользователь уже существует")]
        DuplicateUser = 80,

        /// <summary>
        /// Пользователь удален
        /// </summary>
        [Description("Пользователь удален")]
        UserDeleted = 81,

        /// <summary>
        /// Переданный сертификат уже есть в базе данных
        /// </summary>
        [Description("Переданный сертификат уже есть в базе данных")]
        DuplicateCertificate = 83,

        /// <summary>
        /// Привязка к организации пользователя уже есть
        /// </summary>
        [Description("Привязка к организации пользователя уже есть")]
        DuplicateBindToOrganization = 84,

        /// TODO@Не используется
        /// <summary>
        /// Не найден сертификат
        /// </summary>
        [Description("Не найден сертификат")]
        CertificateNotFound = 85,

        /// <summary>
        /// Не удалось распознать сертификат
        /// </summary>
        [Description("Не удалось распознать сертификат")]
        CertificateParsingFailed = 86,

        /// <summary>
        /// Организация с предоставленным ИНН уже есть в базе данных
        /// </summary>
        [Description("Организация с предоставленным ИНН уже есть в базе данных")]
        DuplicateOrganization = 87,

        #region Черновики (101-110)
        /// <summary>
        /// Ошибка работы с черновиками сообщений
        /// </summary>
        [Description("Ошибка работы с черновиками сообщений")]
        DraftMessageError = 101,

        #endregion Черновики

        #region Валидация (1001-1007)

        /// <summary>
        /// Некорректный формат документа
        /// </summary>
        [Description("Некорректный формат документа")]
        InvalidDocumentFormat = 1001,

        /// <summary>
        /// Некорректное содержимое документа
        /// </summary>
        [Description("Некорректное содержимое документа")]
        InvalidDocumentContent = 1002,

        /// <summary>
        /// Некорректное имя файла
        /// </summary>
        [Description("Некорректное имя файла")]
        InvalidFileName = 1003,

        /// <summary>
        /// Не удалось загрузить архив с цепочкой документооборота
        /// </summary>
        [Description("Не удалось загрузить архив с цепочкой документооборота")]
        DownloadDocumentFlowArchiveFailed = 1004,

        /// <summary>
        /// Доступ к контенту документа запрещен
        /// </summary>
        [Description("Доступ к контенту документа запрещен")]
        DocumentContentAccessDenied = 1005,

        /// <summary>
        /// Некорректный тип документа
        /// </summary>
        [Description("Некорректный тип документа")]
        InvalidDocumentType = 1006,

        /// <summary>
        /// Обмен документами запрещен
        /// </summary>
        [Description("Обмен документами запрещен")]
        DocumentExchangeIsDenied = 1007,

        #endregion

        #region  Регламенты (2001-2001)

        /// <summary>
        /// Нарушение регламента документооборота
        /// </summary>
        [Description("Нарушение регламента документооборота")]
        WorkflowViolation = 2001,

        #endregion

        #region Связывание (3001-3001)

        /// <summary>
        /// Невозможно связать документы
        /// </summary>
        [Description("Невозможно связать документы")]
        RelationNotAllowed = 3001,

        #endregion

        #region Документы (4001-4004)

        /// TODO@Не используется
        /// <summary>
        /// Возникает при попытке подписать уже подписанный документ (одним и тем же пользователем)
        /// </summary>
        [Description("Попытка подписать уже подписанный документ (одним и тем же пользователем)")]
        SignAlreadyExists = 4001,

        /// TODO@Не используется
        /// TODO Присвоить числовое значение
        /// <summary>
        /// Неправильно указан получатель
        /// </summary>
        [Description("Неправильно указан получатель")]
        InvalidSourceAddress,

        /// TODO Присвоить числовое значение
        /// <summary>
        /// Циклические ссылки в списке документов
        /// </summary>
        [Description("Циклические ссылки в списке документов")]
        CyclicParentReferences,

        /// TODO Присвоить числовое значение
        /// <summary>
        /// Не найден документ, удовлетворяющий критериям поиска
        /// </summary>
        [Description("Не найден документ, удовлетворяющий критериям поиска")]
        DocumentNotFound,

        #endregion

        #region Контрагенты (5001-5001)

        /// <summary>
        /// Ошибка авторизации контрагентов
        /// </summary>
        [Description("Ошибка авторизации контрагентов")]
        AuthorizeContragentError = 5001,

        #endregion

        #region Документооборот (6000-6009)

        /// <summary>
        /// Неизвестная ошибка документооборота
        /// </summary>
        [Description("Неизвестная ошибка документооборота")]
        UnknowDocumentFlowError = 6000,

        /// <summary>
        /// Операция не доступна
        /// </summary>
        [Description("Операция не доступна")]
        OperationIsNotAvailable = 6001,

        /// <summary>
        /// Отправка самому себе запрещена
        /// </summary>
        [Description("Отправка самому себе запрещена")]
        SendToSelfIsNotAllowed = 6002,

        /// <summary>
        /// Отправка от другого контрагента запрещена
        /// </summary>
        [Description("Отправка от другого контрагента запрещена")]
        SendFromOtherIsNotAllowed = 6003,

        /// <summary>
        /// Пересылка документа не доступна
        /// </summary>
        [Description("Пересылка документа не доступна")]
        ForwardIsNotAvailable = 6004,

        /// <summary>
        /// Документ не требует подписания
        /// </summary>
        [Description("Документ не требует подписания")]
        DocumentDoesNotRequireSigning = 6005,

        /// <summary>
        /// Документ уже был подписан
        /// </summary>
        [Description("Документ уже был подписан")]
        DocumentWasAlreadySigned = 6006,

        /// <summary>
        /// Уже было отказано в подписании документа
        /// </summary>
        [Description("Уже было отказано в подписании документа")]
        SignWasAlreadyRejected = 6007,

        /// <summary>
        /// Отправка в роуминг запрещена
        /// </summary>
        [Description("Отправка в роуминг запрещена")]
        SendToRoamingIsNotAllowed = 6008,

        /// <summary>
        /// Недопустимый пользователь получателя
        /// </summary>
        [Description("Недопустимый пользователь получателя")]
        InvalidRecipientUser = 6009,

        #endregion

        #region Конвертация (7001-7001)

        /// <summary>
        /// Ошибка конвертации документа
        /// </summary>
        [Description("Ошибка конвертации документа")]
        DocumentConversionError = 7001,

        #endregion

        #region Простая ЭП (8001-8009)

        /// <summary>
        /// Простая ЭП недействительна.
        /// </summary>
        [Description("Простая ЭП недействительна")]
        SimpleSignatureInvalid = 8001,

        /// <summary>
        /// Некорректный формат простой ЭП.
        /// </summary>
        [Description("Некорректный формат простой ЭП")]
        InvalidSimpleSignatureFormat = 8002,

        /// <summary>
        /// Некорректные проверяемые атрибуты простой ЭП.
        /// </summary>
        [Description("Некорректные проверяемые атрибуты простой ЭП")]
        InvalidSimpleSignatureAttributes = 8003,

        /// <summary>
        /// Некорректное содержимое документа простой ЭП.
        /// </summary>
        [Description("Некорректное содержимое документа простой ЭП")]
        InvalidSimpleSignatureDocument = 8004,

        /// <summary>
        /// Возможность использования простой ЭП отключена.
        /// </summary>
        [Description("Возможность использования простой ЭП отключена")]
        SimpleSignatureDisabled = 8005,

        /// <summary>
        /// Не принят регламент использования простой ЭП.
        /// </summary>
        [Description("Не принят регламент использования простой ЭП")]
        SimpleSignatureRegulationNotAccepted = 8006,

        /// <summary>
        /// Регламент использования простой ЭП уже был принят.
        /// </summary>
        [Description("Регламент использования простой ЭП уже был принят")]
        SimpleSignatureRegulationAlreadyAccepted = 8007,

        /// <summary>
        /// Не указан СНИЛС для использования в простой ЭП.
        /// </summary>
        [Description("Не указан СНИЛС для использования в простой ЭП")]
        SimpleSignatureSnilsNotSpecified = 8008,

        /// <summary>
        /// Недопустимый тип документа для подписания простой ЭП.
        /// </summary>
        [Description("Недопустимый тип документа для подписания простой ЭП")]
        SimpleSignatureDocumentTypeNotAllowed = 8009,

        #endregion
    }
}
