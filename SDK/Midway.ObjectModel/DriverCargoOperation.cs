using System;
using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Операция с грузом (прием или сдача).
    /// </summary>
    [DataContract]
    public class DriverCargoOperation
    {
        /// <summary>
        /// Период между прибытием и убытием.
        /// </summary>
        [DataMember]
        public DateTimeRange Duration { get; set; }

        /// <summary>
        /// Фактическое состояние груза, тары, упаковки, маркировки и опломбирования.
        /// </summary>
        [DataMember]
        public CargoState CargoState { get; set; }

        /// <summary>
        /// Фактическое место приема груза.
        /// </summary>
        [DataMember]
        public Address Address { get; set; }

        /// <summary>
        /// Должность, подпись, расшифровка подписи водителя.
        /// </summary>
        [DataMember]
        public SignerBase DriverSignatureBy { get; set; }
    }
}
