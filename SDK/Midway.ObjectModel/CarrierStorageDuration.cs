using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Продолжительность хранения груза у перевозчика.
    /// </summary>
    [DataContract]
    public class CarrierStorageDuration
    {
        /// <summary>
        /// Диапазон времени, в котором груз может хранится в терминале перевозчика.
        /// </summary>
        [DataMember]
        public DateTimeRange TimeWindow { get; set; }

        /// <summary>
        /// Длительность хранения груза в терминале перевозчика.
        /// </summary>
        [DataMember]
        public Quantity TimeSpan { get; set; }
    }
}
