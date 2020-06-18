using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// QR-код выпущенного сертификата.
    /// </summary>
    [DataContract]
    public class IssuedCertificateQrCode
    {
        /// <summary>
        /// Содержимое QR-кода (в формате GIF).
        /// </summary>
        [DataMember]
        public byte[] Raw { get; set; }

        /// <summary>
        /// Дата и время выпуска QR-кода.
        /// </summary>
        [DataMember]
        public DateTime? IssuedAt { get; set; }
    }
}
