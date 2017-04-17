using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Подразделение оргструктуры
    /// </summary>
    [DataContract]
    public class Department : DepartmentShortInfo
    {
        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [DataMember]
        public string OrganizationBoxId { get; set; }

        /// <summary>
        /// Несуществующее подразделение?
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}
