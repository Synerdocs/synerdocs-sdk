using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������������� ������������� ���������
    /// </summary>
    [DataContract]
    public class LocalServerId
    {
        /// <summary>
        /// ��������� ������������� ��������� (�� ������� �������)
        /// </summary>
        [DataMember]
        public string LocalId { get; set; }

        /// <summary>
        /// ������������� ��������� � ������� ������
        /// </summary>
        [DataMember]
        public string ServiceId { get; set; }
    }
}