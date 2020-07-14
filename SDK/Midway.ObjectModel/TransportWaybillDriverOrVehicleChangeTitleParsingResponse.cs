using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула изменения водителя и/или ТС транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillDriverOrVehicleChangeTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула изменения водителя и/или ТС транспортной накладной.
        /// </summary>
        [DataMember]
        public TransportWaybillDriverOrVehicleChangeTitle Model { get; set; }
    }
}
