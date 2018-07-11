using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Итоговая информация по всем грузовым местам.
    /// </summary>
    [DataContract]
    public class CargoAreaTotal
    {
        /// <summary>
        /// Количество всех мест.
        /// </summary>
        [DataMember]
        public Quantity NumberOfAreas { get; set; }

        /// <summary>
        /// Масса нетто всех грузовых мест.
        /// </summary>
        [DataMember]
        public Quantity NetWeight { get; set; }

        /// <summary>
        /// Масса брутто всех грузовых мест.
        /// </summary>
        [DataMember]
        public Quantity GrossWeight { get; set; }

        /// <summary>
        /// Размеры всех грузовых мест.
        /// </summary>
        [DataMember]
        public CargoAreaDimensions Dimensions { get; set; }

        /// <summary>
        /// Другая информация.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
