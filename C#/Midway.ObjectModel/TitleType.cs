using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ��� ���������
    /// TODO ������������� �����
    /// </summary>
    [DataContract]
    public enum TitleType
    {
        /// <summary>
        /// ��� ����������� �����
        /// </summary>
        [EnumMember]
        Act,

        /// <summary>
        /// �������� ���������
        /// </summary>
        [EnumMember]
        Torg12
    }
}
