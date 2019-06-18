using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Центр идентификации провайдера облачной ЭП.
    /// </summary>
    [DataContract]
    public class ProviderIdentificationCenter
    {
        /// <summary>
        /// Центр идентификации.
        /// </summary>
        [DataMember]
        public IdentificationCenter IdentificationCenter { get; set; }

        /// <summary>
        /// ИД центра идентификации, используемый у провайдера облачной ЭП.
        /// </summary>
        [DataMember]
        public string IdentificationCenterExternalId { get; set; }

        /// <summary>
        /// Статус работы.
        /// </summary>
        [DataMember]
        public EnumValue ActivityStatus { get; set; }
    }
}