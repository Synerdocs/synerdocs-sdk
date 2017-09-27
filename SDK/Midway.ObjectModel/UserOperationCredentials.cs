using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Учетные данные пользователя для выполнения операции.
    /// </summary>
    [DataContract]
    [KnownType(typeof(EmployeeOperationCredentials))]
    public class UserOperationCredentials : OperationCredentials
    {
        /// <summary>
        /// Токен авторизации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string AuthToken { get; set; }
    }
}
