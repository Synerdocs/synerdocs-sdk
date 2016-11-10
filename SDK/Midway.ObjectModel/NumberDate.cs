using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Номер и дата
    /// </summary>
    [DataContract]
    public class NumberDate
    {
        /// <summary>
        /// Номер
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }
    }
}
