using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// �������� ������ �����������
    /// </summary>
    [DataContract]
    public class OrganizationByCriteriaValues
    {
        /// <summary>
        /// �� �����������
        /// </summary>
        [DataMember]
        public string OrganizationId { get; set; }

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
        /// ����� ������������ �����
        /// </summary>
        [DataMember]
        public string BoxAddress { get; set; }

        /// <summary>
        /// ����� ������������
        /// </summary>
        [DataMember]
        public string UserLogin { get; set; }

        /// <summary>
        /// ��� ����������� � ������ ������� ���
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }

        /// <summary>
        /// ��� ��������� ���
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }
    }
}
