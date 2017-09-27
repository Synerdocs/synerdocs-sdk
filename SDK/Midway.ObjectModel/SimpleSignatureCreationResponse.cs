using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при создании простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureCreationResponse : OperationResponse
    {
        /// <summary>
        /// Результат создания простой ЭП.
        /// </summary>
        [DataMember]
        public SimpleSignature Signature { get; set; }
    }
}
