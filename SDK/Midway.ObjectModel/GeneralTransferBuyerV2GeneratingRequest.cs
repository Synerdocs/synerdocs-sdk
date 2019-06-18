using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на генерацию титула покупателя УПД.
    /// Формат УПД, утвержденный ММВ-7-15/820.
    /// </summary>
    [DataContract]
    public class GeneralTransferBuyerV2GeneratingRequest : OperationRequest
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
        public GeneralTransferBuyerV2 Model { get; set; }

        /// <summary>
        /// ИД родительского документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ParentDocumentId { get; set; }
    }
}
