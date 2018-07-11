using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Идентификация файла.
    /// </summary>
    [DataContract]
    public class FileIdentification
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FileId { get; set; }

        /// <summary>
        /// Электронные подписи.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<byte[]> Signatures { get; set; }
    }
}
