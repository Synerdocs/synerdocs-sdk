using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание формата документа
    /// </summary>
    [DataContract]
    public class DocumentFormat
    {
        /// <summary>
        /// Информация о типе документа
        /// </summary>
        [DataMember]
        public DocumentTypeInfo DocumentTypeInfo { get; set; }

        /// <summary>
        /// Формат содержимого
        /// </summary>
        [DataMember]
        public ContentFormatEnum ContentFormat { get; set; }

        /// <summary>
        /// Кодировка текста
        /// </summary>
        [DataMember]
        public string Encoding { get; set; }

        /// <summary>
        /// Версия формата
        /// </summary>
        [DataMember]
        public string Version { get; set; }
    }
}
