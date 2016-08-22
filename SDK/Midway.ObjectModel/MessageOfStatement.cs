using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class MessageOfStatement
    {
        /// <summary>
        /// Идентификатор сообщения
        /// Не используется при отправке
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Ящик организации
        /// </summary>
        [DataMember]
        public string FromBoxId { get; set; }

        /// <summary>
        /// ИД подразделения отправителя
        /// </summary>
        [DataMember]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// Документ
        /// </summary>
        [DataMember]
        public Document Statement { get; set; }

        /// <summary>
        /// Подпись 
        /// </summary>
        [DataMember]
        public Sign Sign { get; set; }
    }
}
