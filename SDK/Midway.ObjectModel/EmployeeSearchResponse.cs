using Midway.ObjectModel.Common;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при поиске сотрудников абонента.
    /// </summary>
    [DataContract]
    public class EmployeeSearchResponse
    {
        /// <summary>
        /// Общее количество найденных сотрудников.
        /// </summary>
        [DataMember]
        public int Total { get; set; }

        /// <summary>
        /// Список сотрудников.
        /// </summary>
        [DataMember]
        public List<Employee> Items { get; set; }

        /// <summary>
        /// Использованный пейджинг списка.
        /// </summary>
        [DataMember]
        public PageSettings Paging { get; set; }
    }
}
