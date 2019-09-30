using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Титул водителя (сдача груза) товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillCargoDeliveredTitle : GoodsTransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Описание фактов при сдаче груза.
        /// </summary>
        [DataMember]
        public string DeliveryFacts { get; set; }

        /// <summary>
        /// Сведения о лице сдавшем груз.
        /// </summary>
        [DataMember]
        public OperationAuthority DeliveredBy { get; set; }
    }
}