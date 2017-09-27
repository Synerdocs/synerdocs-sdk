using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс для обозначения документа, подписываемого простой ЭП.
    /// </summary>
    [DataContract]
    [KnownType(typeof(SimpleSignatureCreationDocumentId))]
    [KnownType(typeof(SimpleSignatureCreationDocumentData))]
    public class SimpleSignatureCreationDocument
    {
    }
}
