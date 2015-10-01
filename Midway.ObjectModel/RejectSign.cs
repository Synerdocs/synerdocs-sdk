using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация по отказу от подписания
    /// Используется только при отправке
    /// Для документов без подписи и пересылаемых
    /// </summary>
    [DataContract]
    public class RejectSign
    {
        /// <summary>
        /// Ящик отправителя
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// Идентификатор документа
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; }

        /// <summary>
        /// Комментарий (причина отказа)
        /// </summary>
        [DataMember]
        public string Comment { get; set; }
    }
}
