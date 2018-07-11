using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый ответный титул транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillReplyTitleBase : TransportWaybillTitleBase
    {
        /// <summary>
        /// Идентификация файла обмена ТН.
        /// </summary>
        [DataMember]
        public FileIdentification ConsignorTitleIdentification { get; set; }
    }
}