using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос на генерацию документа.
    /// </summary>
    [DataContract]
    public class DocumentGenerationResponse : OperationResponse
    {
        /// <summary>
        /// Сгенерированное содержимое документа.
        /// </summary>
        [DataMember]
        public GeneratedContent GeneratedContent { get; set; }
    }
}
