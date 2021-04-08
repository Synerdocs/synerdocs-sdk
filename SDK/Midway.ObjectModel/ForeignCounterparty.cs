using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Иностранный контрагент.
    /// Для работы с титулом продавца УКД по приказу ЕД-7-26/736 рекомендуется использовать
    /// <see cref="ForeignCounterpartyV2"/>.
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
