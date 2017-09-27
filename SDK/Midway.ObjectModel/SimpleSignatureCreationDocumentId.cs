using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс для обозначения ИД сщуествующего документа, подписываемого простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureCreationDocumentId : SimpleSignatureCreationDocument
    {
        /// <summary>
        /// ИД документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Id { get; set; }
    }
}
