using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула покупателя УПД.
    /// Формат УПД, утвержденный ММВ-7-15/820.
    /// </summary>
    [DataContract]
    public class GeneralTransferBuyerV2ParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула покупателя УПД.
        /// </summary>
        [DataMember]
        public GeneralTransferBuyerV2 Model { get; set; }
    }
}
