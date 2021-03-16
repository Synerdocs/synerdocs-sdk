using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Ответ при парсинге титула покупателя УКД версии 3.
    /// Формат УКД, утвержденный приказом № ЕД-7-26/736.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionBuyerTitleV3ParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула покупателя УКД версии 3.
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionBuyerTitleV3 Model { get; set; }
    }
}
