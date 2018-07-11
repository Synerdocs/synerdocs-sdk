using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Контрагент - юридическое лицо.
    /// </summary>
    [DataContract]
    public class LegalEntityCounterparty : CounterpartyBase
    {
        /// <summary>
        /// Представитель контрагента.
        /// </summary>
        [DataMember]
        public CounterpartyRepresentative Representative { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string OrganizationName { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Inn { get; set; }

        /// <summary>
        /// КПП.
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }
    }
}
