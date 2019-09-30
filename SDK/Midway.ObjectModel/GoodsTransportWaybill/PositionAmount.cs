using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Стоимость позиции.
    /// </summary>
    [DataContract]
    public class PositionAmount
    {
        /// <summary>
        /// Значение. 
        /// </summary>
        [DataMember]
        public decimal? Value { get; set; }

        /// <summary>
        /// НДС. 
        /// </summary>
        [DataMember]
        public decimal? Vat { get; set; }

        /// <summary>
        /// Акциз. 
        /// </summary>
        [DataMember]
        public decimal? Excise { get; set; }
    }
}