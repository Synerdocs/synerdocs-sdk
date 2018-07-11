using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Общая информация о контрагенте.
    /// </summary>
    [DataContract]
    [KnownType(typeof(LegalEntityCounterparty))]
    [KnownType(typeof(IndividualEntrepreneurCounterparty))]
    [KnownType(typeof(IndividualCounterparty))]
    [KnownType(typeof(ForeignCounterparty))]
    public class CounterpartyBase
    {
        /// <summary>
        /// Адрес контрагента.
        /// </summary>
        [DataMember]
        public Address Address { get; set; }

        /// <summary>
        /// Контакты контрагента.
        /// </summary>
        [DataMember]
        public ContragentContactInfo Contact { get; set; }

        /// <summary>
        /// Банковские реквизиты.
        /// </summary>
        [DataMember]
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// ОКПО.
        /// </summary>
        [DataMember]
        public string Okpo { get; set; }

        /// <summary>
        /// Наименование подразделения.
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Информация для участников.
        /// </summary>
        [DataMember]
        public string AdditionalInfoForParticipants { get; set; }
    }
}
