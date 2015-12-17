using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� �� ������������ ���������
    /// </summary>
    [DataContract]
    public class SentMessage
    {
        /// <summary>
        /// ��������������� ������������� ���������
        /// </summary>
        [DataMember]
        public string MessageId { get; set; }

        /// <summary>
        /// ��������������� �������������� ����������: ��������� � ���������
        /// ���� - �������� �������������
        /// </summary>
        [DataMember]
        public LocalServerId[] DocumentIds { get; set; }

        /// <summary>
        /// ���� ��������
        /// </summary>
        [DataMember]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// ��������������� �������������� ��������: ��������� � ���������.
        /// </summary>
        [DataMember]
        public LocalServerId[] SignIds { get; set; }

        /// <summary>
        /// ��� ��������. ����� ����� ���� ��������� � ��������, ��������� � ���� ��������� � �������� ���������
        /// </summary>
        [DataMember]
        public string[] Log { get; set; }
    }
}
