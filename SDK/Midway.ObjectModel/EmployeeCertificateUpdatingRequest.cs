using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на изменение сертификата сотрудника.
    /// </summary>
    [DataContract]
    public class EmployeeCertificateUpdatingRequest : CertificateUpdatingRequest
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string EmployeeId { get; set; }
    }
}