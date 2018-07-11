using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула водителя (сдача груза) транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCargoDeliveredTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула водителя (сдача груза) транспортной накладной.
        /// </summary>
        [DataMember]
        public TransportWaybillCargoDeliveredTitle Model { get; set; }
    }
}
