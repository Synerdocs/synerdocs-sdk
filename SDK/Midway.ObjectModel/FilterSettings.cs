using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Настройки фильтрации.
    /// </summary>
    [DataContract]
    public class FilterSettings
    {
        /// <summary>
        /// Настройки фильтра.
        /// </summary>
        [DataMember]
        public FilterConditionBase Filter { get; set; }

        /// <summary>
        /// Строка для поиска.
        /// </summary>
        [DataMember]
        public string SearchString { get; set; }
    }
}
