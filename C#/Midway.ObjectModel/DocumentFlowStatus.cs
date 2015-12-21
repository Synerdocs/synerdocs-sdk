using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������ ����������������
    /// ������� �����. ���������� ���������� ������� �� ���� ���������.
    /// </summary>
    [DataContract]
    [KnownType(typeof(UntypedDocumentFlowStatus))]
    [KnownType(typeof(UntypedDocumentMultiFlowStatus))]
    [KnownType(typeof(InvoiceDocumentFlowStatus))]
    public class DocumentFlowStatus
    {
    }
}
