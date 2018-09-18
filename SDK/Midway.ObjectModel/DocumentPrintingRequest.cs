using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на печать документа.
    /// </summary>
    [DataContract]
    public class DocumentPrintingRequest : OperationRequest
    {
        /// <summary>
        /// Внешний ИД документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string DocumentId { get; set; }
    }
}
