using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на изменение личных персональных данных.
    /// </summary>
    [DataContract]
    [KnownType(typeof(EmployeePersonalInfoUpdatingRequest))]
    public class PersonalInfoUpdatingRequest : OperationRequest
    {
        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Position { get; set; }

        /// <summary>
        /// Пользовательская информация.
        /// </summary>
        [DataMember(IsRequired = true)]
        public PersonalInfo User { get; set; }
    }
}