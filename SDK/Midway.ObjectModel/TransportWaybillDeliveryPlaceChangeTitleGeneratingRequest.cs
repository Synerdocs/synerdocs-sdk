using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на генерацию титула изменения места доставки транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillDeliveryPlaceChangeTitleGeneratingRequest : OperationRequest
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
        public TransportWaybillDeliveryPlaceChangeTitle Model { get; set; }

        /// <summary>
        /// Внешний ИД родительского документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ParentDocumentId { get; set; }
    }
}