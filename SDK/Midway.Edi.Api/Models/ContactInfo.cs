using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Midway.Edi.Api.Annotations;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Информация о контактном лице
    /// </summary>
    [DataContract]
    public class ContactInfo
    {
        /// <summary>
        /// Имя контактного лица
        /// </summary>
        [DataMember]
        [StringLength(150, ErrorMessage = "Длина должна быть не более {1} символов")]
        public string Name { get; set; }

        /// <summary>
        /// E-mail адрес
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required, ErrorMessage = "Укажите E-mail")]
        [StringLength(100, ErrorMessage = "Длина должна быть не более {1} символов")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [DataMember]
        [StringLength(50, ErrorMessage = "Длина должна быть не более {1} символов")]
        [ReferenceValidation(
            ValidationAttributeType.PhoneFormat,
            ErrorMessage = @"Неправильный телефон, допустимые символы: цифры, пробелы, скобки, дефис, +, -")]
        public string PhoneNumber { get; set; }
    }
}
