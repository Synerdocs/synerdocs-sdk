using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>.
    /// Информаци о пользователе
    /// </summary>
    [DataContract]
    public class UserInfo
    {
        /// <summary>
        /// Логин.
        /// </summary>
        [DataMember]
        public string Login { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Эл. почта.
        /// </summary>
        [DataMember]
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
        /// Логин Skype.
        /// </summary>
        [DataMember]
        public string Skype { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// СНИЛС.
        /// </summary>
        [DataMember]
        public string Snils { get; set; }
    }
}
