using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Связь черновика сообщения с документом
    /// </summary>
    [DataContract]
    public class DraftMessageRelation
    {
        /// <summary>
        /// Идентификатор документа
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; }
    }
}
