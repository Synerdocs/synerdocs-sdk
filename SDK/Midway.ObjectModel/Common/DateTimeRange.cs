using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Диапазон дат и времени.
    /// </summary>
    [DataContract]
    public class DateTimeRange
    {
        /// <summary>
        /// Дата и время начала.
        /// </summary>
        [DataMember]
        public DateTime? From { get; set; }

        /// <summary>
        /// Дата и время завершения.
        /// </summary>
        [DataMember]
        public DateTime? To { get; set; }
    }
}
