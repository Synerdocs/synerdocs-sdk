using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул водителя (сдача груза) транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCargoDeliveredTitle : TransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Сдача груза.
        /// </summary>
        [DataMember]
        public DriverCargoOperation CargoDelivery { get; set; }

        /// <summary>
        /// Оговорки и замечания перевозчика (при сдаче груза).
        /// </summary>
        [DataMember]
        public CargoRemarks CargoRemarksDuringDelivery { get; set; }
    }
}