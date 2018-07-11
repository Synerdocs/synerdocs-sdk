using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг.
    /// </summary>
    [DataContract]
    public class ParsingRequest : OperationRequest
    {
        /// <summary>
        /// Содержимое документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public byte[] Content { get; set; }
    }
}
