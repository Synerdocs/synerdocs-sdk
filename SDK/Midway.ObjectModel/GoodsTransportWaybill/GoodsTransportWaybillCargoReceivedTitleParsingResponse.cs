using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Ответ при парсинге титула водителя (прием груза) товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillCargoReceivedTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула водителя (прием груза) товарно-транспортной накладной.
        /// </summary>
        [DataMember]
        public GoodsTransportWaybillCargoReceivedTitle Model { get; set; }
    }
}
