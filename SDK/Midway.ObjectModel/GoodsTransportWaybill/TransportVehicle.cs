using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Транспортное средство.
    /// </summary>
    [DataContract]
    public class TransportVehicle
    {
        /// <summary>
        /// Марка транспортного средства.
        /// </summary>
        [DataMember]
        public string Brand { get; set; }

        /// <summary>
        /// Регистрационный номер транспортного средства.
        /// </summary>
        [DataMember]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Гаражный номер.
        /// </summary>
        [DataMember]
        public string GarageNumber { get; set; }
    }
}
