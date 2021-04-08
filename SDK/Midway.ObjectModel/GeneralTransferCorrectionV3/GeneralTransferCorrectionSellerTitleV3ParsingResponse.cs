using System.Runtime.Serialization;
using Midway.ObjectModel.GeneralTransferCorrectionV3;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Ответ при парсинге титула УКД ЕД-7-26/736.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionSellerTitleV3ParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула УКД ЕД-7-26/736.
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionSellerTitleV3 Model { get; set; }
    }
}
