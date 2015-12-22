using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ��� ���������
    /// </summary>
    [DataContract]
    public enum DocumentType
    {
        /// <summary>
        /// ����������������� ��������
        /// </summary>
        [EnumMember]
        [Description("�����������������")]
        Untyped = 0x0,

        /// <summary>
        /// ����-�������
        /// </summary>
        [EnumMember]
        [Description("����-�������")]
        Invoice = 0x1,

        /// <summary>
        /// ��������� ��������: ������������� (��������� ���)
        /// </summary>
        [EnumMember]
        [Description("���������: ������������� (��������� ���)")]
        ServiceInvoiceConfirmation = 0x2,

        /// <summary>
        /// ��������� ��������: ��������� (��������� ���)
        /// </summary>
        [EnumMember]
        [Description("���������: ��������� (��������� ���)")]
        ServiceInvoiceReceipt = 0x4,

        /// <summary>
        /// ��������� ��������: ����������� �� ��������� (��������� ���)
        /// </summary>
        [EnumMember]
        [Description("���������: ����������� �� ��������� (��������� ���)")]
        ServiceInvoiceAmendmentRequest = 0x5,

        /// <summary>
        /// ����������� �� ���������, ����� �� ������� (����� ���������)
        /// </summary>
        [EnumMember]
        [Description("���������: ����������� �� ���������, ����� �� ������� (����� ���������)")]
        ServiceAmendmentRequest = 0x6,

        /// <summary>
        /// ����������� � ��������� (�� ������������)
        /// </summary>
        [EnumMember]
        [Description("")]
        Comment = 0x7,

        /// <summary>
        /// ��������� ��������: ��������� � ��������� (����� ���������)
        /// </summary>
        [EnumMember]
        [Description("���������: ��������� � ��������� (����� ���������)")]
        ServiceReceipt = 0x8,

        /// <summary>
        /// ���������� ����-�������
        /// </summary>
        [EnumMember]
        [Description("���������� ����-�������")]
        InvoiceRevision = 0x09,

        /// <summary>
        /// ���������������� ����-�������
        /// </summary>
        [EnumMember]
        [Description("���������������� ����-�������")]
        InvoiceCorrection = 0x0A,

        /// <summary>
        /// ���������� ���������������� ����-�������
        /// </summary>
        [EnumMember]
        [Description("���������� ���������������� ����-�������")]
        InvoiceCorrectionRevision = 0x0B,

        /// <summary>
        /// �������� ��������� (����� ��������)
        /// </summary>
        [EnumMember]
        [Description("�������� ���������")]
        WaybillSeller = 0x0C,

        /// <summary>
        /// �������� ��������� (����� ����������)
        /// </summary>
        [EnumMember]
        [Description("���������: �������� ��������� (����� ����������)")]
        WaybillBuyer = 0x0D,

        /// <summary>
        /// ��� � ���������� ����� (����� �����������)
        /// </summary>
        [EnumMember]
        [Description("��� � ���������� �����")]
        ActOfWorkSeller = 0x0E,

        /// <summary>
        /// ��� � ���������� ����� (����� ���������)
        /// </summary>
        [EnumMember]
        [Description("���������: ��� � ���������� ����� (����� ���������)")]
        ActOfWorkBuyer = 0x0F,

        /// <summary>
        /// ��������� ��������: ��������� �� ������
        /// </summary>
        [EnumMember]
        [Description("���������: ��������� �� ������")]
        ErrorReceipt = 0x10
    }
}
