using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ��������� ��������
    /// </summary>
    [DataContract]
    public class ServiceDocument : Document
    {
        /// <summary>
        /// ������������� �������
        /// </summary>
        [DataMember]
        public string SignId { get; set; }

        /// <summary>
        /// ������� � ��������� (������������)
        /// </summary>
        [DataMember]
        public byte[] SignRaw { get; set; }

        /// <summary>
        /// ���� �������
        /// </summary>
        [DataMember]
        public DateTime SignDate { get; set; }

        /// <summary>
        /// ����� ������������ ����� �����������
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// ������������� ������������� �����������
        /// </summary>
        [DataMember]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// ����� ������������ ����� ����������
        /// </summary>
        [DataMember]
        public string To { get; set; }

        /// <summary>
        /// ������������� ������������� ����������
        /// </summary>
        [DataMember]
        public string ToDepartmentId { get; set; }

        /// <summary>
        /// ������ �����������
        /// </summary>
        [DataMember]
        public MessageRecipient[] Recipients { get; set; }

        /// <summary>
        /// ����� �������
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// ���� ������������ ������� ���������
        /// </summary>
        [DataMember]
        public bool IsValidSign { get; set; }
    }
}