using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сгенерированный контент документа с результатом валидации
    /// </summary>
    [DataContract]
    public class GeneratedContent
    {
        /// <summary>
        /// Результат валидации
        /// </summary>
        [DataMember]
        public ContentValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Сгенерированный контент
        /// </summary>
        [DataMember]
        public NamedContent NamedContent { get; set; }
    }
}
