using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Адрес организации
    /// </summary>
    [DataContract]
    public class OrganizationAddress : Address
    {
        /// <summary>
        /// Тип адреса
        /// </summary>
        [DataMember]
        public AddressType AddressType { get; set; }
    }
}
