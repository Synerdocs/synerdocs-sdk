using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Изданный сертификат.
    /// </summary>
    [DataContract]
    public class IssuedCertificate
    {
        /// <summary>
        /// ИД сертификата.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Отпечаток сертификата.
        /// </summary>
        [DataMember]
        public string Thumbprint { get; set; }

        /// <summary>
        /// Содержимое сертификата.
        /// </summary>
        [DataMember]
        public byte[] Raw { get; set; }

        /// <summary>
        /// Дата начала действия сертификата.
        /// </summary>
        [DataMember]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Дата окончания действия сертификата.
        /// </summary>
        [DataMember]
        public DateTime ValidTo { get; set; }
    }
}
