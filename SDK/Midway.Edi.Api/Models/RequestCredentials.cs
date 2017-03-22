using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Учетные данные запроса
    /// </summary>
    [DataContract]
    public class RequestCredentials
    {
        /// <summary>
        /// Токен авторизации
        /// </summary>
        [DataMember(IsRequired = true)]
        public string AuthToken { get; set; }

        /// <summary>
        /// Ящик организации
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BoxAddress { get; set; }
    }
}
