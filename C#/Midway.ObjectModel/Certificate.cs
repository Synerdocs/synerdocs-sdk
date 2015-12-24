using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� �� �����������
    /// </summary>
    [DataContract]
    public class Certificate
    {
        /// <summary>
        /// �������������
        /// </summary>
        [DataMember]
        public int CertificateId { get; set; }

        /// <summary>
        /// ������� "����������������� ����������"
        /// </summary>
        [DataMember]
        public bool QualifiedCertificate { get; set; }

        /// <summary>
        /// �������� �����
        /// </summary>
        [DataMember]
        public string SerialNumber { get; set; }

        /// <summary>
        /// ������ ����� �������� �����������
        /// </summary>
        [DataMember]
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// ����� ����� �������� �����������
        /// </summary>
        [DataMember]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// �������� ����
        /// </summary>
        [DataMember]
        public byte[] PublicKey { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string IssuerName { get; set; }
        
        /// <summary>
        /// �������� �������
        /// </summary>
        [DataMember]
        public string SignatureAlgorithm { get; set; }
        
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [DataMember]
        public byte[] Raw { get; set; }
        
        /// <summary>
        /// ��������� �����������
        /// </summary>
        [DataMember]
        public string Thumbprint { get; set; }

        /// <summary>
        /// ����� ������������
        /// </summary>
        [DataMember]
        public string Login { get; set; }

        /// <summary>
        /// ������������� �����������
        /// </summary>
        [DataMember]
        public string OrganizationId { get; set; }
       
        /// <summary>
        /// ������� "�������� ����������"
        /// </summary>
        [DataMember]
        public bool IsTest { get; set; }
    }
}
