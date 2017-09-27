using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Заявка на издание сертификата.
    /// </summary>
    [DataContract]
    public class CertificateIssueRequest
    {
        /// <summary>
        /// ИД заявки на издание сертификата.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Тип провайдера облачной ЭП.
        /// </summary>
        [DataMember]
        public EnumValue CloudProviderType { get; set; }

        /// <summary>
        /// Идентификатор учетной записи абонента.
        /// </summary>
        [DataMember]
        public string CloudSubscriberId { get; set; }

        /// <summary>
        /// Тип заявки.
        /// </summary>
        [DataMember]
        public EnumValue RequestType { get; set; }

        /// <summary>
        /// Идентификатор партнера.
        /// </summary>
        [DataMember]
        public string PartnerId { get; set; }

        /// <summary>
        /// Реквизиты организации.
        /// </summary>
        [DataMember]
        public CertificateOrganization Organization { get; set; }

        /// <summary>
        /// Представитель организации.
        /// </summary>
        [DataMember]
        public CertificateOrganizationRepresentative Representative { get; set; }
        
        /// <summary>
        /// ИД проекта подключения / интеграции.
        /// </summary>
        [DataMember]
        public string IntegrationProjectId { get; set; }
    }
}
