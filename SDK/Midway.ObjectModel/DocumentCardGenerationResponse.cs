using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос на генерацию карточки документа.
    /// </summary>
    [DataContract]
    public class DocumentCardGenerationResponse : OperationResponse
    {
        /// <summary>
        /// Сгенерированное содержимое карточки документа.
        /// </summary>
        [DataMember]
        public GeneratedContent GeneratedContent { get; set; }
    }
}
