using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ��������� ������ ���������
    /// </summary>
    [DataContract]
    public class ContactSearchResult
    {
        /// <summary>
        /// ����� ���������� ���������, ��������������� �������� ������
        /// </summary>
        [DataMember]
        public int TotalCount { get; set; }

        /// <summary>
        /// ��������� ��������, ������������ ����������� From � Max
        /// </summary>
        [DataMember]
        public ContactSearchItem[] Items { get; set; }
    }
}
