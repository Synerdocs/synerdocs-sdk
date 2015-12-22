using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные об организации для отображения в виде списка
    /// </summary>
    [DataContract]
    public class OrganizationListEntry
    {
        /// <summary>
        /// Идентификатор орагнизации
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Наименование орагнизации
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Юридическое наименование организации
        /// </summary>
        [DataMember]
        public string LegalName { get; set; }

        /// <summary>
        /// Форма собственности
        /// </summary>
        [DataMember]
        public string LegalForm { get; set; }

        /// <summary>
        /// Признак иностранной организации
        /// </summary>
        [DataMember]
        public bool IsForeignCompany { get; set; }

        /// <summary>
        /// Юридический адрес иностранной организации
        /// </summary>
        [DataMember]
        public string LegalAddressForeign { get; set; }

        /// <summary>
        /// Почтовый адрес иностранной организации
        /// </summary>
        [DataMember]
        public string MailingAddressForeign { get; set; }

        #region Юридический адрес

        /// <summary>
        /// Юридический адрес: город
        /// </summary>
        [DataMember]
        public string LegalAddressCity { get; set; }

        /// <summary>
        /// Юридический адрес: дом
        /// </summary>
        [DataMember]
        public int? LegalAddressHouse { get; set; }

        /// <summary>
        /// Юридический адрес: квартира, офис
        /// </summary>
        [DataMember]
        public int? LegalAddressApartment { get; set; }

        /// <summary>
        /// Юридический адрес: строение
        /// </summary>
        [DataMember]
        public string LegalAddressBuilding { get; set; }

        /// <summary>
        /// Юридический адрес: населенный пункт
        /// </summary>
        [DataMember]
        public string LegalAddressLocality { get; set; }

        /// <summary>
        /// Юридический адрес: район
        /// </summary>
        [DataMember]
        public string LegalAddressDistrict { get; set; }

        /// <summary>
        /// Юридический адрес: улица
        /// </summary>
        [DataMember]
        public string LegalAddressStreet { get; set; }

        #endregion Юридический адрес

        #region Почтовый адрес

        /// <summary>
        /// Почтовый адрес: город
        /// </summary>
        [DataMember]
        public string MailingAddressCity { get; set; }

        /// <summary>
        /// Почтовый адрес: дом
        /// </summary>
        [DataMember]
        public int? MailingAddressHouse { get; set; }

        /// <summary>
        /// Почтовый адрес: квартира
        /// </summary>
        [DataMember]
        public int? MailingAddressApartment { get; set; }

        /// <summary>
        /// Почтовый адрес: строение
        /// </summary>
        [DataMember]
        public string MailingAddressBuilding { get; set; }

        /// <summary>
        /// Почтовый адрес: населенный пункт
        /// </summary>
        [DataMember]
        public string MailingAddressLocality { get; set; }

        /// <summary>
        /// Почтовый адрес: район
        /// </summary>
        [DataMember]
        public string MailingAddressDistrict { get; set; }

        /// <summary>
        /// Почтовый адрес: улица
        /// </summary>
        [DataMember]
        public string MailingAddressStreet { get; set; }

        #endregion Почтовый адрес
    }
}
