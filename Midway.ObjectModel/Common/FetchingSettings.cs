using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Настройки выборки
    /// </summary>
    [DataContract]
    public class FetchingSettings
    {
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
