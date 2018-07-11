using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула перевозчика транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCarrierTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула перевозчика транспортной накладной.
        /// </summary>
        [DataMember]
        public TransportWaybillCarrierTitle Model { get; set; }
    }
}