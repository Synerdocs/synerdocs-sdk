using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// �����
    /// </summary>
    [DataContract]
    public class Address
    {
        /// TODO@internal
        /// <summary>
        /// ������������� ������
        /// </summary>
        [DataMember]
        public string AddressId { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [DataMember]
        public string House { get; set; }

        /// <summary>
        /// �������� ������
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string Apartment { get; set; }

        /// <summary>
        /// ��� �������
        /// </summary>
        [DataMember]
        public string RegionCode { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string Building { get; set; }

        /// <summary>
        /// ���������� �����
        /// </summary>
        [DataMember]
        public string Locality { get; set; }

        /// <summary>
        /// �����    
        /// </summary>
        [DataMember]
        public string District { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// TODO: �� ������������
        /// <summary>
        /// ���������� ����������� ����
        /// </summary>
        [DataMember]
        public string PostOfficeBox { get; set; }

        /// <summary>
        /// ��� ������
        /// </summary>
        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// ���� "����������� �����"
        /// </summary>
        [DataMember]
        public bool IsForeign { get; set; }

        /// <summary>
        /// ����������� ����� (�����, �����, ��� � �.�.)
        /// </summary>
        [DataMember]
        public string ForeignStreetAddress { get; set; }
    }
}
