using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������� ��������
    /// </summary>
    [DataContract]
    public enum ContactStatus : byte
    {
        /// <summary>
        /// �� �����������. ����� ����������
        /// </summary>
        [EnumMember]
        [Description("�� �����������")]
        NonAuthorized = 0x0,

        /// <summary>
        /// �����������. ����� ��������
        /// </summary>
        [EnumMember]
        [Description("�����������")]
        Active = 0x1,

        /// <summary>
        ///  ������. ����� ���������� (�� ������������)
        /// </summary>
        [EnumMember]
        [Description("������")]
        Deleted = 0x2,

        /// <summary>
        /// ��������� ������ �����������
        /// </summary>
        [EnumMember]
        [Description("���������� ����������� � ������")]
        OutgoingAuthRequest = 0x3,

        /// <summary>
        /// �������� ������ �����������
        /// </summary>
        [EnumMember]
        [Description("�������� ����������� � ������")]
        IncomingAuthRequest = 0x4,

        /// <summary>
        /// ����������� ������ �������� �����������. ����� ����������
        /// </summary>
        [EnumMember]
        [Description("��������� ����������� � ������")]
        AuthRejected = 0x5,

        /// <summary>
        /// �����, ����� ������������ (��� ������)
        /// </summary>
        [EnumMember]
        [Description("�����, ����� ������������")]
        NonActive = 0x6,

        /// <summary>
        /// ����������� ������ ��������� �����������. ����� � ������� ����������� ���������
        /// </summary>
        [EnumMember]
        [Description("����� ��������")]
        OutgoingAuthRejected = 0x7,

        /// <summary>
        /// ���������� ������ ��������� �����������. ����� ����������
        /// </summary>
        [EnumMember]
        [Description("�������� ������������ ����������� � ������")]
        OutgoingAuthCancelled = 0x8,

        /// <summary>
        /// ���������� ������ �������� �����������. ����� ����������
        /// </summary>
        [EnumMember]
        [Description("�������� ���������� ����������� � ������")]
        IncomingAuthCancelled = 0x9,
    }
}
