using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � �����������
    /// </summary>
    [DataContract]
    public class Contact
    {
        /// <summary>
        /// �� �����������
        /// </summary>
        [DataMember]
        public int ContragentId { get; set; }

        /// <summary>
        /// ������������ �����������
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
        /// �����������
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// ���� ���������� ��������� ��������
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// ������ �����������
        /// </summary>
        [DataMember]
        public ContactStatus ContactStatus { get; set; }

        /// <summary>
        /// ��� ��������� ���
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }
    }
}
