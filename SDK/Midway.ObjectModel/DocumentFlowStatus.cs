using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус документооборота
    /// Базовый класс. Конкретная реализация зависит от типа документа.
    /// </summary>
    [DataContract]
    [KnownType(typeof(UntypedDocumentFlowStatus))]
    [KnownType(typeof(UntypedDocumentMultiFlowStatus))]
    [KnownType(typeof(InvoiceDocumentFlowStatus))]
    public class DocumentFlowStatus
    {
    }
}
