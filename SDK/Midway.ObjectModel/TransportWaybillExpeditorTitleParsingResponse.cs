using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула экспедитора транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillExpeditorTitleParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула экспедитора транспортной накладной.
        /// </summary>
        [DataMember]
        public TransportWaybillExpeditorTitle Model { get; set; }
    }
}
