using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ��������� ������ ���������
    /// </summary>
    [DataContract]
    public class ContactSearchOptions
    {
        /// <summary>
        /// ����� ������, ������� � �������� ������ ����� � ������ ���������
        /// </summary>
        [DataMember]
        public int From { get; set; }

        /// <summary>
        /// ���������� ���������� �������
        /// </summary>
        [DataMember]
        public int Max { get; set; }

        /// <summary>
        /// �� �����������, �������������� �����
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// ������ ������. � ������ ������ ����� ��������� 
        /// ����� ������������, ���, ���
        /// </summary>
        [DataMember]
        public string SearchString { get; set; }

        /// <summary>
        /// ������ ��������
        /// </summary>
        [DataMember]
        public ContactStatus ContactStatus { get; set; }

        /// <summary>
        /// ���� ��������� ���������� ����������� � �����
        /// </summary>
        [DataMember]
        public bool IncludeNonActive { get; set; }
    }
}
