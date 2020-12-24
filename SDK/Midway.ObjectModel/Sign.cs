using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Усиленная подпись под документом. Отправляется следующим образом:
    ///  - вместе с документом. В этом случае класс содержит подпись отправителя;
    ///  - отдельно от документа. В этом случае класс содержит подпись получателя.
    /// </summary>
    [DataContract]
    public class Sign : ISignature
    {
        /// <summary>
        /// Идентификатор подписываемого документа.
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; } // uniqueidentifier

        /// <summary>
        /// Содержимое подписи.
        /// </summary>
        [DataMember]
        public byte[] Raw { get; set; } // varbinary(-1)

        /// <summary>
        /// Дата отправки подписи.
        /// </summary>
        [DataMember]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Ящик организации-отправителя подписи.
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// ИД подразделения отправителя подписи.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string FromDepartmentId { get; set; }

        /// TODO@internal а надо ли это делать internal?
        /// <summary>
        /// Идентификатор сообщения, содержащего данную подпись.
        /// </summary>
        public Guid? MessageId { get; set; } // uniqueidentifier

        /// <summary>
        /// Признак подписи.
        /// </summary>
        [DataMember]
        public EnumValue SignatureMark { get; set; }

        /// <summary>
        /// Субъект сертификата подписи.
        /// </summary>
        [DataMember]
        public string Subject { get; set; }
        
        /// <summary>
        /// Идентификатор подписи.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор первоначальной подписи.
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }

        /// TODO: Почему тип не Nullabe?
        /// <summary>
        /// Время из штампа.
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Флаг соответствия подписи документу.
        /// </summary>
        [DataMember]
        public bool IsValid { get; set; }
    }
}
