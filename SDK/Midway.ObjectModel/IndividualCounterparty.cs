using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Контрагент - физическое лицо.
    /// </summary>
    [DataContract]
    public class IndividualCounterparty : CounterpartyBase
    {
        /// <summary>
        /// ФИО.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// Иные сведения.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
