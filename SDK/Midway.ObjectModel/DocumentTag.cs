using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Дополнительный статус документа.
    /// </summary>
    [DataContract]
    public class DocumentTag
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Ящик организации.
        /// </summary>
        [DataMember]
        public string OrganizationBoxId { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [DataMember]
        public string Login  { get; set; }

        /// <summary>
        /// Идентификатор документа.
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; }

        /// <summary>
        /// Тип тэга документа.
        /// </summary>
        [DataMember]
        [Obsolete("Используйте '" + nameof(TagTypeEnum) + "' .")]
        public DocumentTagType TagType { get; set; }

        /// <summary>
        /// Тип тэга документа.
        /// </summary>
        [DataMember]
        public EnumValue TagTypeEnum { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Информация о пользователе.
        /// </summary>
        [DataMember]
        public TagUser User { get; set; }
    }
}
