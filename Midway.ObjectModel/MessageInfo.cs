using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// »нформаци€ о сообщении, используетс€ дл€ получени€ списка сообщений из €щика
    /// </summary>
    [DataContract]
    public class MessageInfo
    {
        /// <summary>
        /// »дентификатор сообщени€
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// ящик отправител€
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// ящик адресата
        /// </summary>
        [DataMember]
        public string To { get; set; }

        /// <summary>
        /// ящики получателей
        /// </summary>
        [DataMember]
        public string[] Recipients { get; set; }
    }
}
