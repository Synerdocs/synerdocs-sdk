using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос на получение всех доступных подразделений сотрудника.
    /// </summary>
    [DataContract]
    public class AvailableDepartmentsResponse : OperationResponse
    {
        /// <summary>
        /// Список доступных подразделений сотрудника.
        /// </summary>
        [DataMember]
        public List<Department> AvailableDepartments { get; set; }
    }
}
