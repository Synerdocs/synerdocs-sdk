using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Сведения о дополнительной операции при погрузке/разгрузке.
    /// </summary>
    [DataContract]
    public class AdditionalOperation
    {
        /// <summary>
        /// Наименование операции.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        [DataMember]
        public decimal? Count { get; set; }

        /// <summary>
        /// Длительность операции.
        /// </summary>
        [DataMember]
        public TimeSpan? Duration { get; set; }
    }
}