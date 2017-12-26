using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс для обозначения информации о типе документа документа,
    /// у которого требуется проверить возможность подписания простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureAvailabilityCheckingDocumentType : SimpleSignatureAvailabilityCheckingDocument
    {
        /// <summary>
        /// Информация о типе документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public DocumentTypeInfo DocumentTypeInfo { get; set; }
    }
}
