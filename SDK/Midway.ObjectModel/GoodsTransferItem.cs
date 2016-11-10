using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание товара
    /// </summary>
    [DataContract]
    public class GoodsTransferItem : ProductBase
    {
        /// <summary>
        /// Характеристика товара
        /// </summary>
        [DataMember]
        public string Characteristic { get; set; }

        /// <summary>
        /// Сорт товара
        /// </summary>
        [DataMember]
        public string Sort { get; set; }

        /// <summary>
        /// Артикул товара
        /// </summary>
        [DataMember]
        public string Article { get; set; }

        /// <summary>
        /// Код товара
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Вид упаковки
        /// </summary>
        [DataMember]
        public string PackingType { get; set; }

        /// <summary>
        /// Количество в одном месте
        /// </summary>
        [DataMember]
        public decimal? QuantityInPackage { get; set; }

        /// <summary>
        /// Количество мест, штук
        /// </summary>
        [DataMember]
        public decimal? NumberOfPackages { get; set; }

        /// <summary>
        /// Масса брутто
        /// </summary>
        [DataMember]
        public decimal? GrossWeight { get; set; }

        /// <summary>
        /// Количество надлежит отпустить
        /// </summary>
        [DataMember]
        public decimal? QuantityToRelease { get; set; }
    }
}
