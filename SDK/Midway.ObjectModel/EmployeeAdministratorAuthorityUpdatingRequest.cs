using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на изменение прав администратора сотрудника.
    /// </summary>
    [DataContract]
    public class EmployeeAdministratorAuthorityUpdatingRequest : OperationRequest
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string EmployeeId { get; set; }

        /// <summary>
        /// Признак: сотрудник абонента является администратором.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsAdmin { get; set; }
    }
}