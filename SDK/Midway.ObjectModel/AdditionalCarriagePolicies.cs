using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Прочие условия перевозки.
    /// </summary>
    [DataContract]
    public class AdditionalCarriagePolicies
    {
        /// <summary>
        /// Специальное разрешение.
        /// </summary>
        [DataMember]
        public ShippingDocument SpecialPermission { get; set; }

        /// <summary>
        /// Установленные маршруты перевозки опасного, тяжеловесного или крупногабаритного груза.
        /// </summary>
        [DataMember]
        public List<string> Routes { get; set; }

        /// <summary>
        /// Режимы водителя.
        /// </summary>
        [DataMember]
        public List<CarrierDriverSchedule> DriverSchedules { get; set; }

        /// <summary>
        /// Сведения о коммерческих и иных актах.
        /// </summary>
        [DataMember]
        public List<ShippingDocument> Acts { get; set; }
    }
}
