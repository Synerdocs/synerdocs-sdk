using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Изменения в сведениях о товаре, подлежащем прослеживаемости.
    /// </summary>
    [DataContract]
    public class ProductTraceabilityInfoChange
    {
        /// <summary>
        /// Регистрационный номер партии товаров.
        /// </summary>
        [DataMember]
        public string BatchNumber { get; set; }

        /// <summary>
        /// Код единицы количественного учета товара, используемая в целях осуществления
        /// прослеживаемости.
        /// </summary>
        [DataMember]
        public string UnitQuantityAccountingCode { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Изменение в количестве прослеживаемого товара.
        /// </summary>
        [DataMember]
        public DecimalChange QuantityChange { get; set; }
    }
}
