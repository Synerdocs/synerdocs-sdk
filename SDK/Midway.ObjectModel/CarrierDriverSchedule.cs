using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Режим водителя грузоперевозчика.
    /// </summary>
    [DataContract]
    public class CarrierDriverSchedule
    {
        /// <summary>
        /// Описание режима водителя в пути следования.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        /// <summary>
        /// Труд и отдых водителя.
        /// </summary>
        [DataMember]
        public string Activity { get; set; }
    }
}
