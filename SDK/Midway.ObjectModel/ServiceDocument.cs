using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Служебный документ, подписанный усиленной ЭП.
    /// </summary>
    [DataContract]
    public class ServiceDocument : Document
    {
        /// <summary>
        /// Идентификатор подписи.
        /// </summary>
        [DataMember]
        public string SignId { get; set; }

        /// <summary>
        /// Подпись к документу (единственная).
        /// </summary>
        [DataMember]
        public byte[] SignRaw { get; set; }

        /// <summary>
        /// Дата подписи.
        /// </summary>
        [DataMember]
        public DateTime SignDate { get; set; }

        /// <summary>
        /// Адрес абонентского ящика отправителя.
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// Идентификатор подразделения отправителя.
        /// </summary>
        [DataMember]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// Адрес абонентского ящика получателя.
        /// </summary>
        [DataMember]
        public string To { get; set; }

        /// <summary>
        /// Идентификатор подразделения получателя.
        /// </summary>
        [DataMember]
        public string ToDepartmentId { get; set; }

        /// <summary>
        /// Список получателей.
        /// </summary>
        [DataMember]
        public MessageRecipient[] Recipients { get; set; }

        /// <summary>
        /// Штамп времени.
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Флаг соответствия подписи документу.
        /// </summary>
        [DataMember]
        public bool IsValidSign { get; set; }
    }
}