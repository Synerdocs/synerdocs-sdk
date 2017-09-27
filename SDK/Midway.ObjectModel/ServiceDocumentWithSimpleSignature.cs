using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Служебный документ, подписанный простой ЭП.
    /// </summary>
    [DataContract]
    public class ServiceDocumentWithSimpleSignature : Document
    {
        /// <summary>
        /// Подпись к документу.
        /// </summary>
        [DataMember]
        public SimpleSignature Signature { get; set; }

        /// <summary>
        /// Список получателей.
        /// </summary>
        [DataMember]
        public MessageRecipient[] Recipients { get; set; }
    }
}
