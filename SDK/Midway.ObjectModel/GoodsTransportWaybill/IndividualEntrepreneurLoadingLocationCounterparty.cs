using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Контрагент места погрузки/разгрузки - индивидуальный предприниматель.
    /// </summary>
    [DataContract]
    public class IndividualEntrepreneurLoadingLocationCounterparty : LoadingLocationCounterpartyBase
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
