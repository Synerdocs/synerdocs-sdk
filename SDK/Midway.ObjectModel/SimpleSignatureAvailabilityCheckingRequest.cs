using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на проверку доступности использования простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureAvailabilityCheckingRequest : OperationRequest
    {
        /// <summary>
        /// Документ, подписание которого планируется.
        /// </summary>
        [DataMember(IsRequired = true)]
        public SimpleSignatureAvailabilityCheckingDocument Document { get; set; }
    }
}
