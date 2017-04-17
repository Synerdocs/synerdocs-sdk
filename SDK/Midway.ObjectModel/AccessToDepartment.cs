using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Доступ к подразделению
    /// </summary>
    [DataContract]
    public class AccessToDepartment
    {
        /// <summary>
        /// Подразделение
        /// </summary>
        [DataMember]
        public Department Department { get; set; }

        /// <summary>
        /// Доступ к дочерним элементам
        /// </summary>
        [DataMember]
        public bool SubElementsAccess { get; set; }

        /// <summary>
        /// Флаг о том что пользователь является сотрудником данного подразделения
        /// </summary>
        [DataMember]
        public bool IsEmployee { get; set; }

        /// <summary>
        /// Флаг о том, что привязка удалена
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}
