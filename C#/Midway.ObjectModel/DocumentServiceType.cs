namespace Midway.ObjectModel
{
    /// TODO@internal (������� � Midway.DAL)
    /// <summary>
    /// ��� ���������� ���������
    /// </summary>
    public enum DocumentServiceType
    {
        /// <summary>
        /// ���������������
        /// </summary>
        NoType = 0x0,

        #region ��������� ��������� �� ������-��������

        /// <summary>
        /// ������������� �������� ��������� �����-������� ����������
        /// </summary>
        SenderInvoiceConfirmationType = 0x01,

        /// <summary>
        /// ������������� ���������� �������� �����-������� �� ������� ����������
        /// </summary>
        BuyerInvoiceConfirmationType = 0x02,

        /// <summary>
        /// ������������� ���������� � ��������� ��������� �� ����������
        /// </summary>
        BuyerInvoiceNoticeConfirmationType = 0x03,

        /// <summary>
        /// ��������� �� ������
        /// </summary>
        ErrorReceipt = 0x03

        #endregion ��������� ��������� �� ������-��������
    }
}
