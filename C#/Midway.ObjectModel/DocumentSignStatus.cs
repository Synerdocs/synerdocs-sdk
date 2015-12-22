using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������ ���������� ��������� �����������
    /// </summary>
    [DataContract]
    public enum DocumentSignStatus
    {
        /// <summary>
        /// ������� ���������� �� ���������
        /// </summary>
        [Description("������� �� ���������")]
        [EnumMember]
        NoSignNeeded = 0x00,

        /// <summary>
        /// ��������� ������� ����������
        /// </summary>
        [Description("��������� �������")]
        [EnumMember]
        WaitingForSign = 0x01,

        /// <summary>
        /// �������� �������� �����������
        /// </summary>
        [Description("��������")]
        [EnumMember]
        Signed = 0x02,

        /// <summary>
        /// ���������� ��������� ����������� ��������
        /// </summary>
        [Description("��������")]
        [EnumMember]
        SignRejected = 0x03,
    }
}
