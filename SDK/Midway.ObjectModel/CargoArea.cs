using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Грузовые места.
    /// </summary>
    public class CargoArea
    {
        /// <summary>
        /// Грузовые места.
        /// </summary>
        [DataMember]
        public List<CargoAreaUnit> Units { get; set; }

        /// <summary>
        /// Всего мест.
        /// </summary>
        [DataMember]
        public CargoAreaTotal Total { get; set; }
    }
}
