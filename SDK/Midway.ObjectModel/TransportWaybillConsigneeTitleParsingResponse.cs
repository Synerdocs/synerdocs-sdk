using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула грузополучателя транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillConsigneeTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула грузополучателя транспортной накладной.
        /// </summary>
        [DataMember]
        public TransportWaybillConsigneeTitle Model { get; set; }
    }
}