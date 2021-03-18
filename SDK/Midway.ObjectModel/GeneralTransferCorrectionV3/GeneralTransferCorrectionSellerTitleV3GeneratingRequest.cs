using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Запрос на генерацию титула продавца УКД.
    /// Формат УКД, утвержденный ММВ-7-15/189.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionSellerTitleV3GeneratingRequest : OperationRequest
    {
        /// <summary>
        /// Параметры генерации.
        /// </summary>
        [DataMember(IsRequired = false)]
        public DocumentGenerationOptions Options { get; set; }

        /// <summary>
        /// Модель документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public GeneralTransferCorrectionSellerTitleV3 Model { get; set; }
    }
}
