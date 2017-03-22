using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сообщение с документами без подписи
    /// Используется только при отправке
    /// </summary>
    [DataContract]
    public class UnsignedMessage : IMessage
    {
        /// <summary>
        /// Ящик отправителя.
        /// Используется при отправке.
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// ИД подразделения отправителя.
        /// Используется при отправке.
        /// </summary>
        [DataMember]
        public string FromDepartment { get; set; }

        /// <summary>
        /// Получатели сообщения
        /// </summary>
        [DataMember]
        public MessageRecipient[] Recipients { get; set; }

        /// <summary>
        /// Документы без подписи
        /// </summary>
        [DataMember]
        public Document[] Documents {get;set;}
    }
}
