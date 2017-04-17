using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные, необходимые для создания неактивного абонента
    /// </summary>
    [DataContract]
    public class NonActiveSubscriberCreationRequest
    {
        /// <summary>
        /// Название организации
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Тип организации
        /// </summary>
        [DataMember]
        public EnumValue OrganizationType { get; set; }

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
        /// Телефон организации
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Контактное лицо
        /// </summary>
        [DataMember]
        public string ContactPerson { get; set; }

        /// <summary>
        /// Список email
        /// </summary>
        [DataMember]
        public List<string> Emails { get; set; }
    }
}
