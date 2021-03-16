using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Информация по разнице до и после УКД.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionItemChange
    {
        /// <summary>
        /// Разница в сумме акциза.
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? ExciseDifference { get; set; }

        /// <summary>
        /// Разница в сумме НДС.
        /// </summary>
        [DataMember]
        public decimal VatDifference { get; set; }

        /// <summary>
        /// Изменение стоимости товара без НДС.
        /// </summary>
        [DataMember]
        public DecimalChange ProductCostWithoutVatChange { get; set; }

        /// <summary>
        /// Изменение стоимости товара, учитывая НДС.
        /// </summary>
        [DataMember]
        public DecimalChange ProductCostWithVatChange { get; set; }

        /// <summary>
        /// Изменения в сведениях о товаре, подлежащем прослеживаемости.
        /// </summary>
        [DataMember]
        public List<ProductTraceabilityInfoChange> TraceabilityChanges { get; set; }

        /// <summary>
        /// Изменение количества товара.
        /// </summary>
        [DataMember]
        public DecimalChange QuantityChange { get; set; }
    }
}
