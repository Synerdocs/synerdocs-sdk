using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула изменения места доставки транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillDeliveryPlaceChangeTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула изменения места доставки транспортной накладной.
        /// </summary>
        [DataMember]
        public TransportWaybillDeliveryPlaceChangeTitle Model { get; set; }
    }
}