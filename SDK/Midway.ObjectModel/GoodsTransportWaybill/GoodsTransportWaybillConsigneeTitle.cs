using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Титул грузополучателя товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillConsigneeTitle : GoodsTransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Товарный раздел.
        /// </summary>
        [DataMember]
        public ConsigneeGoodsSection GoodsSection { get; set; }

        /// <summary>
        /// Транспортный раздел.
        /// </summary>
        [DataMember]
        public ConsigneeTransportSection TransportSection { get; set; }
    }
}
