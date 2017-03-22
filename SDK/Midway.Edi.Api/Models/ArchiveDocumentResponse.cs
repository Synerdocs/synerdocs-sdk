using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Ответ при архивировании документа
    /// </summary>
    [DataContract]
    public class ArchiveDocumentResponse
    {
        /// <summary>
        /// Результат ответа
        /// </summary>
        [DataMember]
        public ResponseResult Result { get; set; }
    }
}
