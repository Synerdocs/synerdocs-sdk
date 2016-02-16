using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о зашифрованном токене авторизации
    /// </summary>
    [DataContract]
    public class EncryptedTokenInfo
    {
        /// <summary>
        /// Идентификатор токена в БД
        /// </summary>
        [DataMember]
        public string TokenId { get; set; }

        /// <summary>
        /// Зашифрованный токен в base64 кодировке
        /// </summary>
        [DataMember]
        public string EncryptedToken { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [DataMember]
        public string Login { get; set; }
    }
}
