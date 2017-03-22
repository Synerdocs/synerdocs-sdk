using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Ответ при получении списка файлов
    /// </summary>
    [DataContract]
    public class GetFileListResponse
    {
        /// <summary>
        /// Результат ответа
        /// </summary>
        [DataMember]
        public ResponseResult Result { get; set; }

        /// <summary>
        /// Список файлов
        /// </summary>
        [DataMember]
        public List<string> Files { get; set; }
    }
}
