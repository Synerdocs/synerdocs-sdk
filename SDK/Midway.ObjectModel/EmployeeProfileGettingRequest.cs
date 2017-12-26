using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на получение данных профиля сотрудника.
    /// </summary>
    [DataContract]
    public class EmployeeProfileGettingRequest : ProfileGettingRequest
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string EmployeeId { get; set; }
    }
}