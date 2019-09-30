using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Сведения о грузе.
    /// </summary>
    [DataContract]
    public class CargoSection
    {
        /// <summary>
        /// Грузовые позиции транспортного раздела ТТН.
        /// </summary>
        [DataMember]
        public List<CargoItem> Items { get; set; }

        /// <summary>
        /// Количество ездок, заездов.
        /// </summary>
        [DataMember]
        public decimal? TotalRideCount { get; set; }

        /// <summary>
        /// Общая масса брутто.
        /// </summary>
        [DataMember]
        public decimal? TotalGrossWeight { get; set; }
    }
}
