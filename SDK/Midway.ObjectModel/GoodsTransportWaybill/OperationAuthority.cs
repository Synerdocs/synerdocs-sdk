using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Уполномоченное лицо для выполнения операции.
    /// </summary>
    [DataContract]
    public class OperationAuthority
    {
        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// Доверенность.
        /// </summary>
        [DataMember]
        public Procuration Procuration { get; set; }
    }
}