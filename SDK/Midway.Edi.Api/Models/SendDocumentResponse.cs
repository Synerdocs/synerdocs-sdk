using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Ответ при отправке документа
    /// </summary>
    [DataContract]
    public class SendDocumentResponse
    {
        /// <summary>
        /// Результат ответа
        /// </summary>
        [DataMember]
        public ResponseResult Result { get; set; }
    }
}
