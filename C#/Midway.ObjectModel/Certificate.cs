using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация по сертификату
    /// </summary>
    [DataContract]
    public class Certificate
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [DataMember]
        public int CertificateId { get; set; }

        /// <summary>
        /// Признак "Квалифицированный сертификат"
        /// </summary>
        [DataMember]
        public bool QualifiedCertificate { get; set; }

        /// <summary>
        /// Серийный номер
        /// </summary>
        [DataMember]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Начало срока действия сертификата
        /// </summary>
        [DataMember]
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// Конец срока действия сертификата
        /// </summary>
        [DataMember]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Открытый ключ
        /// </summary>
        [DataMember]
        public byte[] PublicKey { get; set; }

        /// <summary>
        /// Издатель
        /// </summary>
        [DataMember]
        public string IssuerName { get; set; }
        
        /// <summary>
        /// Алгоритм подписи
        /// </summary>
        [DataMember]
        public string SignatureAlgorithm { get; set; }
        
        /// <summary>
        /// Владелец
        /// </summary>
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// Контент
        /// </summary>
        [DataMember]
        public byte[] Raw { get; set; }
        
        /// <summary>
        /// Отпечаток сертификата
        /// </summary>
        [DataMember]
        public string Thumbprint { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [DataMember]
        public string Login { get; set; }

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [DataMember]
        public string OrganizationId { get; set; }
       
        /// <summary>
        /// Признак "Тестовый сертификат"
        /// </summary>
        [DataMember]
        public bool IsTest { get; set; }
    }
}
