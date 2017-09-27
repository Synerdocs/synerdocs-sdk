using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Учетные данные сотрудника для выполнения операции.
    /// </summary>
    [DataContract]
    public class EmployeeOperationCredentials : UserOperationCredentials
    {
        /// <summary>
        /// Ящик организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BoxAddress { get; set; }
    }
}
