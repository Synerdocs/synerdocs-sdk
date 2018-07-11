using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Контрагент - индивидуальный предприниматель.
    /// </summary>
    [DataContract]
    public class IndividualEntrepreneurCounterparty : CounterpartyBase
    {
        /// <summary>
        /// ФИО.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Inn { get; set; }

        /// <summary>
        /// Свидетельство государственной регистрации ИП.
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }

        /// <summary>
        /// Иные сведения.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
