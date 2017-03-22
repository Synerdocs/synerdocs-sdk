using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Ответ при получении документа
    /// </summary>
    [DataContract]
    public class GetDocumentResponse
    {
        /// <summary>
        /// Результат ответа
        /// </summary>
        [DataMember]
        public ResponseResult Result { get; set; }

        /// <summary>
        /// Полученный документ
        /// </summary>
        [DataMember]
        public DocumentData Document { get; set; }
    }
}
