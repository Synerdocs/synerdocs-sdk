using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс для обозначения документа, у которого требуется проверить возможность подписания простой ЭП.
    /// </summary>
    [DataContract]
    [KnownType(typeof(SimpleSignatureAvailabilityCheckingDocumentId))]
    [KnownType(typeof(SimpleSignatureAvailabilityCheckingDocumentType))]
    [KnownType(typeof(SimpleSignatureAvailabilityCheckingDocumentContent))]
    public class SimpleSignatureAvailabilityCheckingDocument
    {
    }
}
