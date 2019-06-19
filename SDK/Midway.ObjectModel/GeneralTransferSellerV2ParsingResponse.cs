using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при парсинге титула продавца УПД.
    /// Формат УПД, утвержденный ММВ-7-15/820.
    /// </summary>
    [DataContract]
    public class GeneralTransferSellerV2ParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула продавца УПД.
        /// </summary>
        [DataMember]
        public GeneralTransferSellerV2 Model { get; set; }
    }
}
