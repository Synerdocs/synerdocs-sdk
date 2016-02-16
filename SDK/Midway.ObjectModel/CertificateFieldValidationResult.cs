using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Результат проверки поля сертификата
    /// </summary>
    [DataContract]
    public class CertificateFieldValidationResult
    {
        /// <summary>
        /// Имя поля
        /// </summary>
        [DataMember]
        public string Field { get; set; }

        /// <summary>
        /// Статус проверки
        /// </summary>
        [DataMember]
        public CertificateValidationStatus Status { get; set; }

        /// <summary>
        /// Дополнительная информация по результату проверки
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}
