using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул грузополучателя транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillConsigneeTitle : TransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Сдача груза.
        /// </summary>
        [DataMember]
        public CargoOperation CargoDelivery { get; set; }

        /// <summary>
        /// Оговорки и замечания перевозчика (при приеме и сдаче груза).
        /// </summary>
        [DataMember]
        public CarrierRemarks CarrierRemarks { get; set; }
    }
}