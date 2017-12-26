using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на изменение персональных данных сотрудника.
    /// </summary>
    [DataContract]
    public class EmployeePersonalInfoUpdatingRequest : PersonalInfoUpdatingRequest
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string EmployeeId { get; set; }
    }
}