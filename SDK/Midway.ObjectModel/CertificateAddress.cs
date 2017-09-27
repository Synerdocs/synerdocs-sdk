using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Адрес в сертификате.
    /// </summary>
    [DataContract]
    public class CertificateAddress
    {
        /// <summary>
        /// Индекс.
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// Код региона.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string RegionCode { get; set; }

        /// <summary>
        /// Район.
        /// </summary>
        [DataMember]
        public string District { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Населенный пункт.
        /// </summary>
        [DataMember]
        public string Locality { get; set; }

        /// <summary>
        /// Улица.
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// Дом.
        /// </summary>
        [DataMember]
        public string House { get; set; }

        /// <summary>
        /// Строение / корпус.
        /// </summary>
        [DataMember]
        public string Building { get; set; }

        /// <summary>
        /// Квартира.
        /// </summary>
        [DataMember]
        public string Apartment { get; set; }
    }
}
