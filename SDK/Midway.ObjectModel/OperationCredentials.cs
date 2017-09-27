using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Учетные данные для выполнения операции.
    /// </summary>
    [DataContract]
    [KnownType(typeof(UserOperationCredentials))]
    [KnownType(typeof(EmployeeOperationCredentials))]
    public class OperationCredentials
    {
    }
}
