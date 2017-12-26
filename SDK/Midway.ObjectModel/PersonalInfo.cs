using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Пользовательская информация.
    /// </summary>
    [DataContract]
    public class PersonalInfo
    {
        /// <summary>
        /// Фамилия.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Email { get; set; }

        /// <summary>
        /// Часовой пояс.
        /// </summary>
        [DataMember]
        public string TimeZone { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [DataMember]
        public string Comment { get; set; }
    }
}