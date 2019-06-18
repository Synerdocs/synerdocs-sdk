using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о товаре, подлежащем прослеживаемости.
    /// </summary>
    [DataContract]
    public class ProductTraceabilityInfo
    {
        /// <summary>
        /// Регистрационный номер партии товаров.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BatchNumber { get; set; }

        /// <summary>
        /// Количество товара.
        /// </summary>
        [DataMember(IsRequired = true)]
        public Quantity Quantity { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string AdditionalInfo { get; set; }
    }
}
