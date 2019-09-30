using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Титул грузоотправителя товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillConsignorTitle : GoodsTransportWaybillTitleBase
    {
        /// <summary>
        /// Серия документа.
        /// </summary>
        [DataMember]
        public string DocumentFamily { get; set; }

        /// <summary>
        /// Номер и дата составления товарно-транспортной накладной.
        /// </summary>
        [DataMember]
        public NumberDate WaybillNumberDate { get; set; }

        /// <summary>
        /// Номер и дата заказа.
        /// </summary>
        [DataMember]
        public NumberDate OrderNumberDate { get; set; }

        /// <summary>
        /// Грузоотправитель.
        /// </summary>
        [DataMember]
        public CounterpartyBase Consignor { get; set; }

        /// <summary>
        /// Грузополучатель.
        /// </summary>
        [DataMember]
        public CounterpartyBase Consignee { get; set; }

        /// <summary>
        /// Плательщик.
        /// </summary>
        [DataMember]
        public CounterpartyBase Payer { get; set; }

        /// <summary>
        /// Заказчик.
        /// </summary>
        [DataMember]
        public CounterpartyBase Customer { get; set; }

        /// <summary>
        /// Товарный раздел.
        /// </summary>
        [DataMember]
        public ConsignorGoodsSection GoodsSection { get; set; }

        /// <summary>
        /// Транспортный раздел.
        /// </summary>
        [DataMember]
        public ConsignorTransportSection TransportSection { get; set; }
    }
}
