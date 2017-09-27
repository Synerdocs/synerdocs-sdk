using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при проверки доступности использования простой ЭП.
    /// </summary>
    [DataContract]
    [KnownType(typeof(SimpleSignatureAvailabilityStatus))]
    public class SimpleSignatureAvailabilityCheckingResponse : OperationResponse
    {
        /// <summary>
        /// Статус доступности использования простой ЭП.
        /// </summary>
        [DataMember]
        public EnumValue AvailabilityStatus { get; set; }
    }
}
