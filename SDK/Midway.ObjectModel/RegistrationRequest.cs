using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные, необходимые для регистрации.
    /// </summary>
    [DataContract]
    public class RegistrationRequest
    {
        /// <summary>
        /// Данные об организации.
        /// </summary>
        [DataMember]
        public OrganizationRegistrationData Organization { get; set; }

        /// <summary>
        /// Данные об оргструктуре.
        /// </summary>
        [DataMember]
        public List<DepartmentRegistrationData> Departments { get; set; }

        /// <summary>
        /// Данные о пользователях.
        /// </summary>
        [DataMember]
        public List<UserRegistrationData> Users { get; set; }

        /// <summary>
        /// Принят регламент ЭДО.
        /// </summary>
        [DataMember]
        [DisplayName("Вы принимаете доступные по адресу www.synerdocs.ru Правила Synerdocs?")]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// Промокоды
        /// </summary>
        [DataMember]
        public List<string> PromoCodes { get; set; }

        /// <summary>
        /// Идентификатор приложения
        /// </summary>
        [DataMember]
        public string ApplicationId { get; set; }
    }
}
