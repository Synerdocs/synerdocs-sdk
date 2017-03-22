using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Midway.Edi.Api.Common;
using Midway.Edi.Api.Annotations;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Информация о реквизитах сущности (органзации, точки доставки/отправки и т.д.)
    /// </summary>
    [DataContract]
    public class RequisitesInfo
    {
        /// <summary>
        /// Тип бизнес-сущности
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите тип бизнес-сущности")]
        [EnumValueValidation(typeof(BusinessEntityType), ErrorMessage = "Недопустимый тип бизнес-сущности")]
        public BusinessEntityTypeEnum BusinessEntityType { get; set; }

        /// <summary>
        /// Тип бизнес-сущности в виде перечисления
        /// Для внутреннего использования
        /// </summary>
        public BusinessEntityType BusinessEntityTypeEnum => BusinessEntityType?.Value
            ?? (BusinessEntityType?)(BusinessEntityType?.Code)
            ?? Models.BusinessEntityType.Unknown;

        /// <summary>
        /// ИНН
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите ИНН")]
        [ReferenceValidation(
            ValidationAttributeType.LegalEntityInnFormat,
            nameof(BusinessEntityTypeEnum),
            Models.BusinessEntityType.LegalEntity,
            ErrorMessage = "Неверный формат ИНН для ЮЛ")]
        [ReferenceValidation(
            ValidationAttributeType.IndividualInnFormat,
            nameof(BusinessEntityTypeEnum),
            Models.BusinessEntityType.IndividualEntrepreneur,
            ErrorMessage = "Неверный формат ИНН для ИП")]
        public string Inn { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        [DataMember]
        [ReferenceValidation(
            ValidationAttributeType.Required,
            nameof(BusinessEntityTypeEnum),
            Models.BusinessEntityType.LegalEntity,
            ErrorMessage = "Укажите КПП")]
        [ReferenceValidation(
            ValidationAttributeType.KppFormat,
            nameof(BusinessEntityTypeEnum),
            Models.BusinessEntityType.LegalEntity,
            ErrorMessage = "Неверный формат КПП")]
        public string Kpp { get; set; }

        /// <summary>
        /// ОГРН
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите ОГРН")]
        [ReferenceValidation(
            ValidationAttributeType.LegalEntityOgrnFormat,
            nameof(BusinessEntityTypeEnum),
            Models.BusinessEntityType.LegalEntity,
            ErrorMessage = "Неверный формат ОГРН для ЮЛ")]
        [ReferenceValidation(
            ValidationAttributeType.IndividualOgrnFormat,
            nameof(BusinessEntityTypeEnum),
            Models.BusinessEntityType.IndividualEntrepreneur,
            ErrorMessage = "Неверный формат ОГРН для ИП")]
        public string Ogrn { get; set; }
    }
}
