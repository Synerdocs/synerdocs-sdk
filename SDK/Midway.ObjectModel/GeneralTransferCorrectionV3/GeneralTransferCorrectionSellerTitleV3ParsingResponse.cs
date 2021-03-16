using System.Runtime.Serialization;
using Midway.ObjectModel.GeneralTransferCorrectionV3;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Ответ при парсинге титула УКД ММВ-7-15/189.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionSellerTitleV3ParsingResponse : OperationResponse
    {
        /// <summary>
        /// Модель титула УКД ММВ-7-15/189.
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionSellerTitleV3 Model { get; set; }
    }
}
