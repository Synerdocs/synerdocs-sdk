using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация об издании сертификата.
    /// </summary>
    [DataContract]
    public class CertificateIssueInfo : CertificateIssueShortInfo
    {
        /// <summary>
        /// Заявка на издание сертификата.
        /// </summary>
        [DataMember]
        public CertificateIssueRequest Request { get; set; }

        /// <summary>
        /// Файл заявки на издание сертификата.
        /// </summary>
        [DataMember]
        public NamedContent RequestFile { get; set; }

        /// <summary>
        /// Изданный сертификат (заполняется, если сертификат издан).
        /// </summary>
        [DataMember]
        public IssuedCertificate Certificate { get; set; }

        /// <summary>
        /// QR-код (заполняется, если сертификат издан и выпускается по технологии DSS).
        /// </summary>
        [DataMember]
        public IssuedCertificateQrCode CertificateQrCode { get; set; }
    }
}
