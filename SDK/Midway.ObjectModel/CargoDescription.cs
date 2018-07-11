using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание груза.
    /// </summary>
    [DataContract]
    public class CargoDescription
    {
        /// <summary>
        /// Груз.
        /// </summary>
        [DataMember]
        public Cargo Cargo { get; set; }

        /// <summary>
        /// Грузовые места.
        /// </summary>
        [DataMember]
        public CargoArea CargoArea { get; set; }

        /// <summary>
        /// Опасные вещества.
        /// </summary>
        [DataMember]
        public List<string> HazardousSubstances { get; set; }
    }
}
