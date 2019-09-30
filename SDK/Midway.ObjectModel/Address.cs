using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Адрес
    /// </summary>
    [DataContract]
    [KnownType(typeof(OrganizationAddress))]
    public class Address
    {
        /// TODO@internal
        /// <summary>
        /// Идентификатор адреса
        /// </summary>
        [DataMember]
        public string AddressId { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        [DataMember]
        public string House { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        [DataMember]
        public string Apartment { get; set; }

        /// <summary>
        /// Код региона
        /// </summary>
        [DataMember]
        public string RegionCode { get; set; }

        /// <summary>
        /// Строение
        /// </summary>
        [DataMember]
        public string Building { get; set; }

        /// <summary>
        /// Населенный пункт
        /// </summary>
        [DataMember]
        public string Locality { get; set; }

        /// <summary>
        /// Район    
        /// </summary>
        [DataMember]
        public string District { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// TODO: не используется
        /// <summary>
        /// Физический абонентский ящик
        /// </summary>
        [DataMember]
        public string PostOfficeBox { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Флаг "иностранный адрес"
        /// </summary>
        [DataMember]
        public bool IsForeign { get; set; }

        /// <summary>
        /// Иностранный адрес (город, улица, дом и т.д.)
        /// </summary>
        [DataMember]
        public string ForeignStreetAddress { get; set; }

        /// <summary>
        /// Уникальный номер адреса объекта в государственном реестре
        /// </summary>
        [DataMember]
        public string StateRegistryCode { get; set; }

        /// <summary>
        /// Тип записи Адреса
        /// </summary>
        [DataMember]
        public EnumValue AddressLocationType { get; set; }
    }
}
