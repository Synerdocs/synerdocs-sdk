using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Температурный режим.
    /// </summary>
    [DataContract]
    public class TemperatureCondition
    {
        /// <summary>
        /// Температура, град. Цельсия.
        /// </summary>
        [DataMember]
        public decimal? Temperature { get; set; }

        /// <summary>
        /// Температура не ниже, град. Цельсия.
        /// </summary>
        [DataMember]
        public decimal? MinimumTemperature { get; set; }

        /// <summary>
        /// Температура не выше, град. Цельсия.
        /// </summary>
        [DataMember]
        public decimal? MaximumTemperature { get; set; }

        /// <summary>
        /// Иные сведения о температурном режиме.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
