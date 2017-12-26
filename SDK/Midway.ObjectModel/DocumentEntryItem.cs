using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о вхождении документа.
    /// Один документ может иметь несколько вхождений.
    /// Например оригинальный и несколько пересылок.
    /// Используется для получения списка документов в ящике.
    /// </summary>
    [DataContract]
    public class DocumentEntryItem
    {
        /// <summary>
        /// ИД вхождения
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// ИД документа.
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; }

        /// <summary>
        /// Название документа.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Тип документа.
        /// </summary>
        [DataMember]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Тип документа в виде EnumValue.
        /// </summary>
        [DataMember]
        public EnumValue DocumentTypeEnum { get; set; }

        /// <summary>
        /// Идентификатор сообщения, в котором был загружен документ.
        /// </summary>
        [DataMember]
        public string MessageId { get; set; }

        /// <summary>
        /// Ящик отправителя.
        /// </summary>
        [DataMember]
        public string MessageFrom { get; set; }

        /// <summary>
        /// Название организации-отправителя.
        /// </summary>
        [DataMember]
        public string FromOrganizationName { get; set; }

        /// <summary>
        /// Идентификатор подразделения отправителя.
        /// </summary>
        [DataMember]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// Комментарий к документу.
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Статус документооборота для текущего абонента.
        /// </summary>
        [DataMember]
        public DocumentFlowStatus Status { get; set; }

        /// <summary>
        /// Общий статус по документу, отправленному нескольким контрагентам.
        /// </summary>
        [DataMember]
        public UntypedDocumentMultiFlowStatus MultiStatus { get; set; }

        /// <summary>
        /// Статус аннулирования документа.
        /// </summary>
        [DataMember]
        public DocumentRevocationStatus RevocationStatus { get; set; }

        /// <summary>
        /// Дата отправки.
        /// </summary>
        [DataMember]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Флаг показывает есть ли связанные документы.
        /// </summary>
        [DataMember]
        public bool HasRelatedDocuments { get; set; }

        /// <summary>
        /// Список получателей документа со статусами.
        /// </summary>
        [DataMember]
        public MessageRecipientWithStatus[] Recipients { get; set; }

        /// <summary>
        /// Итоговая стоимость в документе с налогами, НДС и т.п.
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? Sum { get; set; }

        /// <summary>
        /// Номер документа, указанный пользователем.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Number { get; set; }

        /// <summary>
        /// Дата документа, указанная пользователем.
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Сумма НДС для документа.
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? Nds { get; set; }

        /// <summary>
        /// Тип неформализованного документа.
        /// </summary>
        [DataMember]
        public string UntypedKind { get; set; }

        /// <summary>
        /// Флаг "Необходимость подписания документа получателем".
        /// </summary>
        [DataMember]
        public bool NeedSign { get; set; }

        /// <summary>
        /// Флаг "Необходимость подтверждения факта приема документа".
        /// </summary>
        [DataMember]
        public bool NeedReceipt { get; set; }

        /// <summary>
        /// Тип документооборота.
        /// </summary>
        [DataMember]
        public FlowType FlowType { get; set; }

        /// <summary>
        /// Доступные операции над документом в виде битовой маски.
        /// </summary>
        [DataMember]
        public int AvailableOperations { get; set; }

        /// <summary>
        /// Документооборот.
        /// </summary>
        [DataMember]
        public DocumentFlow[] Flows { get; set; }
        
        /// <summary>
        /// Текстовое описание полного текущего статуса документооборота относительно абонента.
        /// </summary>
        [DataMember]
        public DocumentFlowStatusDescription DocumentFlowStatusDescription { get; set; }

        /// <summary>
        /// Теги согласования документа.
        /// </summary>
        [DataMember]
        [Obsolete("Используйте свойство '" + nameof(DocumentTags) + "'.")]
        public DocumentTag[] Tags { get; set; }

        /// <summary>
        /// Все теги документа.
        /// </summary>
        [DataMember]
        public List<DocumentTag> DocumentTags { get; set; }

        /// <summary>
        /// Поле для хранения дополнительной информации.
        /// </summary>
        [DataMember]
        public string CustomField { get; set; }
    }
}
