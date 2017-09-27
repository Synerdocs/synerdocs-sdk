using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Краткая информация о текущем состоянии издания сертификата.
    /// </summary>
    [DataContract]
    public class CertificateIssueShortInfo
    {
        /// <summary>
        /// ИД издания сертификата.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// ИД заявки на издание сертификата.
        /// </summary>
        [DataMember]
        public string RequestId { get; set; }

        /// <summary>
        /// Статус издания сертификата.
        /// </summary>
        [DataMember]
        public EnumValue Status { get; set; }

        /// <summary>
        /// ИД изданного сертификата (заполняется, если сертификат издан).
        /// </summary>
        [DataMember]
        public string CertificateId { get; set; }

        /// <summary>
        /// Информация о произошедшей ошибке.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
