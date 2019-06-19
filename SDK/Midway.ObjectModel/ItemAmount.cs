using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовая модель товара (продукта, услуги).
    /// </summary>
    [DataContract]
    public class ItemAmount
    {
        /// <summary>
        /// Налоговая ставка.
        /// </summary>
        [DataMember]
        public EnumValue VatRate { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        [DataMember]
        public decimal? Price { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        [DataMember]
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Стоимость без налога.
        /// </summary>
        [DataMember]
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// Сумма налога.
        /// </summary>
        [DataMember]
        public decimal? VatAmount { get; set; }

        /// <summary>
        /// Сумма с налогом.
        /// </summary>
        [DataMember]
        public decimal? GrossAmount { get; set; }

        ///<summary>
        /// Единица измерения.
        /// </summary>
        [DataMember]
        public NameCodeObject UnitOfMeasure { get; set; }
    }
}
