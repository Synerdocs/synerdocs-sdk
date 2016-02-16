using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Черновик сообщения
    /// </summary>
    [DataContract]
    public class DraftMessage
    {
        /// <summary>
        /// ИД сообщения
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Ящик организации-отправителя
        /// </summary>
        [DataMember]
        public string SenderBoxId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Признак "Связать документы"
        /// </summary>
        [DataMember]
        public bool BindDocuments { get; set; }

        /// <summary>
        /// Режим отправки сообщения
        /// Если не задан, то используется
        /// <c>DraftMessageSendMode.External</c>
        /// (отправка внешнему контрагенту)
        /// </summary>
        [DataMember]
        public DraftMessageSendMode? SendMode { get; set; }

        /// <summary>
        /// Черновики документов
        /// </summary>
        [DataMember]
        public DraftDocument[] Documents { get; set; }

        /// <summary>
        /// Получатели
        /// </summary>
        [DataMember]
        public MessageRecipient[] Recipients { get; set; }

        /// <summary>
        /// Внутренние получатели
        /// </summary>
        [DataMember]
        public InternalMessageRecipient[] InternalRecipients { get; set; }

        /// <summary>
        /// Связанные документы
        /// </summary>
        [DataMember]
        public DraftMessageRelation[] RelatedDocuments { get; set; }

        /// <summary>
        /// Пересылаемые документы
        /// </summary>
        [DataMember]
        public DraftForwardDocument[] ForwardDocuments { get; set; }
    }
}
