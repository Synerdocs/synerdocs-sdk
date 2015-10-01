using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Список вхождений документов
    /// Один документ может иметь несколько вхождений
    /// Например оригинальный и несколько пересылок
    /// Используется для получения списка документов в ящике
    /// </summary>
    [DataContract]
    public class DocumentEntryList
    {
        /// <summary>
        /// Общее количество вхождений документов в списке
        /// </summary>
        [DataMember]
        public int Total { get; set; }

        /// <summary>
        /// Массив вхождений документов
        /// </summary>
        [DataMember]
        public DocumentEntryItem[] Items { get; set; }
    }
}