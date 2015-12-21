using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � ���������, ������������ ��� ��������� ������ ��������� �� �����
    /// </summary>
    [DataContract]
    public class MessageInfo
    {
        /// <summary>
        /// ������������� ���������
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// ���� �����������
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// ���� ��������
        /// </summary>
        [DataMember]
        public string To { get; set; }

        /// <summary>
        /// ����� �����������
        /// </summary>
        [DataMember]
        public string[] Recipients { get; set; }
    }
}
