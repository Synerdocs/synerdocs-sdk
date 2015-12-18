using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус проверки сертификата
    /// </summary>
    [DataContract]
    public enum CertificateValidationStatus
    {
        /// <summary>
        /// Недоступно
        /// </summary>
        [EnumMember]
        Unavailable = 0x00,

        /// <summary>
        /// Успешно
        /// </summary>
        [EnumMember]
        Success = 0x01,

        /// <summary>
        /// Ошибка
        /// </summary>
        [EnumMember]
        Error = 0x02,

        /// <summary>
        /// Предупреждение
        /// </summary>
        [EnumMember]
        Warning = 0x03
    }
}
