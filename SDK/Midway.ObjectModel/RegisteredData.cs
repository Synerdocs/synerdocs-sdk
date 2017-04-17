using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Зарегистрированные данные
    /// </summary>
    [DataContract]
    public class RegisteredData
    {
        /// <summary>
        /// Данные об организации
        /// </summary>
        [DataMember]
        public Organization Organization { get; set; }

        /// <summary>
        /// Список сотрудников организации
        /// </summary>
        [DataMember]
        public List<Employee> Employees { get; set; }
    }
}
