using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Midway.Edi.Api.Annotations;
using Midway.Edi.Api.Common;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Точка доставки/отправки
    /// </summary>
    [DataContract]
    public class EdiLocation
    {
        /// <summary>
        /// ИД точки доставки/отправки
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Ящик организации
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите ящик организации")]
        public string OrganizationBox { get; set; }

        /// <summary>
        /// Наименование точки доставки/отправки
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите наименование")]
        [StringLength(200, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string Name { get; set; }

        /// <summary>
        /// GLN (Global Location Number)
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.GlnFormat, ErrorMessage = "Неверный формат GLN")]
        [ReferenceValidation(ValidationAttributeType.GS1CheckDigit, ErrorMessage = "Некорректный номер GLN")]
        public string Gln { get; set; }

        /// <summary>
        /// Статус обработки заявки на регистрацию
        /// Не используется при отправке
        /// </summary>
        [DataMember]
        public EdiRequestStatusEnum RequestStatus { get; set; }

        /// <summary>
        /// Реквизиты
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите реквизиты")]
        public RequisitesInfo Requisites { get; set; }

        /// <summary>
        /// Контактное лицо
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите контактное лицо")]
        public ContactInfo Contact { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите адрес")]
        public AddressInfo Address { get; set; }

        /// <summary>
        /// Дата и время создания записи
        /// Не используется при отправке
        /// </summary>
        [DataMember]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Дата и время изменения записи
        /// Не используется при отправке
        /// </summary>
        [DataMember]
        public DateTime? ModifyDate { get; set; }
    }
}
