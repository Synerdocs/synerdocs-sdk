using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Доверенность.
    /// </summary>
    [DataContract]
    public class Procuration
    {
        /// <summary>
        /// Номер и дата доверенности.
        /// </summary>
        [DataMember]
        public NumberDate NumberDate { get; set; }

        /// <summary>
        /// Лицо, выдавшее доверенность.
        /// </summary>
        [DataMember]
        public string IssuedBy { get; set; }
    }
}