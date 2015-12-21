using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ����� ��� �������� ���������� �� ���
    /// </summary>
    [DataContract]
    public class ServiceNotice
    {
        /// <summary>
        /// �������� ��� ���������
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// ����� �����������
        /// </summary>
        [DataMember]
        public string FromBoxId { get; set; }

        /// <summary>
        /// ������������� ������������� �����������
        /// </summary>
        [DataMember]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// ����� ����������
        /// </summary>
        [DataMember]
        public string ToBoxId { get; set; }

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
        /// ������������� ���������, �� ������� ��������� ���������
        /// </summary>
        [DataMember]
        public string ParentDocumentId { get; set; }

        /// <summary>
        /// ��� ���������, �� ������� ��������� ���������
        /// </summary>
        [DataMember]
        public DocumentType ParentDocumentType { get; set; }

        /// <summary>
        /// �������, ����������� ������������ ������������� ���������
        /// </summary>
        [DataMember]
        public bool ParentDocumentIsLegitimate { get; set; }

        /// <summary>
        /// ��� ��������� (���������)
        /// </summary>
        [DataMember]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// ������� ��������� � base64-���������
        /// </summary>
        [DataMember]
        public byte[] Content { get; set; }
    }
}
