using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при создании неактивного абонента
    /// </summary>
    [DataContract]
    public class NonActiveSubscriberCreationResponse
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
        public NonActiveSubscriber Result { get; set; }

        /// <summary>
        /// Результат валидации входной модели данных
        /// </summary>
        [DataMember]
        public ModelValidationResult ValidationResult { get; set; }
    }
}
