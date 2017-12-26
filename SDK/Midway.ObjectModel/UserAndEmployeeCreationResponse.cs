using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при создании пользователя и сотрудника абонента.
    /// </summary>
    [DataContract]
    public class UserAndEmployeeCreationResponse : OperationResponse
    {
        /// <summary>
        /// Информация по сотруднику.
        /// </summary>
        [DataMember]
        public Employee Result { get; set; }
    }
}