using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Контрагент.
    /// </summary>
    [DataContract]
    public class Contragent : ContragentBase
    {
        public Contragent()
        {
            OrganizationType = new EnumValue
            {
                Code = 1,
                Name = "LegalEntity",
                Description = "Юридическое лицо"
            };
        }

        /// <summary>
        /// Тип организации.
        /// </summary>
        [DataMember]
        public EnumValue OrganizationType { get; set; }

        /// <summary>
        /// ОКПО.
        /// </summary>
        [DataMember]
        public string Okpo { get; set; }

        /// <summary>
        /// Информация для участников.
        /// </summary>
        [DataMember]
        public string AdditionalInfoForParticipants { get; set; }

        /// <summary>
        /// ФИО.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// Страна (для иностранных организаций).
        /// </summary>
        [DataMember]
        public string CountryName { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        [DataMember]
        public Address Address { get; set; }

        /// <summary>
        /// Контакты контрагента.
        /// </summary>
        [DataMember]
        public ContragentContactInfo ContactInfo { get; set; }

        /// <summary>
        /// ОКДП.
        /// </summary>
        [DataMember]
        public string Okdp { get; set; }

        /// <summary>
        /// ОКОПФ.
        /// </summary>
        [DataMember]
        public string Okopf { get; set; }

        /// <summary>
        /// Свидетельство государственной регистрации ИП.
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }

        /// <summary>
        /// Подразделение.
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Код оператора ЭДО.
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }

        /// <summary>
        /// Флаг "иностранный контрагент".
        /// </summary>
        [DataMember]
        public bool IsForeign { get; set; }
    }
}
