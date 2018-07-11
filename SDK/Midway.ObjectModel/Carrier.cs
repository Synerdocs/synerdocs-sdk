using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о перевозчике и водителях.
    /// </summary>
    [DataContract]
    public class Carrier
    {
        /// <summary>
        /// Реквизиты.
        /// </summary>
        [DataMember]
        public CounterpartyBase Requisites { get; set; }

        /// <summary>
        /// Водители.
        /// </summary>
        [DataMember]
        public List<CarrierDriver> Drivers { get; set; }
    }
}
