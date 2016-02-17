using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о сертификате, по которому возможна авторизация
    /// </summary>
    [DataContract]
    public class CertificateCheckInfo
    {
        /// <summary>
        /// Отпечаток
        /// </summary>
        [DataMember]
        public string Thumbprint { get; set; }

        /// <summary>
        /// ИД абонента если это облачный сертификат в удаленном сервисе
        /// </summary>
        [DataMember]
        public string CloudAbonentId { get; set; }

        /// <summary>
        /// Флаг облачность (сейчас это только для Калуга Астрал сертификатов)
        /// </summary>
        [DataMember]
        public bool IsCloud { get; set; }
    }
}
