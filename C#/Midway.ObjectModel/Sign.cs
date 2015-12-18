using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������� ��� ����������. ������������ ��������� �������:
    ///  - ������ � ����������. � ���� ������ ����� �������� ������� �����������;
    ///  - �������� �� ���������. � ���� ������ ����� �������� ������� ����������.
    /// </summary>
    [DataContract]
    public class Sign
    {
        /// <summary>
        /// ������������� �������������� ���������
        /// </summary>
        [DataMember]
        public string DocumentId { get; set; } // uniqueidentifier

        /// <summary>
        /// ���������� �������
        /// </summary>
        [DataMember]
        public byte[] Raw { get; set; } // varbinary(-1)

        /// <summary>
        /// ���� �������� �������
        /// </summary>
        [DataMember]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// ����������� �������
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// TODO@internal � ���� �� ��� ������ internal?
        /// <summary>
        /// ������������� ���������, ����������� ������ �������
        /// </summary>
        public Guid? MessageId { get; set; } // uniqueidentifier

        /// <summary>
        /// ������� ����������� �������
        /// </summary>
        [DataMember]
        public string Subject { get; set; }
        
        /// <summary>
        /// ������������� �������
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// ������������� �������������� �������
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }

        /// TODO: ������ ��� �� Nullabe?
        /// <summary>
        /// ����� �� ������
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// ���� ������������ ������� ���������
        /// </summary>
        [DataMember]
        public bool IsValid { get; set; }
    }
}
