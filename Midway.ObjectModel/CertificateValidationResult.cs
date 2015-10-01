using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Общий результат проверки сертификата
    /// </summary>
    [DataContract]
    public class CertificateValidationResult
    {
        /// <summary>
        /// Результаты проверок по отдельным полям
        /// </summary>
        [DataMember]
        public CertificateFieldValidationResult[] FieldValidationResults { get; set; }

        /// <summary>
        /// Статус проверки сертификата
        /// </summary>
        [DataMember]
        public CertificateValidationStatus CommonStatus { get; set; }
    }
}
