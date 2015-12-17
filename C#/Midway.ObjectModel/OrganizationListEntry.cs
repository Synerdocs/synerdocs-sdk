using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������ �� ����������� ��� ����������� � ���� ������
    /// </summary>
    [DataContract]
    public class OrganizationListEntry
    {
        /// <summary>
        /// ������������� �����������
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// ������������ �����������
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// ����������� ������������ �����������
        /// </summary>
        [DataMember]
        public string LegalName { get; set; }

        /// <summary>
        /// ����� �������������
        /// </summary>
        [DataMember]
        public string LegalForm { get; set; }

        /// <summary>
        /// ������� ����������� �����������
        /// </summary>
        [DataMember]
        public bool IsForeignCompany { get; set; }

        /// <summary>
        /// ����������� ����� ����������� �����������
        /// </summary>
        [DataMember]
        public string LegalAddressForeign { get; set; }

        /// <summary>
        /// �������� ����� ����������� �����������
        /// </summary>
        [DataMember]
        public string MailingAddressForeign { get; set; }

        #region ����������� �����

        /// <summary>
        /// ����������� �����: �����
        /// </summary>
        [DataMember]
        public string LegalAddressCity { get; set; }

        /// <summary>
        /// ����������� �����: ���
        /// </summary>
        [DataMember]
        public int? LegalAddressHouse { get; set; }

        /// <summary>
        /// ����������� �����: ��������, ����
        /// </summary>
        [DataMember]
        public int? LegalAddressApartment { get; set; }

        /// <summary>
        /// ����������� �����: ��������
        /// </summary>
        [DataMember]
        public string LegalAddressBuilding { get; set; }

        /// <summary>
        /// ����������� �����: ���������� �����
        /// </summary>
        [DataMember]
        public string LegalAddressLocality { get; set; }

        /// <summary>
        /// ����������� �����: �����
        /// </summary>
        [DataMember]
        public string LegalAddressDistrict { get; set; }

        /// <summary>
        /// ����������� �����: �����
        /// </summary>
        [DataMember]
        public string LegalAddressStreet { get; set; }

        #endregion ����������� �����

        #region �������� �����

        /// <summary>
        /// �������� �����: �����
        /// </summary>
        [DataMember]
        public string MailingAddressCity { get; set; }

        /// <summary>
        /// �������� �����: ���
        /// </summary>
        [DataMember]
        public int? MailingAddressHouse { get; set; }

        /// <summary>
        /// �������� �����: ��������
        /// </summary>
        [DataMember]
        public int? MailingAddressApartment { get; set; }

        /// <summary>
        /// �������� �����: ��������
        /// </summary>
        [DataMember]
        public string MailingAddressBuilding { get; set; }

        /// <summary>
        /// �������� �����: ���������� �����
        /// </summary>
        [DataMember]
        public string MailingAddressLocality { get; set; }

        /// <summary>
        /// �������� �����: �����
        /// </summary>
        [DataMember]
        public string MailingAddressDistrict { get; set; }

        /// <summary>
        /// �������� �����: �����
        /// </summary>
        [DataMember]
        public string MailingAddressStreet { get; set; }

        #endregion �������� �����
    }
}
