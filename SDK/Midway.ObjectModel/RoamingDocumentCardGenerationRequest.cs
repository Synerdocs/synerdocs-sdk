using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на генерацию карточки документа, который участвует в обмене через роуминг.
    /// </summary>
    [DataContract]
    public class RoamingDocumentCardGenerationRequest : DocumentCardGenerationRequest
    {
        /// <summary>
        /// Модель карточки.
        /// </summary>
        [DataMember]
        public RoamingDocumentCard Model { get; set; }
    }
}
