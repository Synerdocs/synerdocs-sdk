using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������ ���������� �� �����������
    /// </summary>
    [DataContract]
    public class Organization
    {
        /// <summary>
        /// 
        /// </summary>
        public Organization()
        {
            ContactAuthType = ContactAuthType.Accept;
            OrganizationStatus = OrganizationStatus.NonActive;
        }

        /// <summary>
        /// �� �����������
        /// </summary>
        [DataMember]
        public string OrganizationId { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }
        
        /// <summary>
        /// �������� �����������
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// ������� �����������
        /// </summary>
        [DataMember]
        public string Tel { get; set; }

        /// <summary>
        /// ���� �����������
        /// </summary>
        [DataMember]
        public string Fax { get; set; }

        /// TODO@��������
        /// <summary>
        /// </summary>
        [DataMember]
        public bool? State { get; set; }

        /// <summary>
        /// ����������� �������� �����������
        /// </summary>
        [DataMember]
        public string LegalName { get; set; }

        /// <summary>
        /// ��������������-�������� ����� (���, ���, � �.�.)
        /// </summary>
        [DataMember]
        public string LegalForm { get; set; }

        /// <summary>
        /// ������� ����������� ��������
        /// </summary>
        [DataMember]
        public bool IsForeignCompany { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// ������������ ����� �����������
        /// </summary>
        [DataMember]
        public string Bank { get; set; }

        /// <summary>
        /// ���������� ����������������� ��� �����������
        /// </summary>
        [DataMember]
        public string Bik { get; set; }

        /// <summary>
        /// ����������������� ���� �����������
        /// </summary>
        [DataMember]
        public string CorrespondentAccount { get; set; }

        /// <summary>
        /// ��������� ���� �����������
        /// </summary>
        [DataMember]
        public string CurrentAccount { get; set; }

        /// <summary>
        /// ������ ������� �����������
        /// </summary>
        [DataMember]
        public OrganizationAddress[] Addresses { get; set; }

        /// <summary>
        /// ����������� ����� �����������
        /// </summary>
        [DataMember]
        [Obsolete("��� ����������� �������� �������������")]
        public Address LegalAddress { get; set; }

        /// <summary>
        /// �������� ����� �����������
        /// </summary>
        [DataMember]
        [Obsolete("��� ����������� �������� �������������")]
        public Address MailingAddress { get; set; }

        /// <summary>
        /// �� ��� ��
        /// </summary>
        [DataMember]
        [Obsolete("��� ����������� �������� �������������")]
        public bool IsJuridical { get; set; }

        /// <summary>
        /// ��� (��� ��)
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// ������� (��� ��)
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// �������� (��� ��)
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// ��� ����������� � ������ ������� ���, ������������ ��� ����������� ���
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }

        /// <summary>
        /// ����� ������������ ����� �����������
        /// </summary>
        [DataMember]
        public string BoxAddress { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [DataMember]
        public string Ogrn { get; set; }

        /// <summary>
        /// ��� ���������� ������
        /// </summary>
        [DataMember]
        public string Ifns { get; set; }

        /// <summary>
        /// ������������� ��������������� ����������� ��
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }

        /// TODO@internal
        /// <summary>
        /// ������ ���������� ���������
        /// </summary>
        [DataMember]
        public Int64 Version { get; set; }

        /// <summary>
        /// ������ ��������� ���
        /// </summary>
        [DataMember]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// ������ ��������� ��� �������-���������
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
        [DataMember]
        public string OperatorServiceName { get; set; }
        
        /// <summary>
        /// ������ ����������� � �������
        /// </summary>
        [DataMember]
        public OrganizationStatus OrganizationStatus { get; set; }

        /// <summary>
        /// ��� ����������� ���������
        /// </summary>
        [DataMember]
        public ContactAuthType ContactAuthType { get; set; }

        /// <summary>
        /// ������� "���������� ������ "������������� ��������� ���������"
        /// </summary>
        [DataMember]
        [Obsolete("��� ����������� �������� �������������")]
        public bool FeatureConfirmReceiptEnabled { get; set; }

        /// <summary>
        /// ������� "������� ����� � ��"
        /// </summary>
        [DataMember]
        [Obsolete("��� ����������� �������� �������������")]
        public bool ExchangeWithIndividualEnabled { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }
}