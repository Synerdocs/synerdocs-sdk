using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о сообщении, используется для получения списка сообщений из ящика
    /// </summary>
    [DataContract]
    public class MessageInfo
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Ящик отправителя
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// Подразделение отправителя.
        /// </summary>
        [DataMember]
        public string FromDepartment { get; set; }

        /// <summary>
        /// Ящик адресата
        /// </summary>
        [DataMember]
        public string To { get; set; }

        /// <summary>
        /// Ящики получателей
        /// </summary>
        [DataMember]
        [Obsolete("Используйте свойство '" + nameof(MessageRecipients) + "'.")]
        public string[] Recipients { get; set; }

        /// <summary>
        /// Получатели.
        /// </summary>
        [DataMember]
        public MessageRecipient[] MessageRecipients { get; set; }
    }
}
