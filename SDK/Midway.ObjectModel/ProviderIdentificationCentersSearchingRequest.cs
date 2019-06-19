using System.Runtime.Serialization;

namespace Midway.ObjectModel
{   
    /// <summary>
    /// Запрос на поиск центров идентификации облачного провайдера по коду провайдера, коду региона субъекта РФ и статусу центра.
    /// </summary>
    [DataContract]
    public class ProviderIdentificationCentersSearchingRequest
    {
        /// <summary>
        /// Тип провайдера облачной ЭП, для провайдера "Калуга Астрал" подставляем Code = 1.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue CloudProviderType { get; set; }

        /// <summary>
        /// Код региона субъекта РФ.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string RegionCode { get; set; }

        /// <summary>
        /// Статус центра идентификации Active/Inactive.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue ActivityStatus { get; set; }
    }
}