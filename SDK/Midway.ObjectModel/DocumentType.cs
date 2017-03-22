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
        Untyped = 0,

        /// <summary>
        /// Счет-фактура
        /// </summary>
        [EnumMember]
        [Description("Счет-фактура")]
        Invoice = 1,

        /// <summary>
        /// Служебный документ: подтверждение (регламент ЭСФ)
        /// </summary>
        [EnumMember]
        [Description("Служебный: подтверждение (регламент ЭСФ)")]
        ServiceInvoiceConfirmation = 2,

        /// <summary>
        /// Служебный документ: извещение (регламент ЭСФ)
        /// </summary>
        [EnumMember]
        [Description("Служебный: извещение (регламент ЭСФ)")]
        ServiceInvoiceReceipt = 4,

        /// <summary>
        /// Служебный документ: уведомление об уточнении (регламент ЭСФ)
        /// </summary>
        [EnumMember]
        [Description("Служебный: уведомление об уточнении (регламент ЭСФ)")]
        ServiceInvoiceAmendmentRequest = 5,

        /// <summary>
        /// Уведомление об уточнении, отказ от подписи (общий регламент)
        /// </summary>
        [EnumMember]
        [Description("Служебный: уведомление об уточнении, отказ от подписи (общий регламент)")]
        ServiceAmendmentRequest = 6,

        /// <summary>
        /// Комментарий к документу (не используется)
        /// </summary>
        [EnumMember]
        [Description("")]
        Comment = 7,

        /// <summary>
        /// Служебный документ: извещение о получении (общий регламент)
        /// </summary>
        [EnumMember]
        [Description("Служебный: извещение о получении (общий регламент)")]
        ServiceReceipt = 8,

        /// <summary>
        /// Исправленный счет-фактура
        /// </summary>
        [EnumMember]
        [Description("Исправленный счет-фактура")]
        InvoiceRevision = 9,

        /// <summary>
        /// Корректировочный счет-фактура
        /// </summary>
        [EnumMember]
        [Description("Корректировочный счет-фактура")]
        InvoiceCorrection = 10,

        /// <summary>
        /// Исправленный корректировочный счет-фактура
        /// </summary>
        [EnumMember]
        [Description("Исправленный корректировочный счет-фактура")]
        InvoiceCorrectionRevision = 11,

        /// <summary>
        /// Товарная накладная (титул продавца)
        /// </summary>
        [EnumMember]
        [Description("Товарная накладная")]
        WaybillSeller = 12,

        /// <summary>
        /// Товарная накладная (титул покупателя)
        /// </summary>
        [EnumMember]
        [Description("Служебный: товарная накладная (титул покупателя)")]
        WaybillBuyer = 13,

        /// <summary>
        /// Акт о выполнении работ (титул исполнителя)
        /// </summary>
        [EnumMember]
        [Description("Акт о выполнении работ")]
        ActOfWorkSeller = 14,

        /// <summary>
        /// Акт о выполнении работ (титул заказчика)
        /// </summary>
        [EnumMember]
        [Description("Служебный: акт о выполнении работ (титул заказчика)")]
        ActOfWorkBuyer = 15,

        /// <summary>
        /// Служебный документ: квитанция об ошибке
        /// </summary>
        [EnumMember]
        [Description("Служебный: квитанция об ошибке")]
        ErrorReceipt = 16,

        /// <summary>
        /// Предложение об аннулировании
        /// </summary>
        [EnumMember]
        [Description("Соглашение об аннулировании")]
        RevocationOffer = 17,

        /// <summary>
        /// Документ о передаче результатов работ (титул исполнителя)
        /// </summary>
        [EnumMember]
        [Description("Документ о передаче результатов работ")]
        WorksTransferSeller = 18,

        /// <summary>
        /// Служебный: документ передачи результатов работ (титул заказчика)
        /// </summary>
        [EnumMember]
        [Description("Служебный: документ передачи результатов работ (титул заказчика)")]
        WorksTransferBuyer = 19,

        /// <summary>
        /// Документ о передаче товаров (титул продавца)
        /// </summary>
        [EnumMember]
        [Description("Документ о передаче товаров")]
        GoodsTransferSeller = 20,

        /// <summary>
        /// Служебный: документ о передаче товаров (титул покупателя)
        /// </summary>
        [EnumMember]
        [Description("Служебный: документ о передаче товаров (титул покупателя)")]
        GoodsTransferBuyer = 21,

        /// <summary>
        /// Исправленный документ о передаче результатов работ (титул исполнителя)
        /// </summary>
        [EnumMember]
        [Description("Исправленный документ о передаче результатов работ")]
        WorksTransferRevisionSeller = 22,

        /// <summary>
        /// Исправленный документ о передаче товаров (титул продавца)
        /// </summary>
        [EnumMember]
        [Description("Исправленный документ о передаче товаров")]
        GoodsTransferRevisionSeller = 23,

        /// <summary>
        /// Универсальный передаточный документ (титул продавца)
        /// </summary>
        [EnumMember]
        [Description("Универсальный передаточный документ")]
        GeneralTransferSeller = 24,

        /// <summary>
        /// Служебный: универсальный передаточный документ (титул покупателя)
        /// </summary>
        [EnumMember]
        [Description("Служебный: универсальный передаточный документ (титул покупателя)")]
        GeneralTransferBuyer = 25,

        /// <summary>
        /// Исправленный универсальный передаточный документ (титул продавца)
        /// </summary>
        [EnumMember]
        [Description("Исправленный универсальный передаточный документ")]
        GeneralTransferRevisionSeller = 26,

        /// <summary>
        /// Универсальный корректировочный документ (титул продавца)
        /// </summary>
        [EnumMember]
        [Description("Универсальный корректировочный документ")]
        GeneralTransferCorrectionSeller = 27,

        /// <summary>
        /// Служебный: универсальный корректировочный документ (титул покупателя)
        /// </summary>
        [EnumMember]
        [Description("Служебный: универсальный корректировочный документ (титул покупателя)")]
        GeneralTransferCorrectionBuyer = 28,

        /// <summary>
        /// Исправленный универсальный корректировочный документ (титул продавца)
        /// </summary>
        [EnumMember]
        [Description("Исправленный универсальный корректировочный документ")]
        GeneralTransferCorrectionRevisionSeller = 29,

        /// <summary>
        /// Канонический EDI документ
        /// Используется только при конвертации документов
        /// </summary>
        [EnumMember]
        [Description("Канонический EDI документ")]
        EdiGeneral = 1000,

        /// <summary>
        /// EDI документ ORDERS
        /// Используется только при конвертации документов
        /// </summary>
        [EnumMember]
        [Description("EDI документ ORDERS")]
        EdiOrders = 1001,

        /// <summary>
        /// EDI документ ORDRSP
        /// Используется только при конвертации документов
        /// </summary>
        [EnumMember]
        [Description("EDI документ ORDRSP")]
        EdiOrdrsp = 1002,

        /// <summary>
        /// EDI документ DESADV
        /// Используется только при конвертации документов
        /// </summary>
        [EnumMember]
        [Description("EDI документ DESADV")]
        EdiDesadv = 1003,

        /// <summary>
        /// EDI документ RECADV
        /// Используется только при конвертации документов
        /// </summary>
        [EnumMember]
        [Description("EDI документ RECADV")]
        EdiRecadv = 1004,
    }
}
