using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Дополнительная информация о товаре.
    /// </summary>
    [DataContract]
    public class ProductAdditionalInfo
    {
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
        /// Код товара.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Код вида товара.
        /// </summary>
        [DataMember]
        public string KindCode { get; set; }
    }
}
