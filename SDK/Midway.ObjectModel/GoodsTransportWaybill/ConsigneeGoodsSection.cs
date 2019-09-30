using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Товарный раздел грузополучателя.
    /// </summary>
    [DataContract]
    public class ConsigneeGoodsSection
    {
        /// <summary>
        /// Подписант товарного раздела.
        /// </summary>
        [DataMember]
        public OperationAuthority Signer { get; set; }
    }
}
