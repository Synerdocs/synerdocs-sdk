using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Центр идентификации.
    /// </summary>
    [DataContract]
    public class IdentificationCenter
    {
        /// <summary>
        /// ИД центра идентификации.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Наименование центра идентификации.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Код региона.
        /// </summary>
        [DataMember]
        public string RegionCode { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Долгота.
        /// </summary>
        [DataMember]
        public double? Longitude { get; set; }

        /// <summary>
        /// Широта.
        /// </summary>
        [DataMember]
        public double? Latitude { get; set; }

        /// <summary>
        /// Режим работы.
        /// </summary>
        [DataMember]
        public string Schedule { get; set; }

        /// <summary>
        /// Номера телефонов.
        /// </summary>
        [DataMember]
        public List<string> PhoneNumbers { get; set; }

        /// <summary>
        /// Адреса электронной почты.
        /// </summary>
        [DataMember]
        public List<string> Emails { get; set; }
    }
}
