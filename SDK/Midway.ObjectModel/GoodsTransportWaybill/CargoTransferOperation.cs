using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Информация об операции приема/сдачи груза.
    /// </summary>
    [DataContract]
    public class CargoTransferOperation
    {
        /// <summary>
        /// Оттиск пломбы.
        /// </summary>
        [DataMember]
        public string Seal { get; set; }

        /// <summary>
        /// Количество мест.
        /// </summary>
        [DataMember]
        public string AreaCount { get; set; }

        /// <summary>
        /// Масса брутто.
        /// </summary>
        [DataMember]
        public string GrossWeight { get; set; }

        /// <summary>
        /// Сведения о лице сдавшем груз.
        /// </summary>
        [DataMember]
        public OperationAuthority DeliveredBy { get; set; }

        /// <summary>
        /// Сведения о лице принявшем груз.
        /// </summary>
        [DataMember]
        public OperationAuthority ReceivedBy { get; set; }
    }
}