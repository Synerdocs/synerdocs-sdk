using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание и порядок погрузочно-разгрузочных работ.
    /// </summary>
    [DataContract]
    public class CargoHandlingPolicies
    {
        /// <summary>
        /// Дата работ.
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Длительность работ.
        /// </summary>
        [DataMember]
        public Quantity Duration { get; set; }

        /// <summary>
        /// Порядок осуществления работ.
        /// </summary>
        [DataMember]
        public string Routine { get; set; }

        /// <summary>
        /// Иные условия работ.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalPolicies { get; set; }
    }
}
