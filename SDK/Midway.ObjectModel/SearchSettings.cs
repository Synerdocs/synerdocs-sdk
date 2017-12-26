using System.Collections.Generic;
using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Настройки поиска.
    /// </summary>
    [DataContract]
    public class SearchSettings
    {
        /// <summary>
        /// Условия сортировки.
        /// </summary>
        [DataMember]
        public List<SortCondition> Sorting { get; set; }

        /// <summary>
        /// Условия постраничной выборки.
        /// </summary>
        [DataMember]
        public PageSettings Paging { get; set; }

        /// <summary>
        /// Настройки фильтрации.
        /// </summary>
        [DataMember]
        public FilterSettings FilterSettings { get; set; }
    }
}
