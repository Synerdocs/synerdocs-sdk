using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул смены водителя и/или ТС транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillDriverOrVehicleChangeTitle : TransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Сведения о подписанте титула.
        /// </summary>
        [DataMember]
        public SignerBase TitleSigner { get; set; }

        /// <summary>
        /// Дата и время изменения водителя и/или транспортного средства.
        /// </summary>
        [DataMember]
        public DateTime? ChangedAt { get; set; }

        /// <summary>
        /// Водители.
        /// </summary>
        [DataMember]
        public List<CarrierDriver> Drivers { get; set; }

        /// <summary>
        /// Транспортное средство.
        /// </summary>
        [DataMember]
        public VehiclesDescription Vehicle { get; set; }
    }
}
