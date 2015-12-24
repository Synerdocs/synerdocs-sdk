using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������ ���������
    /// </summary>
    [DataContract]
    public enum MessageStatus : short
    {
        /// <summary>
        /// ����������
        /// </summary>
        [EnumMember]
        Sent = 0x0,

        /// <summary>
        /// ��������� ����������� � �������
        /// </summary>
        [EnumMember]
        Pending = 0x1,

        /// <summary>
        /// �� ������� ��������� ��������� ��-�� ������
        /// </summary>
        [EnumMember]
        DeliveryError = 0x2,

        /// <summary>
        /// �������� ��������\�� ����������
        /// </summary>
        [EnumMember]
        NotTreated = 0x3
    }
}