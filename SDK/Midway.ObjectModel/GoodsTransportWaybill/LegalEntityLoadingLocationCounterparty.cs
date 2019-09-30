using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Контрагент места погрузки/разгрузки - юридическое лицо.
    /// </summary>
    [DataContract]
    public class LegalEntityLoadingLocationCounterparty : LoadingLocationCounterpartyBase
    {
        /// <summary>
        /// Представитель контрагента.
        /// </summary>
        [DataMember]
        public CounterpartyRepresentative Representative { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// КПП.
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }
    }
}
