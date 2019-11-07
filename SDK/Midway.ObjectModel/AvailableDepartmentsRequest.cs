using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на получение всех доступных подразделений сотрудника.
    /// </summary>
    [DataContract]
    public class AvailableDepartmentsRequest : OperationRequest
    {
        /// <summary>
        /// ИД пользователя (внешний).
        /// </summary>
        [DataMember]
        public string EmployeeId { get; set; }
    }
}
