using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация, необходимая для регистрации пользователя
    /// </summary>
    [DataContract]
    public class UserRegistrationData : UserInfo
    {
        /// <summary>
        /// Пароль
        /// </summary>
        [DataMember]
        public string Password { get; set; }
        
        /// <summary>
        /// Администратор организации
        /// </summary>
        [DataMember]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Сертификат
        /// </summary>
        [DataMember]
        public byte[] Certificate { get; set; }

        /// <summary>
        /// Идентификатор подразделения, сотрудником которого является пользователь.
        /// Null, если является сотрудником для головного подразделения.
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }
    }
}
