using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные, необходимые для создания пользователя.
    /// </summary>
    [DataContract]
    public class UserCreationData : PersonalInfo
    {
        /// <summary>
        /// Пароль.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Password { get; set; }
    }
}