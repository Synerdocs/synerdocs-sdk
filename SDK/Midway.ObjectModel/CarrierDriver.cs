using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Водитель грузоперевозчика.
    /// </summary>
    [DataContract]
    public class CarrierDriver
    {
        /// <summary>
        /// Реквизиты.
        /// </summary>
        [DataMember]
        public CounterpartyBase Requisites { get; set; }

        /// <summary>
        /// Путевые листы.
        /// </summary>
        [DataMember]
        public List<ShippingDocument> RouteSheets { get; set; }
    }
}
