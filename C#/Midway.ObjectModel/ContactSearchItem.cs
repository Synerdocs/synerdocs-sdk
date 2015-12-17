using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������� ������ ���������. ������������ � ������ ���������
    /// </summary>
    [DataContract]
    public class ContactSearchItem
    {
        /// <summary>
        /// �� �����������
        /// </summary>
        [DataMember]
        public int ContragentId { get; set; }

        /// <summary>
        /// ��� ����������� �����������
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// �� ��� ��
        /// </summary>
        [DataMember]
        [Obsolete("��� ����������� �������� �������������")]
        public bool ContragentIsJuridical { get; set; }

        /// <summary>
        /// ������������ ����������� �����������
        /// </summary>
        [DataMember]
        public string ContragentName { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public string ContragentInn { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public string ContragentKpp { get; set; }

        /// <summary>
        /// ����������� ����������
        /// </summary>
        [DataMember]
        public bool ContragentIsForeignCompany { get; set; }

        /// <summary>
        /// ����� �����������
        /// </summary>
        [DataMember]
        public Address ContragentAddress { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [DataMember]
        public ContactStatus Status { get; set; }

        /// <summary>
        /// ���� ���������� ��������� ��������
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// ����� ������������ �����
        /// </summary>
        [DataMember]
        public string BoxAddress { get; set; }

        /// <summary>
        /// ����������� ���������� ��������� ��������
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// ���������� ��� ����������� � ������ ������������ ���������� ��������� ����������������
        /// </summary>
        [DataMember]
        public string ContragentServiceCode { get; set; }

        /// <summary>
        /// ���������� ������ ��������� �������
        /// </summary>
        [DataMember]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// ���������� ������ ��������� ��� ��
        /// </summary>
        [DataMember]
        public bool InvoiceReglamentAccepted { get; set; }

        /// <summary>
        /// ��� ��������� ���
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }

        /// <summary>
        /// ������������ ������� ��������� ���
        /// </summary>
        [DataMember(IsRequired = false)]
        public string OperatorServiceName { get; set; }

        /// <summary>
        /// ������ ����������� � �������
        /// </summary>
        [DataMember]
        public OrganizationStatus OrganizationStatus { get; set; }
    }
}
