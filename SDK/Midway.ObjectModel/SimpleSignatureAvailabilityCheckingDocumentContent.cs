using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс для обозначения содержимого документа, у которого требуется проверить возможность подписания простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureAvailabilityCheckingDocumentContent : SimpleSignatureAvailabilityCheckingDocument
    {
        /// <summary>
        /// Содержимое документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public byte[] Content { get; set; }
    }
}
