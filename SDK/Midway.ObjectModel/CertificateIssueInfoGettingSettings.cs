using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Настройки получения информации о текущем состоянии издания сертификата.
    /// </summary>
    [DataContract]
    public class CertificateIssueInfoGettingSettings
    {
        /// <summary>
        /// Нужно ли включать в ответ заявку на издание сертификата.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IncludeRequest { get; set; } = true;

        /// <summary>
        /// Нужно ли включать в ответ файл заявки на издание сертификата.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IncludeRequestFile { get; set; }

        /// <summary>
        /// Нужно ли включать в ответ выпущенный сертификат.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IncludeCertificate { get; set; } = true;
    }
}
