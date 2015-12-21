using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// �������� ��� ������� ���������� �� �����������
    /// </summary>
    [DataContract]
    public enum OrganizationByCriteria
    {
        /// <summary>
        /// ������� �� ��
        /// </summary>
        [EnumMember]
        ById = 0x0,

        /// <summary>
        /// ������� �� ���/���
        /// </summary>
        [EnumMember]
        ByInnKpp = 0x1,

        /// <summary>
        /// ������� �� ������ �����
        /// </summary>
        [EnumMember]
        ByBoxAddress = 0x2,

        /// <summary>
        /// ������� �� ���� ����������� � ������ ������� ���
        /// </summary>
        [EnumMember]
        ByServiceCode = 0x3
    }
}
