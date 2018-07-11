using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сумма.
    /// </summary>
    [DataContract]
    public class Amount
    {
        /// <summary>
        /// Численное значение.
        /// </summary>
        [DataMember]
        public decimal? Number { get; set; }

        /// <summary>
        /// Значение прописью.
        /// </summary>
        [DataMember]
        public string Text { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        [DataMember]
        public CurrencyInfo Currency { get; set; }
    }
}
