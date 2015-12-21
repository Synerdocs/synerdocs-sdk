using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� �� ����������� �����. ������������ ��� ��������� ������ ������ ��� ������������
    /// </summary>
    [DataContract]
    public class BoxInfo
    {
        /// <summary>
        /// ����������� ���� �����������
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// TODO: ��������
        /// <summary>
        /// </summary>
        [DataMember]
        [Obsolete("��������, ����������� ���� Address ��� �������� ������������ �����")]
        public string Name { get; set; }

        /// <summary>
        /// �� �����������
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// ��� �����������
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// �������� �����������
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

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
        /// ���� �������� ���������� ���
        /// </summary>
        [DataMember]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// ���� �������� ���������� ��� ������-������
        /// </summary>
        [DataMember]
        public bool InvoiceReglamentAccepted { get; set; }

        /// <summary>
        /// ���� �������� ������������� ���������� ��� �������-���������
        /// </summary>
        [DataMember]
        public bool InvoiceUserReglamentAccepted { get; set; }
    }
}
