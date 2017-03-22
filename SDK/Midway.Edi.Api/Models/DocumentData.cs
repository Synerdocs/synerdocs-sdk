using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Данные документа
    /// </summary>
    [DataContract]
    public class DocumentData
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FileName { get; set; }

        /// <summary>
        /// Содержимое
        /// </summary>
        [DataMember(IsRequired = true)]
        public byte[] Content { get; set; }
    }
}
