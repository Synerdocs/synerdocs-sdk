using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � �����-�������
    /// </summary>
    [DataContract]
    public class InvoiceInfo
    {
        /// <summary>
        /// �������� �����-������� � ������� "����-������� �... �� __.__.____ �."
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// ����� �����-�������
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// ���� �����-�������
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// ����� ����������� �����-�������
        /// </summary>
        [DataMember]
        public string ChangesNumber { get; set; }

        /// <summary>
        /// ���� ����������� �����-�������
        /// </summary>
        [DataMember]
        public DateTime? ChangesDate { get; set; }

        /// <summary>
        /// ����� ������������� �����-�������
        /// </summary>
        [DataMember]
        public string CorrectionNumber { get; set; }

        /// <summary>
        /// ���� ������������� �����-�������
        /// </summary>
        [DataMember]
        public DateTime? CorrectionDate { get; set; }

        /// <summary>
        /// ����� ����������� ������������� �����-�������
        /// </summary>
        [DataMember]
        public string ChangeCorrectionNumber { get; set; }

        /// <summary>
        /// ���� ����������� ������������� �����-�������
        /// </summary>
        [DataMember]
        public DateTime? ChangeCorrectionDate { get; set; }

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
