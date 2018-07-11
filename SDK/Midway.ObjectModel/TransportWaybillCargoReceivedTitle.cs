using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул водителя (прием груза) транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCargoReceivedTitle : TransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Прием груза.
        /// </summary>
        [DataMember]
        public DriverCargoOperation CargoReception { get; set; }

        /// <summary>
        /// Оговорки и замечания перевозчика (при приеме груза).
        /// </summary>
        [DataMember]
        public CargoRemarks CargoRemarksDuringReception { get; set; }
    }
}
