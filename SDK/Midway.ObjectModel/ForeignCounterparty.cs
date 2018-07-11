using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Иностранный контрагент.
    /// </summary>
    [DataContract]
    public class ForeignCounterparty : CounterpartyBase
    {
        /// <summary>
        /// Наименование организации
        /// </summary>
        [DataMember(IsRequired = true)]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Иные сведения.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
