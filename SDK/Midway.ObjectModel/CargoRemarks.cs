using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Оговорки и замечания по грузу.
    /// </summary>
    [DataContract]
    public class CargoRemarks
    {
        /// <summary>
        /// Фактическое состояние груза.
        /// </summary>
        [DataMember]
        public string CargoState { get; set; }

        /// <summary>
        /// Фактическое состояние тары.
        /// </summary>
        [DataMember]
        public string ContainerState { get; set; }

        /// <summary>
        /// Фактическое состояние упаковки.
        /// </summary>
        [DataMember]
        public string PackageState { get; set; }

        /// <summary>
        /// Фактическое состояние маркировки.
        /// </summary>
        [DataMember]
        public string LabelState { get; set; }

        /// <summary>
        /// Фактическое состояние опломбирования.
        /// </summary>
        [DataMember]
        public string SealState { get; set; }

        /// <summary>
        /// Изменение условий перевозки.
        /// </summary>
        [DataMember]
        public CarriagePoliciesChange CarriagePoliciesChange { get; set; }
    }
}
