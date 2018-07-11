using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Количество.
    /// </summary>
    [DataContract]
    public class Quantity
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
        /// Единица измерения.
        /// </summary>
        [DataMember]
        public NameCodeObject UnitOfMeasure { get; set; }
    }
}
