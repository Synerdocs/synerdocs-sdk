using System;
using System.Collections.Generic;
using System.Linq;

namespace Midway.ObjectModel.Extensions
{
    public static class DocumentTypeExtensions
    {
        /// <summary>
        /// Является ли тип документа служебным.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если документ является служебным; иначе - <c>false</c>.</returns>
        public static bool IsService(this DocumentType documentType)
            => !(documentType == DocumentType.Untyped
                || documentType == DocumentType.RevocationOffer
                || documentType.IsInvoice()
                || documentType.IsRootTitle()
                || documentType.IsEdiDocument());

        /// <summary>
        /// Является ли тип документа тем или иным видом счета фактуры
        /// </summary>
        /// <param name="documentType"></param>
        public static bool IsInvoice(this DocumentType documentType)
            => documentType == DocumentType.Invoice
                || documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision;

        /// <summary>
        /// Является ли тип документа тем или иным видом корректировочного счета фактуры
        /// </summary>
        public static bool IsCorrectionInvoice(this DocumentType documentType)
            => documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceCorrectionRevision;

        /// <summary>
        /// Является ли тип документа тем или иным видом исправленного счета фактуры
        /// </summary>
        public static bool IsRevisionInvoice(this DocumentType documentType)
            => documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision;

        /// <summary>
        /// Является ли тип документа тем или иным видом корректировочного или исправленного счета фактуры
        /// </summary>
        public static bool IsCorrectionOrRevision(this DocumentType documentType)
            => documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision;

        /// <summary>
        /// Является ли документ приложением к другому документу
        /// </summary>
        /// <param name="documentType"></param>
        /// <param name="untypedKind"></param>
        public static bool IsChild(this DocumentType documentType, string untypedKind = null)
            => documentType.IsService()
                || documentType.IsCorrectionOrRevision()
                || (documentType == DocumentType.Untyped && untypedKind == UntypedKind.ActOfVariance)
                || (documentType == DocumentType.Untyped && untypedKind == UntypedKind.FormalizedData)
                || (documentType == DocumentType.RevocationOffer);

        /// <summary>
        /// Должен ли документ обрабатываться как "нетипизированный"
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public static bool IsUntyped(this DocumentType documentType)
            => documentType == DocumentType.Untyped
                || documentType == DocumentType.WaybillSeller
                || documentType == DocumentType.ActOfWorkSeller
                || documentType.IsWorksTransferSeller()
                || documentType.IsGoodsTransferSeller();

        /// <summary>
        /// Является ли документ формализованным
        /// </summary>
        /// <param name="documentType">Тип документа</param>
        /// <returns>
        /// true - документ формализованный
        /// false - неформализованный или служебный документ
        /// </returns>
        public static bool IsFormalized(this DocumentType documentType)
            => !documentType.IsService() && documentType != DocumentType.Untyped;

        /// <summary>
        /// Является ли документ Заявлением об участии в ЭДО счетов-фактур
        /// </summary>
        /// <param name="documentType">Тип документа</param>
        /// <param name="untypedKind">Вид нетипизированного документа</param>
        /// <returns>
        /// true - является
        /// false - не является
        /// </returns>
        public static bool IsStatementOfInvoiceReglament(this DocumentType documentType, string untypedKind)
            => documentType == DocumentType.Untyped 
                && untypedKind == UntypedKind.StatementOfInvoiceReglament;

        /// <summary>
        /// Проверить, является ли документ подписью.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если документ является подписью; иначе - <c>false</c>.</returns>
        public static bool IsSign(this DocumentType documentType)
            => IsReplyTitle(documentType);

        /// <summary>
        /// Является ли документ тем или иным видом титула продавца.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если документ является титулом продавца; иначе - <c>false</c>.</returns>
        public static bool IsSellerTitle(this DocumentType documentType)
            => documentType.IsGeneralTransferSeller()
                || documentType.IsGoodsTransferSeller()
                || documentType.IsWorksTransferSeller()
                || documentType == DocumentType.WaybillSeller
                || documentType == DocumentType.ActOfWorkSeller;

        /// <summary>
        /// Является ли документ тем или иным видом титула покупателя
        /// </summary>
        /// <param name="documentType">Тип документа</param>
        /// <returns><c>true</c>, если документ является титулом покупателя</returns>
        public static bool IsBuyerTitle(this DocumentType documentType)
            => documentType.IsGeneralTransferBuyer()
                || documentType == DocumentType.GoodsTransferBuyer
                || documentType == DocumentType.WorksTransferBuyer
                || documentType == DocumentType.WaybillBuyer
                || documentType == DocumentType.ActOfWorkBuyer;

        public static DocumentType[] NoServiceTypes()
            => Types().Where(t => !IsService(t)).ToArray();

        public static DocumentType[] ServiceTypes()
            => Types().Where(t => t.IsService()).ToArray();

        private static IEnumerable<DocumentType> Types()
            => Enum.GetValues(typeof(DocumentType)).Cast<DocumentType>();

        /// <summary>
        /// Является ли документ УПД или УКД.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если документ является УПД или УКД; иначе <c>false</c>.</returns>
        public static bool IsGeneralTransfer(this DocumentType documentType)
            => documentType.IsGeneralTransferSeller()
                || documentType.IsGeneralTransferBuyer();

        /// <summary>
        /// Проверка: является ли документ исправлением документа о передаче товара,
        /// результатов работ (об оказании услуг), УПД, УКД.
        /// </summary>
        /// <returns></returns>
        public static bool IsTransferDocumentRevision(this DocumentType documentType)
            => documentType.IsGeneralTransferRevision()
                || documentType == DocumentType.WorksTransferRevisionSeller
                || documentType == DocumentType.GoodsTransferRevisionSeller;

