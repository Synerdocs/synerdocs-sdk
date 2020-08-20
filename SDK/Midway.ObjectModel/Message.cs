using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сообщения, используется для отправки и чтения.
    /// </summary>
    [DataContract]
    public class Message : IMessage
    {
        public Message()
        {
            Documents = new Document[0];
            Signs = new Sign[0];
            SimpleSignatures = new SimpleSignature[0];
        }

        /// <summary>
        /// Идентификатор сообщения. 
        /// Не используется при отправке.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Ящик отправителя.
        /// Используется при отправке.
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// ИД подразделения отправителя.
        /// </summary>
        [DataMember]
        public string FromDepartment { get; set; }

        /// <summary>
        /// Ящик получателя.
        /// Используется при отправке.
        /// </summary>
        [Obsolete("Используйте '" + nameof(Recipients) + "'.")]
        [DataMember]
        public string To { get; set; }

        /// <summary>
        /// ИД подразделения получателя.
        /// </summary>
        [Obsolete("Используйте '" + nameof(Recipients) + "'.")]
        [DataMember]
        public string ToDepartment { get; set; }

        /// <summary>
        /// Получатели сообщения.
        /// </summary>
        [DataMember]
        public MessageRecipient[] Recipients { get; set; }

        /// <summary>
        /// Время приема сообщения.
        /// не используется при отправке.
        /// </summary>
        [DataMember]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Документы.
        /// </summary>
        [DataMember]
        public Document[] Documents {get;set;}

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
