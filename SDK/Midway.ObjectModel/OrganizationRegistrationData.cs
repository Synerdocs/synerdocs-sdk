using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные, необходимые для регистрации организации
    /// </summary>
    [DataContract]
    public class OrganizationRegistrationData
    {
        /// <summary>
        /// Тип организации
        /// </summary>
        [DataMember]
        public EnumValue OrganizationType { get; set; }

        /// <summary>
        /// Краткое наименование организации
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Юридическое наименование организации
        /// </summary>
        [DataMember]
        public string LegalName { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// ОГРН
        /// </summary>
        [DataMember]
        public string Ogrn { get; set; }

        /// <summary>
        /// Код налогового органа
        /// </summary>
        [DataMember]
        public string Ifns { get; set; }

        /// <summary>
        /// Свидетельство государственной регистрации ИП
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }
        
        /// <summary>
        /// Фамилия (для ИП)
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Имя (для ИП)
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество (для ИП)
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Факс
        /// </summary>
        [DataMember]
        public string Fax { get; set; }

        /// <summary>
        /// Банковские реквизиты
        /// </summary>
        [DataMember]
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// Тип авторизации контактов
        /// </summary>
        [DataMember]
        public EnumValue ContactAuthType { get; set; }

        /// <summary>
        /// Признак иностранной компании
        /// </summary>
        [DataMember]
        public bool IsForeignCompany { get; set; }

        /// <summary>
        /// Список адресов организации
        /// </summary>
        [DataMember]
        public OrganizationAddress[] Addresses { get; set; }

        /// <summary>
        /// Контактное лицо
        /// </summary>
        [DataMember]
        public string ContactPerson { get; set; }
    }
}
