using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Фактическое состояние груза, тары, упаковки, маркировки и опломбирования.
    /// </summary>
    [DataContract]
    public class CargoState
    {
        /// <summary>
        /// Фактическое состояние груза.
        /// </summary>
        [DataMember]
        public Cargo Cargo { get; set; }

        /// <summary>
        /// Грузовые места.
        /// </summary>
        [DataMember]
        public CargoArea CargoArea { get; set; }
    }
}
