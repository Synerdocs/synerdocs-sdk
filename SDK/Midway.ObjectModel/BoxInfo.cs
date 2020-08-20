using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация об абонентском ящике. Используется для получения списка ящиков для пользователя.
    /// </summary>
    [DataContract]
    public class BoxInfo
    {
        /// <summary>
        /// Абонентский ящик организации.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// TODO: устарело
        /// <summary>
        /// </summary>
        [DataMember]
        [Obsolete("Устарело, используйте поле Address для указания абонентского ящика.")]
        public string Name { get; set; }

        /// <summary>
        /// Внутренний идентификатор организации.
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Идентификатор абонента.
        /// </summary>
        [DataMember]
        public Guid SubscriberId { get; set; }

        /// <summary>
        /// Тип организации.
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// Название организации.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// ИНН организации.
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// КПП организации.
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// Флаг принятия регламента ЭДО.
        /// </summary>
        [DataMember]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// Флаг принятия регламента ЭДО счетов-фактур.
        /// </summary>
        [DataMember]
        public bool InvoiceReglamentAccepted { get; set; }

        /// <summary>
        /// Флаг принятия пользователем регламента ЭДО счетами-фактурами.
        /// </summary>
        [DataMember]
        public bool InvoiceUserReglamentAccepted { get; set; }
    }
}