        /// <summary>
        /// Проверка: является ли документ исправлением УПД, УКД
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public static bool IsGeneralTransferRevision(this DocumentType documentType)
            => documentType == DocumentType.GeneralTransferRevisionSeller
                || documentType == DocumentType.GeneralTransferCorrectionRevisionSeller;

        /// <summary>
        /// Есть ли возможность выбора требования ответной подписи.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если есть возможность выбора требования ответной подписи.</returns>
        public static bool IsNeedSignOptional(this DocumentType documentType)
            => documentType == DocumentType.Untyped
                || documentType.IsWorksTransferSeller()
                || documentType.IsGeneralTransferSeller();

        /// <summary>
        /// Является ли документ EDI-документом
        /// </summary>
        /// <param name="documentType">Тип документа</param>
        /// <returns><c>true</c>, если документ является EDI-документом</returns>
        public static bool IsEdiDocument(this DocumentType documentType)
            => documentType == DocumentType.EdiGeneral
                || documentType == DocumentType.EdiOrders
                || documentType == DocumentType.EdiOrdrsp
                || documentType == DocumentType.EdiDesadv
                || documentType == DocumentType.EdiRecadv;

        /// <summary>
        /// Определить, относится ли тип документа к служебным документам для СФ/УПД.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns>
        /// <c>true</c>, если тип документа относится к служебным документам для СФ/УПД; иначе - <c>false</c>.
        /// </returns>
        public static bool IsInvoiceServiceDocument(this DocumentType documentType)
            => documentType == DocumentType.ServiceInvoiceConfirmation
                || documentType == DocumentType.ServiceInvoiceReceipt
                || documentType == DocumentType.ServiceInvoiceAmendmentRequest;

        /// <summary>
        /// Определить, относится ли тип документа к регламенту СФ/УПД.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns>
        /// <c>true</c>, если тип документа относится к регламенту СФ/УПД; иначе - <c>false</c>.
        /// </returns>
        public static bool IsInvoiceRegulationDocument(this DocumentType documentType)
            => documentType.IsInvoice()
                || documentType.IsGeneralTransfer()
                || documentType.IsInvoiceServiceDocument();

        /// <summary>
        /// Является ли документ титулом продавца документа о передаче товара.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если документ является титулом продавца; иначе - <c>false</c>.</returns>
        public static bool IsGoodsTransferSeller(this DocumentType documentType)
            => documentType == DocumentType.GoodsTransferSeller
                || documentType == DocumentType.GoodsTransferRevisionSeller;

        /// <summary>
        /// Является ли документ титулом исполнителя документа о передаче результатов работ (об оказании услуг).
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если документ является титулом исполнителя; иначе - <c>false</c>.</returns>
        public static bool IsWorksTransferSeller(this DocumentType documentType)
            => documentType == DocumentType.WorksTransferSeller
                || documentType == DocumentType.WorksTransferRevisionSeller;

        /// <summary>
        /// Является ли документ титулом продавца универсального передаточного документа.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если документ является титулом продавца; иначе - <c>false</c>.</returns>
        public static bool IsGeneralTransferSeller(this DocumentType documentType)
            => documentType == DocumentType.GeneralTransferSeller
                || documentType == DocumentType.GeneralTransferRevisionSeller
                || documentType == DocumentType.GeneralTransferCorrectionSeller
                || documentType == DocumentType.GeneralTransferCorrectionRevisionSeller;

        /// <summary>
        /// Является ли документ титулом покупателя универсального передаточного документа.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns><c>true</c>, если документ является титулом покупателя; иначе - <c>false</c>.</returns>
        public static bool IsGeneralTransferBuyer(this DocumentType documentType)
            => documentType == DocumentType.GeneralTransferBuyer
                || documentType == DocumentType.GeneralTransferCorrectionBuyer;

        /// <summary>
        /// Проверить, является ли документ титулом грузоотправителя транспортной накладной.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns>
        /// <c>true</c>, если документ является титулом грузоотправителя транспортной накладной; иначе - <c>false</c>.
        /// </returns>
        public static bool IsTransportWaybillConsignorTitle(this DocumentType documentType)
            => documentType == DocumentType.TransportWaybillConsignorTitle;

        /// <summary>
        /// Проверить, является ли документ ответным титулом транспортной накладной.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns>
        /// <c>true</c>, если документ является ответным титулом транспортной накладной; иначе - <c>false</c>.
        /// </returns>
        public static bool IsTransportWaybillReplyTitle(this DocumentType documentType)
            => documentType == DocumentType.TransportWaybillCargoReceivedTitle
                || documentType == DocumentType.TransportWaybillCargoDeliveredTitle
                || documentType == DocumentType.TransportWaybillConsigneeTitle
                || documentType == DocumentType.TransportWaybillCarrierTitle;

        /// <summary>
        /// Проверить, является ли документ тем или иным корневым титулом.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns>
        /// <c>true</c>, если документ является тем или иным корневым титулом; иначе - <c>false</c>.
        /// </returns>
        public static bool IsRootTitle(this DocumentType documentType)
            => documentType.IsSellerTitle()
                || documentType.IsTransportWaybillConsignorTitle();

        /// <summary>
        /// Проверить, является ли документ тем или иным ответным титулом.
        /// </summary>
        /// <param name="documentType">Тип документа.</param>
        /// <returns>
        /// <c>true</c>, если документ является тем или иным ответным титулом; иначе - <c>false</c>.
        /// </returns>
        public static bool IsReplyTitle(this DocumentType documentType)
            => documentType.IsBuyerTitle()
                || documentType.IsTransportWaybillReplyTitle();
    }
}