using System.Runtime.Serialization;

namespace Midway.Edi.Api.Errors
{
    /// <summary>
    /// Результат валидации модели
    /// </summary>
    [DataContract]
    public class ModelValidationResult
    {
        /// <summary>
        /// Итоговый статус валидации
        /// </summary>
        [DataMember]
        public ValidationMessageStatusEnum Status { get; set; }

        /// <summary>
        /// Сообщения валидации модели
        /// </summary>
        [DataMember]
        public ModelValidationMessage[] Messages { get; set; }

        /// <summary>
        /// Результаты валидации полей
        /// </summary>
        [DataMember]
        public ModelValidationResult[] Fields { get; set; }

        /// <summary>
        /// Наименование элемента
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
