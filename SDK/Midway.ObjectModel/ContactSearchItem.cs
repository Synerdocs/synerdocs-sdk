using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Элемент списка контактов. Используется в поиске контактов
    /// </summary>
    [DataContract]
    public class ContactSearchItem
    {
        /// <summary>
        /// ИД контрагента
        /// </summary>
        [DataMember]
        public int ContragentId { get; set; }

        /// <summary>
        /// Тип организации контрагента
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// ЮЛ или ИП
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public bool ContragentIsJuridical { get; set; }

        /// <summary>
        /// Наименование организации контрагента
        /// </summary>
        [DataMember]
        public string ContragentName { get; set; }

        /// <summary>
        /// ИНН контрагента
        /// </summary>
        [DataMember]
        public string ContragentInn { get; set; }

        /// <summary>
        /// КПП контрагента
        /// </summary>
        [DataMember]
        public string ContragentKpp { get; set; }

        /// <summary>
        /// Иностранный контрагент
        /// </summary>
        [DataMember]
        public bool ContragentIsForeignCompany { get; set; }

        /// <summary>
        /// Адрес контрагента
        /// </summary>
        [DataMember]
        public Address ContragentAddress { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [DataMember]
        public ContactStatus Status { get; set; }

        /// <summary>
        /// Дата последнего изменения контакта
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Адрес абонентского ящика
        /// </summary>
        [DataMember]
        public string BoxAddress { get; set; }

        /// <summary>
        /// Комментарий последнего изменения контакта
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Уникальный код организации в рамках электронного юридически значимого документооборота
        /// </summary>
        [DataMember]
        public string ContragentServiceCode { get; set; }

        /// <summary>
        /// Контрагент принял Правила работы в сервисе
        /// </summary>
        [DataMember]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// Контрагент принял регламент ЭДО СФ
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
        [DataMember(IsRequired = false)]
        public string OperatorServiceName { get; set; }

        /// <summary>
        /// Статус организации в сервисе
        /// </summary>
        [DataMember]
        public OrganizationStatus OrganizationStatus { get; set; }

        /// <summary>
        /// Статус организации как абонента EDI
        /// </summary>
        [DataMember]
        public EnumValue EdiSubscriberStatus { get; set; }
    }
}
