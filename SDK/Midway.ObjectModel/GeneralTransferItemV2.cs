using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Продукт.
    /// Формат УПД, утвержденный ММВ-7-15/820.
    /// </summary>
    [DataContract]
    public class GeneralTransferItemV2 : ProductBaseV2
    {
        /// <summary>
        /// Сведения о признаке.
        /// </summary>
        [DataMember]
        public ProductAttribute Attribute { get; set; }

        /// <summary>
        /// Сведения о таможенной декларации.
        /// </summary>
        [DataMember]
        public List<CustomsDeclaration> CustomsDeclarations { get; set; }

        /// <summary>
        /// Краткое наименование страны происхождения товара.
        /// </summary>
        [DataMember]
        public string OriginCountryShortName { get; set; }

        /// <summary>
        /// Код товара.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Количество надлежит отпустить.
        /// </summary>
        [DataMember]
        public decimal? QuantityToRelease { get; set; }

        /// <summary>
        /// Сумма акциза.
        /// </summary>
        [DataMember]
        public decimal? Excise { get; set; }

        /// <summary>
        /// Характеристика товара.
        /// </summary>
        [DataMember]
        public string Characteristic { get; set; }

        /// <summary>
        /// Сорт товара.
        /// </summary>
        [DataMember]
        public string Sort { get; set; }

        /// <summary>
        /// Артикул товара.
        /// </summary>
        [DataMember]
        public string Article { get; set; }

        /// <summary>
        /// Код каталога.
        /// </summary>
        [DataMember]
        public string CatalogCode { get; set; }

        /// <summary>
        /// Код вида товара. Принимает значение согласно Товарной номенклатуре внешнеэкономической деятельности (ТН ВЭД).
        /// </summary>
        [DataMember]
        public string GoodsTypeCode { get; set; }

        /// <summary>
        /// Сведения о товарах, подлежащих прослеживаемости.
        /// </summary>
        [DataMember]
        public List<ProductTraceabilityInfo> ProductTraceabilityInfo { get; set; }

        /// <summary>
        /// Номера средств идентификации товаров.
        /// </summary>
        [DataMember]
        public List<ProductIdentificationInfo> ProductIdentificationInfo { get; set; }
    }
}
