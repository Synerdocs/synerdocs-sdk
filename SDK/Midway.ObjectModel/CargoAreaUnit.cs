using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Грузовое место.
    /// </summary>
    [DataContract]
    public class CargoAreaUnit
    {
        /// <summary>
        /// Вид тары.
        /// </summary>
        [DataMember]
        public NameCodeObject ContainerType { get; set; }

        /// <summary>
        /// Маркировка груза.
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        /// Количество мест.
        /// </summary>
        [DataMember]
        public Quantity NumberOfAreas { get; set; }

        /// <summary>
        /// Масса нетто грузого места.
        /// </summary>
        [DataMember]
        public Quantity NetWeight { get; set; }

        /// <summary>
        /// Масса брутто грузого места.
        /// </summary>
        [DataMember]
        public Quantity GrossWeight { get; set; }

        /// <summary>
        /// Размеры грузого места.
        /// </summary>
        [DataMember]
        public CargoAreaDimensions Dimensions { get; set; }

        /// <summary>
        /// Упаковка груза.
        /// </summary>
        [DataMember]
        public CargoPackage Package { get; set; }

        /// <summary>
        /// Другая необходимая информация о грузовом месте.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
