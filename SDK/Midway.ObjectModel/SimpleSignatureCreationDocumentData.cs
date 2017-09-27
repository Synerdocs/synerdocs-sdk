using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс для обозначения данных (типа и содержимого) нового документа, подписываемого простой ЭП.
    /// </summary>
    [DataContract]
    [KnownType(typeof(DocumentType))]
    public class SimpleSignatureCreationDocumentData : SimpleSignatureCreationDocument
    {
        /// <summary>
        /// Информация о типе документа.
        /// </summary>
        [DataMember]
        public DocumentTypeInfo DocumentTypeInfo { get; set; }

        /// <summary>
        /// Содержимое документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public byte[] Content { get; set; }
    }
}
