using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Запрос на генерацию титула грузоотправителя товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillConsignorTitleGeneratingRequest : OperationRequest
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
        public GoodsTransportWaybillConsignorTitle Model { get; set; }
    }
}
