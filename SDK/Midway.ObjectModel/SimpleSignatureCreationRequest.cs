using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на создание простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureCreationRequest : OperationRequest
    {
        /// <summary>
        /// Подписываемый документ.
        /// </summary>
        [DataMember(IsRequired = true)]
        public SimpleSignatureCreationDocument Document { get; set; }

        /// <summary>
        /// Комментарий к подписанию.
        /// </summary>
        [DataMember]
        public string Comment { get; set; }
    }
}
