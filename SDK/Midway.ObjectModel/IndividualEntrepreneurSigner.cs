using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Подписант - индивидуальный предприниматель.
    /// </summary>
    [DataContract]
    public class IndividualEntrepreneurSigner : SignerBase
    {
        /// <summary>
        /// ИНН физического лица.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Inn { get; set; }

        /// <summary>
        /// Свидетельство государственной регистрации ИП.
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }
    }
}
