using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Всего по товарным позициям.
    /// </summary>
    [DataContract]
    public class GoodsItemsTotal
    {
        /// <summary>
        /// Наценка.  
        /// </summary>
        [DataMember]
        public decimal? ExtraCharge { get; set; }

        /// <summary>
        /// Наименование груза.  
        /// </summary>
        [DataMember]
        public string CargoName { get; set; }

        /// <summary>
        /// Объем.  
        /// </summary>
        [DataMember]
        public decimal? Volume { get; set; }

        /// <summary>
        /// Количество мест.  
        /// </summary>
        [DataMember]
        public decimal? AreaCount { get; set; }

        /// <summary>
        /// Масса.  
        /// </summary>
        [DataMember]
        public decimal? Weight { get; set; }

        /// <summary>
        /// Складские или транспортные расходы.  
        /// </summary>
        [DataMember]
        public decimal? InventoryOrTransportationCosts { get; set; }

        /// <summary>
        /// Всего к оплате.  
        /// </summary>
        [DataMember]
        public PositionAmount TotalAmount { get; set; }

        /// <summary>
        /// Дополнительная информация. 
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalData { get; set; }
    }
}