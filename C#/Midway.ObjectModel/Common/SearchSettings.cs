using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Настройки поиска
    /// </summary>
//    [DataContract]
    public class SearchSettings
    {
        /// <summary>
        /// Настройки фильтра
        /// </summary>
        [DataMember]
        public FilterCondition[] Filter { get; set; }

        /// <summary>
        /// Настройки сортировки
        /// </summary>
        [DataMember]
        public SortingSetting[] Sorting { get; set; }

        /// <summary>
        /// Настройки постраничной выборки
        /// </summary>
        [DataMember]
        public PageSettings Paging { get; set; }
    }
}
