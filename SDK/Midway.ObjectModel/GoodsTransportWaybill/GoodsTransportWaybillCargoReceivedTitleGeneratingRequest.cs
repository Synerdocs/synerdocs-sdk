using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Запрос на генерацию титула водителя (прием груза) товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillCargoReceivedTitleGeneratingRequest : OperationRequest
    {
        /// <summary>
        /// Параметры генерации.
        /// </summary>
        [DataMember]
        public GoodsTransportWaybillGenerationOptions Options { get; set; }

        /// <summary>
        /// Модель документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public GoodsTransportWaybillCargoReceivedTitle Model { get; set; }

        /// <summary>
        /// Внешний ИД родительского документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ParentDocumentId { get; set; }
    }
}
