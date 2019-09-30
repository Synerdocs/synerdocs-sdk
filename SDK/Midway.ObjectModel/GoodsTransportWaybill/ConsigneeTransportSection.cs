using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Транспортный раздел грузополучателя.
    /// </summary>
    [DataContract]
    public class ConsigneeTransportSection
    {
        /// <summary>
        /// Сдача груза.
        /// </summary>
        [DataMember]
        public CargoTransferOperation CargoDelivery { get; set; }

        /// <summary>
        /// Составленные акты.
        /// </summary>
        [DataMember]
        public List<ShippingDocument> Acts { get; set; }

        /// <summary>
        /// Разгрузка.
        /// </summary>
        [DataMember]
        public CargoLoadingOperation UnloadingOperation { get; set; }
    }
}
