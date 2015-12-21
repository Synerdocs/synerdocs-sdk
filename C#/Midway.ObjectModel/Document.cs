using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � ���������.
    /// ������������ ��� �������� � ��������� ����������
    /// </summary>
    [DataContract]
    public class Document
    {
        /// <summary>
        /// ������������� ��������� (�� ������������ ��� ��������)
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// �������� ���������
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// ��� ���������
        /// </summary>
        [DataMember]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// ���������� ���������
        /// </summary>
        [DataMember]
        public byte[] Content { get; set; }

        /// <summary>
        /// �������� ���������
        /// </summary>
        [DataMember]
        public byte[] Card { get; set; }

        /// <summary>
        /// ��� ����� ���������
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// ���� �������� ������� ��� ���������� 
        /// </summary>
        [DataMember]
        public bool NeedSign { get; set; }

        /// <summary>
        /// ������ ����� (�� ������������ ��� ��������)
        /// </summary>
        [DataMember]
        public int FileSize { get; set; }

        /// TODO@internal
        /// <summary>
        /// ������������� ���������, ����������� ��������
        /// </summary>
        public Guid MessageId { get; set; }

        /// <summary>
        /// ������������� ������������� ��������� � ������� ��������� ����������
        /// </summary>
        [DataMember]
        public string ParentDocumentId { get; set; }

        /// <summary>
        /// ������������� ������������� ��������� � ������� ���������� ������
        /// </summary>
        [DataMember]
        public string SourceDocumentId { get; set; }

        /// <summary>
        /// ������������� ��������� ���������, � �������� ��������� ��������� ��������. 
        /// </summary>
        [DataMember]
        public string RootDocumentId { get; set; }

        /// TODO@internal
        /// <summary>
        /// ��� ���������� ���������
        /// </summary>
        public DocumentServiceType DocumentServiceType { get; set; }

        /// <summary>
        /// �������������� ��������� ����������
        /// </summary>
        [DataMember]
        public string[] RelatedDocumentIds { get; set; }

        /// <summary>
        /// ����������� � ���������
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// ���� ��� �������� �������������� ����������. �� 255 ��������.
        /// </summary>
        [DataMember]
        public string CustomField { get; set; }

        /// TODO@���������
        /// <summary>
        /// ������� "��������"
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// ���� ����������� ���������� ���������
        /// </summary>
        [DataMember(IsRequired = false)]
        public bool IsLegitimate { get; set; }

        /// <summary>
        /// ������� �������������� ���������, ����������� � ���� ������� �����
        /// </summary>
        [DataMember(IsRequired = false)]
        public NonLegitimateReason[] NonLegitimateReasons { get; set; }

        /// <summary>
        /// ��� ����������������� ���������
        /// </summary>
        [DataMember(IsRequired = false)]
        public string UntypedKind { get; set; }
        
        /// <summary>
        /// ���� "������������� ��������� ��������� � ���������"
        /// </summary>
        [DataMember(IsRequired = false)]
        public bool NoticeRequired { get; set; }

        /// <summary>
        /// �������� ��������� ���������, ������� ������, ��� � �.�.
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? Sum { get; set; }

        /// <summary>
        /// ����� ���������, ��������� �������������
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Number { get; set; } 

        /// <summary>
        /// ���� ���������, ��������� �������������
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// ���� "������������� ������������� ����� ������ ���������"
        /// </summary>
        [DataMember]
        public bool NeedReceipt { get; set; }

        /// <summary>
        /// ���� ��������
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? SentDate { get; set; }

        /// <summary>
        /// ���� �����������
        /// </summary>
        [DataMember]
        public string FromBoxId { get; set; }
    }
}
