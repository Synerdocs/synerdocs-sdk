using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на изменение личного сертификата.
    /// </summary>
    [DataContract]
    [KnownType(typeof(EmployeeCertificateUpdatingRequest))]
    public class CertificateUpdatingRequest : OperationRequest
    {
        /// <summary>
        /// Сертификат.
        /// </summary>
        [DataMember(IsRequired = true)]
        public byte[] CertificateRaw { get; set; }
    }
}