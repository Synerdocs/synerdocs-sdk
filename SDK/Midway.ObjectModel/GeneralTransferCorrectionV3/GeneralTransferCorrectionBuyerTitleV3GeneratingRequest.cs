using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Запрос на генерацию титула покупателя УКД версии 3.
    /// Формат УКД, утвержденный приказом № ЕД-7-26/736.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionBuyerTitleV3GeneratingRequest : OperationRequest
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
        public GeneralTransferCorrectionBuyerTitleV3 Model { get; set; }

        /// <summary>
        /// ИД родительского документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ParentDocumentId { get; set; }
    }
}
