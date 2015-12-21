using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Список документов
    /// </summary>
    [DataContract]
    public class DocumentList
    {
        /// <summary>
        /// Общее количество документов в списке
        /// </summary>
        [DataMember]
        public int Total { get;set; }

        /// <summary>
        /// Массив документов
        /// </summary>
        [DataMember]
        public DocumentListEntry[] Items { get; set; } 
    }
}