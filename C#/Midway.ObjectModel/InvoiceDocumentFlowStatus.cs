using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������ ���������������� �����-�������
    /// </summary>
    [DataContract]
    public class InvoiceDocumentFlowStatus : DocumentFlowStatus
    {
        /// <summary>
        /// ������ ���������������� ��������
        /// </summary>
        [DataMember]
        public InvoiceFlowStatus SellerFlow { get; set; }

        /// <summary>
        /// ������ ���������������� ����������
        /// </summary>
        [DataMember]
        public InvoiceFlowStatus BuyerFlow { get; set; }

        /// <summary>
        /// ����� ���������
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// ���� ���������
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// ����� � ������
        /// </summary>
        [DataMember]
        public decimal Total { get; set; }

        /// <summary>
        /// ������ ��������� �����-�������
        /// </summary>
        [DataMember]
        public InvoiceModificationStatus ModificationStatus { get; set; }

        /// <summary>
        /// ���� "��������������� ��������"
        /// </summary>
        [DataMember]
        public bool IsFinished { get; set; }

        /// <summary>
        /// ���������� ������ ���������������� � ���� ������
        /// </summary>
        /// <returns>������ ���������� ������ ���������������� �����-�������</returns>
        public override string ToString()
        {
            return string.Format("������ ���������������� ��������: {0}, ������ ���������������� ����������: {1}", SellerFlow, BuyerFlow);
        }
    }
}
