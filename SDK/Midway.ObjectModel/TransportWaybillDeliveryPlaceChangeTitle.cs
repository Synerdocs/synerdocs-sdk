using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул изменения места доставки транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillDeliveryPlaceChangeTitle : TransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Переадресовка (изменение места доставки).
        /// </summary>
        [DataMember]
        public PlaceChange DeliveryPlaceChange { get; set; }
    }
}
