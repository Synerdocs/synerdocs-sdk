using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Пункт погрузки/разгрузки.
    /// </summary>
    [DataContract]
    public class LoadingLocation
    {
        /// <summary>
        /// Информация о контрагенте.
        /// </summary>
        [DataMember]
        public LoadingLocationCounterpartyBase Counterparty { get; set; } 

        /// <summary>
        /// Адрес контрагента.
        /// </summary>
        [DataMember]
        public Address Address { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [DataMember]
        public string Email { get; set; }
    }
}