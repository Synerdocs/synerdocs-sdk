using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Карточка документа из роуминга.
    /// </summary>
    [DataContract]
    public class RoamingDocumentCard
    {
        /// <summary>
        /// Внутренний ИД документа.
        /// </summary>
        [DataMember]
        public string InternalDocumentId { get; set; }

        /// <summary>
        /// ИД сделки.
        /// </summary>
        [DataMember]
        public string DealId { get; set; }

        /// <summary>
        /// Дополнительные данные по документу.
        /// </summary>
        [DataMember]
        public AdditionalDocumentData AdditionalData { get; set; }
    }
}
