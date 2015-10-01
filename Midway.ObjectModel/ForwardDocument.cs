using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о пересылаемом документе
    /// Используется только при отправке
    /// </summary>
    [DataContract]
    public class ForwardDocument
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
    }
}
