using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на предварительный просмотр реквизитов простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureRequisitesPreviewingRequest : OperationRequest
    {
        /// <summary>
        /// Комментарий к подписанию.
        /// </summary>
        [DataMember]
        public string Comment { get; set; }
    }
}
