using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс, содержащий информацию об общей стоимости товаров / услуг / 
    /// продуктов без налога, сумме налога и стоимости с налогом.
    /// </summary>
    [DataContract]
    public class AmountTotal
    {
        /// <summary>
        /// Общая стоимость товаров без налога.
        /// </summary>
        [DataMember]
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// Общая сумма НДС.
        /// </summary>
        [DataMember]
        public decimal? VatAmount { get; set; }

        /// <summary>
        /// Общая стоимость товаров с налогом.
        /// </summary>
        [DataMember]
        public decimal GrossAmount { get; set; }
    }
}
