using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � ���������
    /// </summary>
    [DataContract]
    public class DocumentInfo
    {
        /// <summary>
        /// ����� ���������
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// ���� �����������, ��������� � ���������
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// ���� ��������
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }
        
        /// <summary>
        /// ������������� �����
        /// </summary>
        [DataMember]
        public string IdFile { get; set; }

        /// <summary>
        /// ����� ��� ���
        /// </summary>
        [DataMember]
        public decimal? CoastSum { get; set; }

        /// <summary>
        /// ����� ���
        /// </summary>
        [DataMember]
        public decimal? SumNds { get; set; }
    }
}
