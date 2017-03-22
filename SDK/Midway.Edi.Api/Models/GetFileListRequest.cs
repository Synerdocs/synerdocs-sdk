using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Запрос на получение списка файлов
    /// </summary>
    [DataContract]
    public class GetFileListRequest
    {
        /// <summary>
        /// Учетные данные запроса
        /// </summary>
        [DataMember(IsRequired = true)]
        public RequestCredentials Credentials { get; set; }
    }
}
