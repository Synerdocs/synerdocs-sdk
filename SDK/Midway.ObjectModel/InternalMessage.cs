using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Внутреннее сообщение, используется для отправки.
    /// </summary>
    [DataContract]
    public class InternalMessage : IMessage
    {
        /// <summary>
        /// Идентификатор сообщения.
        /// Не используется при отправке.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Ящик организации.
        /// </summary>
        [DataMember]
        public string BoxId { get; set; }

        /// <summary>
        /// ИД подразделения отправителя.
        /// </summary>
        [DataMember]
        public string FromDepartment { get; set; }

        /// <summary>
        /// Получатели сообщения.
        /// </summary>
        [DataMember]
        public InternalMessageRecipient[] Recipients { get; set; }

        /// <summary>
        /// Документы.
        /// </summary>
        [DataMember]
        public Document[] Documents { get; set; }

        /// <summary>
        /// Усиленные подписи.
        /// </summary>
        [DataMember]
        public Sign[] Signs { get; set; }

        /// <summary>
        /// Простые подписи.
        /// </summary>
        [DataMember]
        public SimpleSignature[] SimpleSignatures { get; set; }
    }
}
