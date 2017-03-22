using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о типе документа
    /// </summary>
    [DataContract]
    public class DocumentTypeInfo
    {
        /// <summary>
        /// Тип документа
        /// </summary>
        [DataMember]
        public DocumentTypeEnum DocumentType { get; set; }

        /// <summary>
        /// Вид неформализованного документа
        /// </summary>
        [DataMember]
        public string UntypedKind { get; set; }
    }
}
