using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Продукт
    /// </summary>
    [DataContract]
    public class GeneralTransferItem: ProductBase
    {
        /// <summary>
        /// Сведения о признаке
        /// </summary>
        [DataMember]
        public ProductAttribute Attribute { get; set; }

        /// <summary>
        /// Сведения о таможенной декларации
        /// </summary>
        [DataMember]
        public CustomsDeclaration[] CustomsDeclarations { get; set; }

        /// <summary>
        /// Краткое наименование страны происхождения товара
        /// </summary>
        [DataMember]
        public string OriginCountryShortName { get; set; }

        /// <summary>
        /// Код товара
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Количество надлежит отпустить
        /// </summary>
        [DataMember]
        public decimal? QuantityToRelease { get; set; }

        /// <summary>
        /// Сумма акциза
        /// </summary>
        [DataMember]
        public decimal? Excise { get; set; }
    }
}
