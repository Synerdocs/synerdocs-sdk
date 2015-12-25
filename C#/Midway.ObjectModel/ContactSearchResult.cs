using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Результат поиска контактов
    /// </summary>
    [DataContract]
    public class ContactSearchResult
    {
        /// <summary>
        /// Общее количество контактов, удовлетворяющих критерию поиска
        /// </summary>
        [DataMember]
        public int TotalCount { get; set; }

        /// <summary>
        /// Найденные контакты, ограниченные параметрами From и Max
        /// </summary>
        [DataMember]
        public ContactSearchItem[] Items { get; set; }
    }
}
