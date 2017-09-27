using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на создание заявки на издание сертификата из файла.
    /// </summary>
    [DataContract]
    public class CertificateIssueRequestFromFileCreationRequest
    {
        /// <summary>
        /// Имя и содержимое файла
        /// </summary>
        [DataMember(IsRequired = true)]
        public NamedContent File { get; set; }

        /// <summary>
        /// Тип провайдера облачной ЭП.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue CloudProviderType { get; set; }

        /// <summary>
        /// ИД проекта подключения / интеграции.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string IntegrationProjectId { get; set; }
    }
}
