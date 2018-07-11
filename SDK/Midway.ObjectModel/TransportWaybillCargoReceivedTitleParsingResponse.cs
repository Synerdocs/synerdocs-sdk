using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула водителя (прием груза) транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCargoReceivedTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула водителя (прием груза) транспортной накладной.
        /// </summary>
        [DataMember]
        public TransportWaybillCargoReceivedTitle Model { get; set; }
    }
}
