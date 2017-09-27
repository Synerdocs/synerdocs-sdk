using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Модель документооборота.
    /// </summary>
    [DataContract]
    public class DocumentFlow
    {
        /// <summary>
        /// ИД документооборота.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Тип документооборота.
        /// </summary>
        [DataMember]
        public FlowType FlowType { get; set; }

        /// <summary>
        /// Статус документооборота отправителя.
        /// </summary>
        [DataMember]
        public SenderFlowStatus SenderStatus { get; set; }

        /// <summary>
        /// Статус документооборота получателя.
        /// </summary>
        [DataMember]
        public RecipientFlowStatus RecipientStatus { get; set; }

        /// <summary>
        /// Дата документооборота.
        /// </summary>
        [DataMember]
        public DateTime FlowDate { get; set; }

        /// <summary>
        /// Дата подписания документа.
        /// </summary>
        [DataMember]
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// Дата отказа от подписи.
        /// </summary>
        [DataMember]
        public DateTime? RejectDate { get; set; }

        /// <summary>
        /// Дата получения.
        /// </summary>
        [DataMember]
        public DateTime? ReceiveDate { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Организация отправителя.
        /// </summary>
        [DataMember]
        public Organization SenderOrganization { get; set; }

        /// <summary>
        /// Подразделение отправителя.
        /// </summary>
        [DataMember]
        public OrganizationStructureElement SenderDepartment { get; set; }

        /// <summary>
        /// Усиленная подпись отправителя.
        /// </summary>
        [DataMember]
        public Sign SenderSign { get; set; }

        /// <summary>
        /// Простая подпись отправителя.
        /// </summary>
        [DataMember]
        public SimpleSignature SenderSimpleSignature { get; set; }

        /// <summary>
        /// Организация получателя.
        /// </summary>
        [DataMember]
        public Organization RecipientOrganization { get; set; }

        /// <summary>
        /// Подразделение получателя.
        /// </summary>
        [DataMember]
        public OrganizationStructureElement RecipientDepartment { get; set; }

        /// <summary>
        /// Пользователь получателя.
        /// </summary>
        [DataMember]
        public User RecipientUser { get; set; }

        /// <summary>
        /// Усиленная подпись получателя.
        /// </summary>
        [DataMember]
        public Sign RecipientSign { get; set; }

        /// <summary>
        /// Простая подпись получателя.
        /// </summary>
        [DataMember]
        public SimpleSignature RecipientSimpleSignature { get; set; }
    }
}
