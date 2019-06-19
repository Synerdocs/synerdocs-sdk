using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о вхождении документа
    /// Один документ может иметь несколько вхождений
    /// Например оригинальный и несколько пересылок
    /// Используется в полной информации по документу
    /// </summary>
    [DataContract]
    public class DocumentEntry
    {
        /// <summary>
        /// ИД вхождения
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// ИД документа
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; }

        /// <summary>
        /// Тип документооборота
        /// </summary>
        [DataMember]
        public FlowType FlowType { get; set; }

        /// <summary>
        /// Дата отправки документа
        /// </summary>
        [DataMember]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Флаг необходимости подписания
        /// </summary>
        [DataMember]
        public bool NeedSign { get; set; }

        /// <summary>
        /// Флаг необходимости подтверждения получения
        /// </summary>
        [DataMember]
        public bool NeedReceipt { get; set; }

        /// <summary>
        /// Комментарий к вхождению
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Ящик организации отправителя
        /// </summary>
        [DataMember]
        public string OrganizationBox { get; set; }

        /// <summary>
        /// Название организации отправителя.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// ИД подразделения отправителя
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Название подразделения отправителя.
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Документооборот
        /// </summary>
        [DataMember]
        public DocumentFlow[] Flows { get; set; }

        /// <summary>
        /// Текстовое описание статуса документооборота
        /// </summary>
        [DataMember]
        public DocumentFlowStatusDescription DocumentFlowStatusDescription { get; set; }

        /// <summary>
        /// Ограничение на отправку документа только участникам документооборота.
        /// </summary>
        [DataMember]
        public bool? SendOnlyToDocumentFlowParticipants { get; set; }

        /// <summary>
        /// Список ролей участника-отправителя в рамках документооборота.
        /// </summary>
        [DataMember]
        public List<EnumValue> SenderRoles { get; set; }
    }
}
