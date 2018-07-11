using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание транспортных средств.
    /// </summary>
    [DataContract]
    public class VehiclesDescription
    {
        /// <summary>
        /// Транспортные средства.
        /// </summary>
        [DataMember]
        public List<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Количество транспортных средств.
        /// </summary>
        [DataMember]
        public int? Quantity { get; set; }
    }
}
