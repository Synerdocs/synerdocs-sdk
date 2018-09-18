using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос на печать документа.
    /// </summary>
    [DataContract]
    public class DocumentPrintingResponse : OperationResponse
    {
        /// <summary>
        /// Печатная форма документа.
        /// </summary>
        [DataMember]
        public NamedContent NamedContent { get; set; }
    }
}
