using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус обработки заявки на издание сертификата.
    /// </summary>
    [DataContract]
    public enum CertificateIssueStatus
    {
        /// <summary>
        /// Создана.
        /// </summary>
        [EnumMember]
        [Description("Создана")]
        Created = 0,

        /// <summary>
        /// Запрос сформирован и готов к отправке.
        /// </summary>
        [EnumMember]
        [Description("Готова к отправке")]
        ReadyToSend = 1,
        
        /// <summary>
        /// В запросе имеются ошибки / ошибка при отправке.
        /// </summary>
        [EnumMember]
        [Description("Ошибка")]
        Error = 2,

        /// <summary>
        /// Отправлен.
        /// </summary>
        [EnumMember]
        [Description("Отправлена")]
        Sent = 3,

        /// <summary>
        /// Получен выпущенный сертификат.
        /// </summary>
        [EnumMember]
        [Description("Сертификат получен")]
        Success = 4,

        /// <summary>
        /// Сертификат получен и успешно загружен в сервис.
        /// </summary>
        [EnumMember]
        [Description("Сертификат получен и загружен")]
        CertificateUploaded = 5,

        /// <summary>
        /// Сертификат получен, но его не удалось загрузить в сервис.
        /// </summary>
        [EnumMember]
        [Description("Сертификат получен, ошибка при загрузке")]
        CertificateUploadError = 6,

        /// <summary>
        /// Сертификат получен, но не удалось создать пользователя.
        /// </summary>
        [EnumMember]
        [Description("Сертификат получен, ошибка при создании пользователя")]
        UserCreationError = 7,

        /// <summary>
        /// Сертификат получен, но не удалось создать абонента.
        /// </summary>
        [EnumMember]
        [Description("Сертификат получен, ошибка при создании абонента")]
        SubscriberCreationError = 8
    }
}
