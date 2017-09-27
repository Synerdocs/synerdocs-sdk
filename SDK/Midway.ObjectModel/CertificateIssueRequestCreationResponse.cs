using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос на создание заявки на издание сертификата.
    /// </summary>
    [DataContract]
    public class CertificateIssueRequestCreationResponse
    {
        /// <summary>
        /// Заявка на издание сертификата.
        /// </summary>
        [DataMember]
        public CertificateIssueRequest Result { get; set; }

        /// <summary>
        /// Результат валидации запроса на создание заявки на издание сертификата.
        /// </summary>
        [DataMember]
        public ModelValidationResult ValidationResult { get; set; } 
    }
}
