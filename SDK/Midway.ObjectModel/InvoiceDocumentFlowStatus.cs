using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус документооборота счета-фактуры
    /// </summary>
    [DataContract]
    public class InvoiceDocumentFlowStatus : DocumentFlowStatus
    {
        /// <summary>
        /// Статус документооборота продавца
        /// </summary>
        [DataMember]
        public InvoiceFlowStatus SellerFlow { get; set; }

        /// <summary>
        /// Статус документооборота покупателя
        /// </summary>
        [DataMember]
        public InvoiceFlowStatus BuyerFlow { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Дата документа
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Всего к оплате
        /// </summary>
        [DataMember]
        public decimal Total { get; set; }

        /// <summary>
        /// Статус изменений счета-фактуры
        /// </summary>
        [DataMember]
        public InvoiceModificationStatus ModificationStatus { get; set; }

        /// <summary>
        /// Флаг "документооборот завершен"
        /// </summary>
        [DataMember]
        public bool IsFinished { get; set; }

        /// <summary>
        /// Возвращает статут документооборота в виде строки
        /// </summary>
        /// <returns>Строка содержащая статус документооборота счета-фактуры</returns>
        public override string ToString()
        {
            return string.Format("Статус документооборота продавца: {0}, статус документооборота покупателя: {1}", SellerFlow, BuyerFlow);
        }
    }
}
