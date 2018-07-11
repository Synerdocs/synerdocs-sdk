using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Размеры.
    /// </summary>
    [DataContract]
    public class Dimensions
    {
        /// <summary>
        /// Длина.
        /// </summary>
        [DataMember]
        public Quantity Length { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        [DataMember]
        public Quantity Width { get; set; }

        /// <summary>
        /// Высота.
        /// </summary>
        [DataMember]
        public Quantity Height { get; set; }

        /// <summary>
        /// Объем.
        /// </summary>
        [DataMember]
        public Quantity Volume { get; set; }
    }
}
