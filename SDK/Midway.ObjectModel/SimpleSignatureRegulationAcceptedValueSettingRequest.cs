using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на обновление настройки принятия регламента использования простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureRegulationAcceptedValueSettingRequest
    {
        /// <summary>
        /// ИД организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Флаг принятия регламента использования простой ЭП.
        /// </summary>
        /// <c>true</c>, если принят регламент использования простой ЭП.
        [DataMember(IsRequired = true)]
        public bool Value { get; set; }
    }
}
