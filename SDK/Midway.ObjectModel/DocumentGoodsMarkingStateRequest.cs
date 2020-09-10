using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на получение состояния товарной маркировки документа.
    /// </summary>
    [DataContract]
    public class DocumentGoodsMarkingStateRequest : OperationRequest
    {
        /// <summary>
        /// ID документа с маркировками.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string DocumentId { get; set; }
    }
}
