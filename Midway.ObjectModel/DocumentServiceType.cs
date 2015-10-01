namespace Midway.ObjectModel
{
    /// TODO@internal (вернуть в Midway.DAL)
    /// <summary>
    /// Тип служебного документа
    /// </summary>
    public enum DocumentServiceType
    {
        /// <summary>
        /// зарезервировано
        /// </summary>
        NoType = 0x0,

        #region служебные документы по счетам-фактурам

        /// <summary>
        /// подтверждение продавцу получения счета-фактуры оператором
        /// </summary>
        SenderInvoiceConfirmationType = 0x01,

        /// <summary>
        /// подтверждение покупателю передачи счета-фактуры от сервиса покупателю
        /// </summary>
        BuyerInvoiceConfirmationType = 0x02,

        /// <summary>
        /// подтверждение покупателю о получении извещения от покупателя
        /// </summary>
        BuyerInvoiceNoticeConfirmationType = 0x03,

        /// <summary>
        /// Квитанция об ошибке
        /// </summary>
        ErrorReceipt = 0x03

        #endregion служебные документы по счетам-фактурам
    }
}
