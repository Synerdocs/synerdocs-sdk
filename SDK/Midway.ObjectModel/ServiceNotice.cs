using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс для хранения информации об ИОП.
    /// </summary>
    [DataContract]
    public class ServiceNotice
    {
        /// <summary>
        /// Понятное имя извещения.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        [DataMember]
        public string FromBoxId { get; set; }

        /// <summary>
        /// Идентификатор подразделения отправителя.
        /// </summary>
        [DataMember]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// Адрес получателя.
        /// </summary>
        [DataMember]
        [Obsolete("Используйте '" + nameof(Recipients) + "'.")]
        public string ToBoxId { get; set; }

        /// <summary>
        /// Идентификатор подразделения получателя.
        /// </summary>
        [DataMember]
        [Obsolete("Используйте '" + nameof(Recipients) + "'.")]
        public string ToDepartmentId { get; set; }

        /// <summary>
        /// Список получателей.
        /// </summary>
        [DataMember]
        public MessageRecipient[] Recipients { get; set; }

        /// <summary>
        /// Идентификатор документа, на который готовится извещение.
        /// </summary>
        [DataMember]
        public string ParentDocumentId { get; set; }

        /// <summary>
        /// Тип документа, на который готовится извещение.
        /// </summary>
        [DataMember]
        public DocumentType ParentDocumentType { get; set; }

        /// <summary>
        /// Признак, указывающий легитимность родительского документа.
        /// </summary>
        [DataMember]
        public bool ParentDocumentIsLegitimate { get; set; }

        /// <summary>
        /// Тип документа (извещения).
        /// </summary>
        [DataMember]
        [Obsolete("Используйте '" + nameof(DocumentTypeInfo) + "'.")]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Информация о типе документа.
        /// </summary>
        [DataMember]
        public DocumentTypeInfo DocumentTypeInfo { get; set; }

        /// <summary>
        /// Контент извещения в BASE64-кодировке.
        /// </summary>
        [DataMember]
        public byte[] Content { get; set; }
    }
}
