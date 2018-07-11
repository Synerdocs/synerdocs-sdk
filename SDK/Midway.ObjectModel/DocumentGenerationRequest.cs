using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на генерацию документа.
    /// </summary>
    [DataContract]
    public class DocumentGenerationRequest : OperationRequest
    {
        /// <summary>
        /// Параметры генерации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public DocumentGenerationOptions Options { get; set; }
    }
}
