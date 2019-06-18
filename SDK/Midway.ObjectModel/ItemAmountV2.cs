using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовая модель товара (продукта, услуги).
    /// </summary>
    [DataContract]
    public class ItemAmountV2
    {
        /// <summary>
        /// Налоговая ставка, соответствует перечислению <see cref="Midway.ObjectModel.VatRate"/>.
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
        public VatAmount VatAmount { get; set; }

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
