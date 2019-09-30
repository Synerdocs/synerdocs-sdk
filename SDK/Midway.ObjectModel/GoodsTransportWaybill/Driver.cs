using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Водитель.
    /// </summary>
    [DataContract]
    public class Driver
    {
        /// <summary>
        /// Номер водительского удостоверения.
        /// </summary>
        [DataMember]
        public string DrivingLicenseNumber { get; set; }

        /// <summary>
        /// ФИО водителя.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// Лицензионная карточка водителя.
        /// </summary>
        [DataMember]
        public LicenseCard LicenseCard { get; set; }
    }
}