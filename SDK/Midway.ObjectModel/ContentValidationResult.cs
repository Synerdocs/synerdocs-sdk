using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Результат валидации контента
    /// </summary>
    [DataContract]
    public class ContentValidationResult
    {
        /// <summary>
        /// Общий статус валидации
        /// </summary>
        [DataMember]
        public EnumValue GeneralStatus { get; set; }

        /// <summary>
        /// Результаты проверки ФЛК
        /// </summary>
        [DataMember]
        public ValidationError[] FormatControlErrors { get; set; }

        /// <summary>
        /// Ошибки XSD
        /// </summary>
        [DataMember]
        public ValidationError[] XsdErrors { get; set; }
    }
}
