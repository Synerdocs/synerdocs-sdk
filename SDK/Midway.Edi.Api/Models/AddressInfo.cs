using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Midway.Edi.Api.Common;
using Midway.Edi.Api.Annotations;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Информация об адресе
    /// </summary>
    [DataContract]
    public class AddressInfo
    {
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        [DataMember]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Длина должна быть равна {1} символам")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.CodeNameRequired, ErrorMessage = "Укажите страну")]
        [DictionaryValidation(
            ValidationAttributeType.CodeDictionary,
            ValidationDictionaryKind.OKSM,
            ErrorMessage = "Укажите код страны в соответствии со справочником")]
        [DictionaryValidation(
            ValidationAttributeType.NameDictionary,
            ValidationDictionaryKind.OKSM,
            ErrorMessage = "Укажите наименование страны в соответствии со справочником")]
        [DictionaryValidation(
            ValidationAttributeType.CodeNameDictionary,
            ValidationDictionaryKind.OKSM,
            ErrorMessage = "Код страны не соответствует наименованию")]
        public CodeName Country { get; set; }

        /// <summary>
        /// Регион (область, край, республика)
        /// </summary>
        [DataMember]
        [ReferenceValidation(
            ValidationAttributeType.CodeNameRequired,
            nameof(IsForeign), false,
            ErrorMessage = "Укажите регион")]
        [DictionaryValidation(
            ValidationAttributeType.CodeDictionary,
            ValidationDictionaryKind.RegionRF,
            nameof(IsForeign), false,
            ErrorMessage = "Укажите код региона в соответствии со справочником")]
        [DictionaryValidation(
            ValidationAttributeType.NameDictionary,
            ValidationDictionaryKind.RegionRF,
            nameof(IsForeign), false,
            ErrorMessage = "Укажите наименование региона в соответствии со справочником")]
        [DictionaryValidation(
            ValidationAttributeType.CodeNameDictionary,
            ValidationDictionaryKind.RegionRF,
            nameof(IsForeign), false,
            ErrorMessage = "Код региона не соответствует наименованию")]
        public CodeName Region { get; set; }

        /// <summary>
        /// Район
        /// </summary>
        [DataMember]
        [StringLength(150, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string District { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [DataMember]
        [StringLength(150, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string City { get; set; }

        /// <summary>
        /// Населенный пункт
        /// </summary>
        [DataMember]
        [StringLength(100, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string Locality { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [DataMember]
        [StringLength(200, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        [DataMember]
        [StringLength(20, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string House { get; set; }

        /// <summary>
        /// Корпус (строение)
        /// </summary>
        [DataMember]
        [StringLength(20, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string Building { get; set; }

        /// <summary>
        /// Квартира (офис)
        /// </summary>
        [DataMember]
        [StringLength(50, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string Apartment { get; set; }

        /// <summary>
        /// Иностранный адрес
        /// </summary>
        [DataMember]
        [StringLength(1000, ErrorMessage = "Длина должна быть не более {1} символов")]
        [ReferenceValidation(
            ValidationAttributeType.Required,
            nameof(IsForeign), true,
            ErrorMessage = "Укажите адрес")]
        public string ForeignAddress { get; set; }

        /// <summary>
        /// Является ли адрес иностранным
        /// Не используется при отправке
        /// </summary>
        [DataMember]
        public bool IsForeign { get; set; }

        /// <summary>
        /// Полное строковое представление адреса
        /// Не используется при отправке
        /// </summary>
        [DataMember]
        public string FullAddress { get; set; }
    }
}
