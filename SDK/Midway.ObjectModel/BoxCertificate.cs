using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ассоциация ящик-сертификат (в контексте авторизованного пользователя)
    /// TODO Надо сюда добавить OraganizationId
    /// </summary>
    [DataContract]
    public class BoxCertificate
    {
        /// <summary>
        /// Адрес организации в сервисе
        /// TODO Это ящик, такая терминология используется в Message; Поле логичнее назвать BoxAddress
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Отпечаток сертификата
        /// </summary>
        [DataMember]
        public string Thumbprint { get; set; }

        /// <summary>
        /// CN сертификата
        /// </summary>
        [DataMember]
        public string CommonName { get; set; }

        /// <summary>
        /// Признак квалифицированного сертификата
        /// </summary>
        [DataMember]
        public bool IsQualified { get; set; }
    }
}