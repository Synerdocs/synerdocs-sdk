using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Ответ при парсинге титула водителя (сдача груза) товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillCargoDeliveredTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула водителя (сдача груза) товарно-транспортной накладной.
        /// </summary>
        [DataMember]
        public GoodsTransportWaybillCargoDeliveredTitle Model { get; set; }
    }
}
