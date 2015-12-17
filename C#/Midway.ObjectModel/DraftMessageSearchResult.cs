using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ��������� ������ ����������
    /// </summary>
    [DataContract]
    public class DraftMessageSearchResult
    {
        /// <summary>
        /// ����� ���������� ������� �� ����������� ������
        /// </summary>
        [DataMember]
        public int TotalCount { get; set; }

        /// <summary>
        /// ��������� ���������
        /// </summary>
        [DataMember]
        public DraftMessage[] Items { get; set; }
    }
}
