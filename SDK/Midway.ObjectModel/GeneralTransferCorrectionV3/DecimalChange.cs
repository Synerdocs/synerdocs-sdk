using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Состояние объекта до/после изменений и разницу между ними.
    /// </summary>
    [DataContract]
    public class DecimalChange
    {
        /// <summary>
        /// Численное состояние объекта до изменений.
        /// </summary>
        [DataMember]
        public decimal BeforeChange { get; set; }

        /// <summary>
        /// Численное состояние объекта после изменений.
        /// </summary>
        [DataMember]
        public decimal AfterChange { get; set; }

        /// <summary>
        /// Численная разница между состоянием объекта до изменений и после.
        /// </summary>
        [DataMember]
        public decimal Difference { get; set; }
    }
}
