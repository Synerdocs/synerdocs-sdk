using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Транспортное средство.
    /// </summary>
    [DataContract]
    public class Vehicle
    {
        /// <summary>
        /// Тип транспортного средства.
        /// </summary>
        [DataMember]
        public NameCodeObject Type { get; set; }

        /// <summary>
        /// Марка транспортного средства.
        /// </summary>
        [DataMember]
        public string Brand { get; set; }

        /// <summary>
        /// Регистрационный номер транспортного средства.
        /// </summary>
        [DataMember]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Грузоподъемность транспортного средства.
        /// </summary>
        [DataMember]
        public Quantity CarryingCapacity { get; set; }

        /// <summary>
        /// Вместимость транспортного средства.
        /// </summary>
        [DataMember]
        public Quantity Capacity { get; set; }

        /// <summary>
        /// Иные сведения о транспортного средстве.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
