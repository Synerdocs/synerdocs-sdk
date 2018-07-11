using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Рекомендации о перевозке.
    /// </summary>
    [DataContract]
    public class CarriageInstructions
    {
        /// <summary>
        /// Рекомендации о температурном режиме.
        /// </summary>
        [DataMember]
        public TemperatureCondition TemperatureCondition { get; set; }

        /// <summary>
        /// Предельный срок перевозки.
        /// </summary>
        [DataMember]
        public string CarriageDeadline { get; set; }

        /// <summary>
        /// Иные рекомендации о перевозке.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInstructions { get; set; }
    }
}
