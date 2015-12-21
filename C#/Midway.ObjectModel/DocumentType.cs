using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип документа
    /// </summary>
    [DataContract]
    public enum DocumentType
    {
        /// <summary>
        /// Неформализованный документ
        /// </summary>
        [EnumMember]
        [Description("Неформализованный")]
        Untyped = 0x0,

        /// <summary>
        /// Счет-фактура
        /// </summary>
        [EnumMember]
        [Description("Счет-фактура")]
        Invoice = 0x1,

        /// <summary>
        /// Служебный документ: подтверждение (регламент ЭСФ)
        /// </summary>
        [EnumMember]
        [Description("Служебный: подтверждение (регламент ЭСФ)")]
        ServiceInvoiceConfirmation = 0x2,

        /// <summary>
        /// Служебный документ: извещение (регламент ЭСФ)
        /// </summary>
        [EnumMember]
        [Description("Служебный: извещение (регламент ЭСФ)")]
        ServiceInvoiceReceipt = 0x4,

        /// <summary>
        /// Служебный документ: уведомление об уточнении (регламент ЭСФ)
        /// </summary>
        [EnumMember]
        [Description("Служебный: уведомление об уточнении (регламент ЭСФ)")]
        ServiceInvoiceAmendmentRequest = 0x5,

        /// <summary>
        /// Уведомление об уточнении, отказ от подписи (общий регламент)
        /// </summary>
        [EnumMember]
        [Description("Служебный: уведомление об уточнении, отказ от подписи (общий регламент)")]
        ServiceAmendmentRequest = 0x6,

        /// <summary>
        /// Комментарий к документу (не используется)
        /// </summary>
        [EnumMember]
        [Description("")]
        Comment = 0x7,

        /// <summary>
        /// Служебный документ: извещение о получении (общий регламент)
        /// </summary>
        [EnumMember]
        [Description("Служебный: извещение о получении (общий регламент)")]
        ServiceReceipt = 0x8,

        /// <summary>
        /// Измененный счет-фактура
        /// </summary>
        [EnumMember]
        [Description("Измененный счет-фактура")]
        InvoiceRevision = 0x09,

        /// <summary>
        /// Корректировочный счет-фактура
        /// </summary>
        [EnumMember]
        [Description("Корректировочный счет-фактура")]
        InvoiceCorrection = 0x0A,

        /// <summary>
        /// Измененный корректировочный счет-фактура
        /// </summary>
        [EnumMember]
        [Description("Измененный корректировочный счет-фактура")]
        InvoiceCorrectionRevision = 0x0B,

        /// <summary>
        /// Товарная накладная (титул продавца)
        /// </summary>
        [EnumMember]
        [Description("Товарная накладная")]
        WaybillSeller = 0x0C,

        /// <summary>
        /// Товарная накладная (титул покупателя)
        /// </summary>
        [EnumMember]
        [Description("Служебный: товарная накладная (титул покупателя)")]
        WaybillBuyer = 0x0D,

        /// <summary>
        /// Акт о выполнении работ (титул исполнителя)
        /// </summary>
        [EnumMember]
        [Description("Акт о выполнении работ")]
        ActOfWorkSeller = 0x0E,

        /// <summary>
        /// Акт о выполнении работ (титул заказчика)
        /// </summary>
        [EnumMember]
        [Description("Служебный: акт о выполнении работ (титул заказчика)")]
        ActOfWorkBuyer = 0x0F,

        /// <summary>
        /// Служебный документ: квитанция об ошибке
        /// </summary>
        [EnumMember]
        [Description("Служебный: квитанция об ошибке")]
        ErrorReceipt = 0x10
    }
}
