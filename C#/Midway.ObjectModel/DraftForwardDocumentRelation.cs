using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Связь пересылаемого документа с другим документом
    /// </summary>
    [DataContract]
    public class DraftForwardDocumentRelation
    {
        /// <summary>
        /// Идентификатор документа
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; }
    }
}
