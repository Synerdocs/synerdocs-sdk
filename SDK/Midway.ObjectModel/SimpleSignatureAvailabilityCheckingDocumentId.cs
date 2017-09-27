using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс для обозначения ИД существующего документа, у которого требуется проверить возможность подписания простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureAvailabilityCheckingDocumentId : SimpleSignatureAvailabilityCheckingDocument
    {
        /// <summary>
        /// ИД документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Id { get; set; }
    }
}
