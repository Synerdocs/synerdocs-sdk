using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о версии типа документа.
    /// </summary>
    [DataContract]
    public class DocumentTypeVersion
    {
        /// <summary>
        /// Тип документа.
        /// Соответствует перечислению <see cref="Midway.ObjectModel.DocumentType"/>
        /// </summary>
        [DataMember]
        public EnumValue DocumentType { get; set; }

        /// <summary>
        /// Номер версии типа документа.
        /// </summary>
        [DataMember]
        public int VersionNumber { get; set; }

        /// <summary>
        /// Наименование версии.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Дата и время начала действия (включая границу).
        /// Если не заполнено, то бессрочно.
        /// </summary>
        [DataMember]
        public DateTimeOffset? ValidFrom { get; set; }

        /// <summary>
        /// Дата и время окончания действия (не включая границу).
        /// Если не заполнено, то бессрочно.
        /// </summary>
        [DataMember]
        public DateTimeOffset? ValidTo { get; set; }
    }
}