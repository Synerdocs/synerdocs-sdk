using Midway.ObjectModel.Common;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Настройки поиска сотрудников абонента.
    /// </summary>
    [DataContract]
    public class EmployeeSearchSettings : SearchSettings
    {
        /// <summary>
        /// Настройки выгрузки данных.
        /// </summary>
        [DataMember]
        public EmployeeLoadingSettings LoadingSettings { get; set; }
    }
}
