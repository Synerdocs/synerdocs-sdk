using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Товарная позиция.
    /// </summary>
    [DataContract]
    public class GoodsItem
    {
        /// <summary>
        /// Номер строки в табличной части. 
        /// </summary>
        [DataMember]
        public decimal? RowNumber { get; set; }

        /// <summary>
        /// Номер прейскуранта. 
        /// </summary>
        [DataMember]
        public string PriceListNumber { get; set; }

        /// <summary>
        /// Артикул. 
        /// </summary>
        [DataMember]
        public string Article { get; set; }

        /// <summary>
        /// Количество. 
        /// </summary>
        [DataMember]
        public Quantity Quantity { get; set; }

        /// <summary>
        /// Наименование продукции. 
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Вид упаковки. 
        /// </summary>
        [DataMember]
        public string PackageType { get; set; }

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
        /// Порядковый номер по складской карточке. 
        /// </summary>
        [DataMember]
        public string StockKeepingUnit { get; set; }

        /// <summary>
        /// Код продукции. 
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Номер секции. 
        /// </summary>
        [DataMember]
        public string SectionNumber { get; set; }

        /// <summary>
        /// Объем. 
        /// </summary>
        [DataMember]
        public decimal? Volume { get; set; }

        /// <summary>
        /// Плотность. 
        /// </summary>
        [DataMember]
        public decimal? Density { get; set; }

        /// <summary>
        /// Температура. 
        /// </summary>
        [DataMember]
        public decimal? Temperature { get; set; }

        /// <summary>
        /// Паспорт качества. 
        /// </summary>
        [DataMember]
        public NumberDate QualityCertificate { get; set; }

        /// <summary>
        /// Сумма. 
        /// </summary>
        [DataMember]
        public PositionAmount Amount { get; set; }

        /// <summary>
        /// Цена. 
        /// </summary>
        [DataMember]
        public PositionAmount Price { get; set; }

        /// <summary>
        /// Дополнительная информация. 
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalData { get; set; }
    }
}