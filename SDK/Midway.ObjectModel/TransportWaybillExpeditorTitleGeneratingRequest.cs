using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на генерацию титула экспедитора транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillExpeditorTitleGeneratingRequest : OperationRequest
    {
        /// <summary>
        /// Параметры генерации.
        /// </summary>
        [DataMember]
        public TransportWaybillGenerationOptions Options { get; set; }

        /// <summary>
        /// Модель документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public TransportWaybillExpeditorTitle Model { get; set; }

        /// <summary>
        /// Внешний ИД родительского документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ParentDocumentId { get; set; }
    }
}
