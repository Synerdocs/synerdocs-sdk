using System;
using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Погрузочно разгрузочная операция.
    /// </summary>
    [DataContract]
    public class CargoLoadingOperation
    {
        /// <summary>
        /// Механизм.
        /// </summary>
        [DataMember]
        public string Device { get; set; }

        /// <summary>
        /// Грузоподъемность.
        /// </summary>
        [DataMember]
        public string CarryingCapacity { get; set; }

        /// <summary>
        /// Ёмкость ковша.
        /// </summary>
        [DataMember]
        public string BucketCapacity { get; set; }

        /// <summary>
        /// Период операции.
        /// </summary>
        [DataMember]
        public DateTimeRange Duration { get; set; }

        /// <summary>
        /// Исполнитель.
        /// </summary>
        [DataMember]
        public CounterpartyBase Contractor { get; set; }

        /// <summary>
        /// Дополнительная операция.
        /// </summary>
        [DataMember]
        public AdditionalOperation AdditionalOperation { get; set; }

        /// <summary>
        /// Способ погрузки/разгрузки.
        /// </summary>
        [DataMember]
        public NameCodeObject Method { get; set; }

        /// <summary>
        /// Реквизиты ответственного лица.
        /// </summary>
        [DataMember]
        public FullName Authority { get; set; }
    }
}