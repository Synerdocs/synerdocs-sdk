using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Ответ при парсинге титула грузоотправителя товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillConsignorTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула грузоотправителя товарно-транспортной накладной.
        /// </summary>
        [DataMember]
        public GoodsTransportWaybillConsignorTitle Model { get; set; }
    }
}
