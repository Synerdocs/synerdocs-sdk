using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Срок, по истечении которых грузоотправитель и грузополучатель вправе считать груз утраченным.
    /// </summary>
    [DataContract]
    public class CargoLossDeadline
    {
        /// <summary>
        /// Дата, после которой грузоотправитель и грузополучатель вправе считать груз утраченным.
        /// </summary>
        [DataMember]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Иные условия, при наступлении которых грузоотправитель и грузополучатель вправе считать груз утраченным.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalPolicies { get; set; }
    }
}
