using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class RegisterModel
    {
        /// <summary>
        /// �����������
        /// </summary>
        public RegisterModel()
        {
            Certificate = new Certificate();
            OrganizationType = OrganizationType.LegalEntity;
        }

        #region ���������� � ������������

        /// <summary>
        /// �����
        /// </summary>
        [DataMember]
        [DisplayName("������� �����")]
        public string Login { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [DataMember]
        [DisplayName("������� ������")]
        public string Password { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [DataMember]
        [DisplayName("������� ���")]
        public string FirstName { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [DataMember]
        [DisplayName("������� �������")]
        public string LastName { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        [DisplayName("������� ��������")]
        public string MiddleName { get; set; }

        /// <summary>
        /// ����������� �����
        /// </summary>
        [DataMember]
        [DisplayName("������� email")]
        public string Email { get; set; }

        #endregion ���������� � ������������

        #region ���������� �� �����������

        /// <summary>
        /// ������������� �����������
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// ������������ �����������
        /// </summary>
        [DataMember]
        [DisplayName("������� �������� �����������")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        [DisplayName("������� ���")]
        public string Inn { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        [DisplayName("������� ���")]
        public string Kpp { get; set; }

        /// <summary>
        /// ���� ����������� ��� ��
        /// </summary>
        [DataMember]
        [DisplayName("������� ����")]
        public string Ogrn { get; set; }

        /// <summary>
        /// ������ ��������� ���
        /// </summary>
        [DataMember]
        [DisplayName("�� ���������� ��������� �� ������ www.synerdocs.ru ������� Synerdocs?")]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        [DataMember]
        public Certificate Certificate { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// ��� ��������� ���
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }

        /// <summary>
        /// ��� ����������� � ������ ������� ���, ������������ ��� ����������� ���
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }

        #endregion ���������� �� �����������
    }
}