using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// TODO ����� ������ �� ���������� ��� ����-����� ������������� ��������� �������� ��������� ����������
    /// <summary>
    /// ������� ���
    /// </summary>
    [DataContract]
    public enum InvoiceFlowStatus
    {
        /// <summary>
        /// ��� ��������� (��� ��������� ������ ����� ���� ��� ��� ��� ��������� ����� ������)
        /// </summary>
        [EnumMember]
        InvoiceSent = 0x0,

        /// <summary>
        /// ��� ��������� (�������� ��� ����������� ��)
        /// </summary>
        [EnumMember]
        InvoiceCharged = 0x1,

        /// <summary>
        /// ��� �������� (��������� ������ �� ���������)
        /// </summary>
        [EnumMember]
        InvoiceRejected = 0x2,

        /// <summary>
        /// ��� �������������� (� ������� 3� ����� �� ������� ��� ����������� ��)
        /// </summary>
        [EnumMember]
        InvoiceNotValid = 0x3
    }
}