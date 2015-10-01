using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сообщение с пересылаемыми документами
    /// Используется только при отправке
    /// </summary>
    [DataContract]
    public class ForwardMessage
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
        /// Отправляемые документы
        /// </summary>
        [DataMember]
        public Document[] Documents { get; set; }

        /// <summary>
        /// Подписи к отправляемым документам
        /// </summary>
        [DataMember]
        public Sign[] Signs { get; set; }

        /// <summary>
        /// Пересылаемые документы
        /// </summary>
        [DataMember]
        public ForwardDocument[] ForwardDocuments { get; set; }
    }
}
