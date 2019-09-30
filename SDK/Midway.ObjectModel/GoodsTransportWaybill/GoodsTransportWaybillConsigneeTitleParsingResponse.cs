using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Ответ при парсинге титула грузополучателя товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillConsigneeTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула грузополучателя товарно-транспортной накладной.
        /// </summary>
        [DataMember]
        public GoodsTransportWaybillConsigneeTitle Model { get; set; }
    }
}