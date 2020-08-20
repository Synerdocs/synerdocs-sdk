using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Документ черновика сообщения
    /// </summary>
    [DataContract]
    public class DraftDocument
    {
        /// <summary>
        /// Идентификатор черновика документа
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        [DataMember]
        [Obsolete("Используйте '" + nameof(DocumentTypeInfo) + "'.")]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Тип документа в виде EnumValue
        /// Не используется при отправке
        /// </summary>
        [DataMember]
        [Obsolete("Используйте '" + nameof(DocumentTypeInfo) + "'.")]
        public EnumValue DocumentTypeEnum { get; set; }

        /// <summary>
        /// Информация о типе документа.
        /// </summary>
        [DataMember(IsRequired = false)]
        public DocumentTypeInfo DocumentTypeInfo { get; set; }

        /// <summary>
        /// Вид неформализованного документа.
        /// </summary>
        [DataMember]
        [Obsolete("Используйте '" + nameof(DocumentTypeInfo) + "'.")]
        public string UntypedKind { get; set; }

        /// <summary>
        /// Имя документа
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Размер файла
        /// </summary>
        [DataMember]
        public int FileSize { get; set; }

        /// <summary>
        /// Контент
        /// </summary>
        [DataMember]
        public byte[] Content { get; set; }

        /// <summary>
        /// Карточка
        /// </summary>
        [DataMember]
        public byte[] Card { get; set; }
        
        /// <summary>
        /// Комментарий
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Признак "Требуется подпись получателя"
        /// </summary>
        [DataMember]
        public bool NeedSign { get; set; }

        /// <summary>
        /// Флаг "Необходимость подтверждения факта приема документа"
        /// </summary>
        [DataMember]
        public bool NeedReceipt { get; set; }

        /// <summary>
        /// Статус проверки документа.
        /// </summary>
        [DataMember]
        public EnumValue ValidationStatus { get; set; }

        /// <summary>
        /// Идентификатор родительского документа в цепочке служебных документов
        /// </summary>
        [DataMember]
        public string ParentDocumentId { get; set; }

        /// <summary>
        /// Настройки конвертации документа при загрузке в черновик
        /// Если свойство задано, то при загрузке в черновик будет выполнено преобразование документа
        /// </summary>
        [DataMember]
        public ConversionSettings ConversionSettings { get; set; }

        /// <summary>
        /// Признак того, что документ будет отправлен только участникам документооборота.
        /// </summary>
        [DataMember]
        public bool? SendOnlyToDocumentFlowParticipants { get; set; }

        /// <summary>
        /// Участники документооборота.
        /// </summary>
        [DataMember]
        public DocumentFlowParticipantShortInfo[] DocumentFlowParticipants { get; set; }
    }
}
