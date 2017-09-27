using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на создание заявки на издание сертификата.
    /// </summary>
    [DataContract]
    public class CertificateIssueRequestCreationRequest
    {
        /// <summary>
        /// Тип провайдера облачной ЭП.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue CloudProviderType { get; set; }

        /// <summary>
        /// Идентификатор учетной записи абонента.
        /// </summary>
        [DataMember]
        public string CloudSubscriberId { get; set; }

        /// <summary>
        /// Тип заявки.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue RequestType { get; set; }

        /// <summary>
        /// Идентификатор партнера.
        /// </summary>
        [DataMember]
        public string PartnerId { get; set; }

        /// <summary>
        /// Реквизиты организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public CertificateOrganization Organization { get; set; }

        /// <summary>
        /// Представители организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public CertificateOrganizationRepresentative Representative { get; set; }

        /// <summary>
        /// Идентификатор проекта подключения / интеграции.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string IntegrationProjectId { get; set; }
    }
}
