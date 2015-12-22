using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Пересылаемый документ черновика сообщения
    /// </summary>
    [DataContract]
    public class DraftForwardDocument
    {
        /// <summary>
        /// Идентификатор оригинального документа
        /// </summary>
        [DataMember]
        public string OriginalDocumentId { get; set; }

        /// <summary>
        /// Комментарий к документу
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Флаг ожидания подписи под документом 
        /// </summary>
        [DataMember]
        public bool NeedSign { get; set; }

        /// <summary>
        /// Связанные документы
        /// </summary>
        [DataMember]
        public DraftForwardDocumentRelation[] RelatedDocuments { get; set; }
    }
}
