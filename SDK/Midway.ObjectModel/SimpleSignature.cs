using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Простая электронная подпись.
    /// </summary>
    [DataContract]
    public class SimpleSignature : ISignature
    {
        /// <summary>
        /// Идентификатор подписи.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор подписанного документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string DocumentId { get; set; }

        /// <summary>
        /// Ящик организации-отправителя.
        /// </summary>
        [DataMember]
        public string SenderBoxId { get; set; }

        /// <summary>
        /// ИД подразделения отправителя.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string SenderDepartmentId { get; set; }

        /// <summary>
        /// Признак подписи.
        /// </summary>
        [DataMember]
        public EnumValue SignatureMark { get; set; }

        /// <summary>
        /// Дата подписания.
        /// </summary>
        [DataMember]
        public DateTime SignedAt { get; set; }

        /// <summary>
        /// Версия подписи.
        /// </summary>
        [DataMember]
        public string Version { get; set; }

        /// <summary>
        /// Реквизиты подписи.
        /// </summary>
        [DataMember]
        public SimpleSignatureRequisites Requisites { get; set; }

        /// <summary>
        /// Хеш проверяемых атрибутов.
        /// </summary>
        [DataMember]
        public byte[] AttributesHash { get; set; }

        /// <summary>
        /// Хеш подписанного документа.
        /// </summary>
        [DataMember]
        public byte[] DocumentHash { get; set; }

        /// <summary>
        /// Код проверки подписи.
        /// </summary>
        [DataMember]
        public byte[] ValidationCode { get; set; }

        /// <summary>
        /// <c>true</c>, если подпись валидна; иначе - <c>false</c>.
        /// </summary>
        [DataMember]
        public bool IsValid { get; set; }

        /// <summary>
        /// Двоичное содержимое подписи.
        /// </summary>
        [DataMember(IsRequired = true)]
        public byte[] Raw { get; set; }
    }
}
