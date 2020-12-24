using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Результат поиска черновиков
    /// </summary>
    [DataContract]
    public class DraftMessageSearchResult
    {
        /// <summary>
        /// Общее количество записей по результатам поиска
        /// </summary>
        [DataMember]
        public int TotalCount { get; set; }

        /// <summary>
        /// Найденные черновики
        /// </summary>
        [DataMember]
        public DraftMessage[] Items { get; set; }
    }
}
