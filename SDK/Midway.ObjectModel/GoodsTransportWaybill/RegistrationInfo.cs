using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Информация о регистрации.
    /// </summary>
    [DataContract]
    public class RegistrationInfo
    {
        /// <summary>
        /// Регистрационный номер.
        /// </summary>
        [DataMember]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Серия.
        /// </summary>
        [DataMember]
        public string Series { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        [DataMember]
        public string Number { get; set; }
    }
}