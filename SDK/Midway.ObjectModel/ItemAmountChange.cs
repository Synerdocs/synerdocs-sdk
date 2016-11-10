using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация по разнице до и после при корректировке
    /// </summary>
    [DataContract]
    public class ItemAmountChange
    {
        /// <summary>
        /// Стоимость без НДС, разница до и после
        /// </summary>
        [DataMember]
        public AmountChange NetAmountChange { get; set; }

        /// <summary>
        /// Сумма налога, разница до и после
        /// </summary>
        [DataMember]
        public AmountChange VatAmountChange { get; set; }

        /// <summary>
        /// Сумма с налогом, разница до и после
        /// </summary>
        [DataMember]
        public AmountChange GrossAmountChange { get; set; }
    }
}
