using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Титул водителя (прием груза) товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillCargoReceivedTitle : GoodsTransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Описание фактов при приёмке груза.
        /// </summary>
        [DataMember]
        public string ReceiptionFacts { get; set; }

        /// <summary>
        /// Сведения о лице принявшем груз.
        /// </summary>
        [DataMember]
        public OperationAuthority ReceivedBy { get; set; }
    }
}
