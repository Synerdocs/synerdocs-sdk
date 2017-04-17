using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при регистрации абонента
    /// </summary>
    [DataContract]
    public class RegistrationResponse
    {
        /// <summary>
        /// Код ответа
        /// </summary>
        [DataMember]
        public EnumValue Code { get; set; }

        /// <summary>
        /// Вложение
        /// </summary>
        [DataMember]
        public RegisteredData Result { get; set; }

        /// <summary>
        /// Результат валидации входной модели данных
        /// </summary>
        [DataMember]
        public ModelValidationResult ValidationResult { get; set; }
    }
}
