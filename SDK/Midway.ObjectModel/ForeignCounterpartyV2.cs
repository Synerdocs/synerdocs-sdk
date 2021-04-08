using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Иностранный контрагент.
    /// Данная модель добавлена для использования в титуле продавца УКД по приказу ЕД-7-26/736
    /// <see cref="GeneralTransferCorrectionV3.GeneralTransferCorrectionSellerTitleV3"/>.
    /// </summary>
    [DataContract]
    public class ForeignCounterpartyV2 : CounterpartyBase
    {
        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Иные сведения.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Идентификатор юр. лица.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string LegalEntityId { get; set; }
    }
}
