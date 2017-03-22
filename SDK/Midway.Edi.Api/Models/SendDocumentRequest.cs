using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Запрос на отправку документа
    /// </summary>
    [DataContract]
    public class SendDocumentRequest
    {
        /// <summary>
        /// Учетные данные запроса
        /// </summary>
        [DataMember(IsRequired = true)]
        public RequestCredentials Credentials { get; set; }

        /// <summary>
        /// Отправляемый документ
        /// </summary>
        [DataMember(IsRequired = true)]
        public DocumentData Document { get; set; }
    }
}
