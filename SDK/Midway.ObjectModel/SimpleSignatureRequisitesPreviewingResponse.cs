using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при предварительном просмотре реквизитов простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureRequisitesPreviewingResponse : OperationResponse
    {
        /// <summary>
        /// Реквизиты простой ЭП.
        /// </summary>
        [DataMember]
        public SimpleSignatureRequisites Requisites { get; set; }
    }
}
