using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � ����������
    /// </summary>
    [DataContract]
    public class SignerInfo
    {
        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public SignerInfo()
        {
            OrganizationType = OrganizationType.Unknown;
#pragma warning disable 618 //�������� �������������� ������ ���������� ����� (obsolete)
            IsJuridical = false;
#pragma warning restore 618
            Inn = "�� �������";
            StateRegistrationCert = "�� �������";
            Position = "�� �������";
            FirstName = "�� �������";
            LastName = "�� �������";
            MiddleName = "�� �������";
        }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// �������, �����������, ��� ��������� ����������� ����
        /// </summary>
        [DataMember]
        [Obsolete("��� ����������� �������� �������������")]
        public bool IsJuridical { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// ��������� ����������
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// ������������� ��������������� ����������� ��
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }

        /// <summary>
        /// ������� ����������
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// ��� ����������
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// �������� ����������
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }
    }
}
