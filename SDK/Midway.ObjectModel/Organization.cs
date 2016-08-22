using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Полная информация об организации
    /// </summary>
    [DataContract]
    public class Organization
    {
        /// <summary>
        /// 
        /// </summary>
        public Organization()
        {
            ContactAuthType = ContactAuthType.Accept;
            OrganizationStatus = OrganizationStatus.NonActive;
        }

        /// <summary>
        /// ИД организации
        /// </summary>
        [DataMember]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Тип организации
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }
        
        /// <summary>
        /// Название организации
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Телефон организации
        /// </summary>
        [DataMember]
        public string Tel { get; set; }

        /// <summary>
        /// Факс организации
        /// </summary>
        [DataMember]
        public string Fax { get; set; }

        /// TODO@устарело
        /// <summary>
        /// </summary>
        [DataMember]
        public bool? State { get; set; }

        /// <summary>
        /// Юридическое название организации
        /// </summary>
        [DataMember]
        public string LegalName { get; set; }

        /// <summary>
        /// Организационно-правовая форма (ООО, ЗАО, и т.д.)
        /// </summary>
        [DataMember]
        public string LegalForm { get; set; }

        /// <summary>
        /// Признак иностранной компании
        /// </summary>
        [DataMember]
        public bool IsForeignCompany { get; set; }

        /// <summary>
        /// ИНН организации
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// КПП организации
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// Наименование банка организации
        /// </summary>
        [DataMember]
        public string Bank { get; set; }

        /// <summary>
        /// Банковский идентификационный код организации
        /// </summary>
        [DataMember]
        public string Bik { get; set; }

        /// <summary>
        /// Корреспондентский счет организации
        /// </summary>
        [DataMember]
        public string CorrespondentAccount { get; set; }

        /// <summary>
        /// Расчетный счет организации
        /// </summary>
        [DataMember]
        public string CurrentAccount { get; set; }

        /// <summary>
        /// Список адресов организации
        /// </summary>
        [DataMember]
        public OrganizationAddress[] Addresses { get; set; }

        /// <summary>
        /// Юридический адрес организации
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public Address LegalAddress { get; set; }

        /// <summary>
        /// Почтовый адрес организации
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public Address MailingAddress { get; set; }

        /// <summary>
        /// ЮЛ или ИП
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public bool IsJuridical { get; set; }

        /// <summary>
        /// Имя (для ИП)
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия (для ИП)
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество (для ИП)
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Код организации в рамках системы ЭДО, используется при выставлении ЭСФ
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }

        /// <summary>
        /// Адрес абонентского ящика организации
        /// </summary>
        [DataMember]
        public string BoxAddress { get; set; }

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

        /// TODO@internal
        /// <summary>
        /// Версия последнего изменения
        /// </summary>
        [DataMember]
        public Int64 Version { get; set; }

        /// <summary>
        /// Принят регламент ЭДО
        /// </summary>
        [DataMember]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// Принят регламент ЭДО счетами-фактурами
        /// </summary>
        [DataMember]
        public bool InvoiceReglamentAccepted { get; set; }

        /// <summary>
        /// Код оператора ЭДО
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }

        /// <summary>
        /// Наименование сервиса оператора ЭДО
        /// </summary>
        [DataMember]
        public string OperatorServiceName { get; set; }
        
        /// <summary>
        /// Статус организации в сервисе
        /// </summary>
        [DataMember]
        public OrganizationStatus OrganizationStatus { get; set; }

        /// <summary>
        /// Тип авторизации контактов
        /// </summary>
        [DataMember]
        public ContactAuthType ContactAuthType { get; set; }

        /// <summary>
        /// Признак "Подключена услуга "Подтверждение получения документа"
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public bool FeatureConfirmReceiptEnabled { get; set; }

        /// <summary>
        /// Признак "Включен обмен с ФЛ"
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public bool ExchangeWithIndividualEnabled { get; set; }

        /// <summary>
        /// Идентификатор получателя пакетов в роуминге
        /// </summary>
        [DataMember]
        public int? RoamingPackageRecipientId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}