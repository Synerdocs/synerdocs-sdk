using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация по отказу от подписания.
    /// Используется только при отправке.
    /// Для документов без подписи и пересылаемых.
    /// </summary>
    [DataContract]
    public class RejectSign
    {
        /// <summary>
        /// Ящик отправителя.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string From { get; set; }

        /// <summary>
        /// ИД подразделения отправителя отказа от подписи.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// Идентификатор документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string DocumentId { get; set; }

        /// <summary>
        /// Комментарий (причина отказа).
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Comment { get; set; }
    }
}
