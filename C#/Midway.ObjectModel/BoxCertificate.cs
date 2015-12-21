using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� ����-���������� (� ��������� ��������������� ������������)
    /// TODO ���� ���� �������� OraganizationId
    /// </summary>
    [DataContract]
    public class BoxCertificate
    {
        /// <summary>
        /// ����� ����������� � �������
        /// TODO ��� ����, ����� ������������ ������������ � Message; ���� �������� ������� BoxAddress
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// ��������� �����������
        /// </summary>
        [DataMember]
        public string Thumbprint { get; set; }

        /// <summary>
        /// CN �����������
        /// </summary>
        [DataMember]
        public string CommonName { get; set; }

        /// <summary>
        /// ������� ������������������ �����������
        /// </summary>
        [DataMember]
        public bool IsQualified { get; set; }
    }
}