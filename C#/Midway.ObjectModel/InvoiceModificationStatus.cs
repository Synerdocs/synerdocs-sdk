using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������ ��������� �����-�������
    /// </summary>
    [DataContract]
    public enum InvoiceModificationStatus
    {
        /// <summary>
        /// ����-������� �� �������
        /// </summary>
        [EnumMember]
        Unchanged = 0,

        /// <summary>
        /// ��������� ������������ ����-�������
        /// </summary>
        [EnumMember]
        Revised = 1,

        /// <summary>
        /// ��������� ���������������� ����-�������
        /// </summary>
        [EnumMember]
        Corrected = 2,
    }
}
