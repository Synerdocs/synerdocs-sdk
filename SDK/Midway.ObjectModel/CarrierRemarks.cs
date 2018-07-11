using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Оговорки и замечания перевозчика при приеме/сдачи груза.
    /// </summary>
    [DataContract]
    public class CarrierRemarks
    {
        /// <summary>
        /// Оговорки и замечания перевозчика при приеме груза.
        /// </summary>
        [DataMember]
        public CargoRemarks DuringReception { get; set; }

        /// <summary>
        /// Оговорки и замечания перевозчика при сдачи груза.
        /// </summary>
        [DataMember]
        public CargoRemarks DuringDelivery { get; set; }
    }
}
