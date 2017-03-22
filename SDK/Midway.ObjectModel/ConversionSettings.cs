using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Настройки конвертации документов
    /// </summary>
    [DataContract]
    public class ConversionSettings
    {
        /// <summary>
        /// Исходный формат для конвертации документа
        /// Для незаполненных полей будет попытка определить их автоматически из содержимого документа
        /// </summary>
        [DataMember]
        public DocumentFormat SourceFormat { get; set; }

        /// <summary>
        /// Целевой формат для конвертации документа
        /// Для незаполненных полей будет использовано значение по умолчанию
        /// </summary>
        [DataMember]
        public DocumentFormat TargetFormat { get; set; }
    }
}
