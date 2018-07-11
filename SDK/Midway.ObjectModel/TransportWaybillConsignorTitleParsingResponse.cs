using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула грузоотправителя транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillConsignorTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель  титула грузоотправителя транспортной накладной.
        /// </summary>
        [DataMember]
        public TransportWaybillConsignorTitle Model { get; set; }
    }
}
