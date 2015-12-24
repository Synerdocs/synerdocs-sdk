using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � �������� ������������ ����������������
    /// </summary>
    [DataContract]
    public class SubjectInfo
    {
        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// �������, ����������� ��� ������� - ����������� ����
        /// </summary>
        [DataMember]
        [Obsolete("��� ����������� �������� �������������")]
        public bool IsJuridical { get; set; }

        /// <summary>
        /// �������, ����������� ��� ������� - ������������ ���
        /// </summary>
        [DataMember]
        public bool IsOperator { get; set; }

        /// <summary>
        /// ��������� ��� ��������� ���
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }

        /// <summary>
        /// ��������� ��� ��������� ���
        /// </summary>
        [DataMember]
        public string OperatorServiceCode { get; set; }

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
        /// ������������ �����������
        /// </summary>
        [DataMember]
        public string Name { get; set; }

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
    }
}
