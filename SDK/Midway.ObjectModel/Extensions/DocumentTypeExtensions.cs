using System;
using System.Collections.Generic;
using System.Linq;

namespace Midway.ObjectModel.Extensions
{
    public static class DocumentTypeExtensions
    {
        /// <summary>
        /// явл€етс€ ли тип документа служебным
        /// </summary>
        /// <param name="documentType"></param>
        public static bool IsService(this DocumentType documentType)
        {
            return documentType != DocumentType.Invoice
                   && documentType != DocumentType.Untyped
                   && documentType != DocumentType.InvoiceCorrection
                   && documentType != DocumentType.InvoiceRevision
                   && documentType != DocumentType.InvoiceCorrectionRevision
                   && documentType != DocumentType.WaybillSeller
                   && documentType != DocumentType.ActOfWorkSeller
                   && documentType != DocumentType.RevocationOffer
                   && documentType != DocumentType.GoodsTransferSeller
                   && documentType != DocumentType.WorksTransferSeller
                   && documentType != DocumentType.GoodsTransferRevisionSeller
                   && documentType != DocumentType.WorksTransferRevisionSeller
                   && documentType != DocumentType.GeneralTransferSeller
                   && documentType != DocumentType.GeneralTransferCorrectionSeller
                   && documentType != DocumentType.GeneralTransferRevisionSeller
                   && documentType != DocumentType.GeneralTransferCorrectionRevisionSeller;
        }

        /// <summary>
        /// явл€етс€ ли тип документа тем или иным видом счета фактуры
        /// </summary>
        /// <param name="documentType"></param>
        public static bool IsInvoice(this DocumentType documentType)
        {
            return documentType == DocumentType.Invoice
                || documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision;
        }

        /// <summary>
        /// явл€етс€ ли тип документа тем или иным видом корректировочного счета фактуры
        /// </summary>
        public static bool IsCorrectionInvoice(this DocumentType documentType)
        {
            return documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceCorrectionRevision;
        }

        /// <summary>
        /// явл€етс€ ли тип документа тем или иным видом исправленного счета фактуры
        /// </summary>
        public static bool IsRevisionInvoice(this DocumentType documentType)
        {
            return documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision;
        }

        /// <summary>
        /// явл€етс€ ли тип документа тем или иным видом корректировочного или исправленного счета фактуры
        /// </summary>
        public static bool IsCorrectionOrRevision(this DocumentType documentType)
        {
            return documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision;
        }

        /// <summary>
        /// явл€етс€ ли документ приложением к другому документу
        /// </summary>
        /// <param name="documentType"></param>
        /// <param name="untypedKind"></param>
        public static bool IsChild(this DocumentType documentType, string untypedKind = null)
        {
            return documentType.IsService()
                || documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision
                || (documentType == DocumentType.Untyped && untypedKind == UntypedKind.ActOfVariance)
                || (documentType == DocumentType.Untyped && untypedKind == UntypedKind.FormalizedData)
                || (documentType == DocumentType.RevocationOffer);
        }

        /// <summary>
        /// ƒолжен ли документ обрабатыватьс€ как "нетипизированный"
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public static bool IsUntyped(this DocumentType documentType)
        {
            return documentType == DocumentType.Untyped
                   || documentType == DocumentType.WaybillSeller
                   || documentType == DocumentType.ActOfWorkSeller
                   || documentType == DocumentType.GoodsTransferSeller
                   || documentType == DocumentType.WorksTransferSeller
                   || documentType == DocumentType.GoodsTransferRevisionSeller
                   || documentType == DocumentType.WorksTransferRevisionSeller;
        }

        /// <summary>
        /// явл€етс€ ли документ формализованным
        /// </summary>
        /// <param name="documentType">“ип документа</param>
        /// <returns>
        /// true - документ формализованный
        /// false - неформализованный или служебный документ
        /// </returns>
        public static bool IsFormalized(this DocumentType documentType)
        {
            return !documentType.IsService() && documentType != DocumentType.Untyped;            
        }

        /// <summary>
        /// явл€етс€ ли документ «а€влением об участии в Ёƒќ счетов-фактур
        /// </summary>
        /// <param name="documentType">“ип документа</param>
        /// <param name="untypedKind">¬ид нетипизированного документа</param>
        /// <returns>
        /// true - €вл€етс€
        /// false - не €вл€етс€
        /// </returns>
        public static bool IsStatementOfInvoiceReglament(this DocumentType documentType, string untypedKind)
        {
            return documentType == DocumentType.Untyped 
                    && untypedKind == UntypedKind.StatementOfInvoiceReglament;
        }

        /// <summary>
        /// явл€етс€ ли документ подписью
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public static bool IsSign(this DocumentType documentType)
        {
            return IsBuyerTitle(documentType);
        }

        /// <summary>
        /// явл€етс€ ли документ тем или иным видом титула покупател€
        /// </summary>
        /// <param name="documentType">“ип документа</param>
        /// <returns><c>true</c>, если документ €вл€етс€ титулом покупател€</returns>
        public static bool IsBuyerTitle(this DocumentType documentType)
        {
            return documentType == DocumentType.WaybillBuyer
                || documentType == DocumentType.ActOfWorkBuyer
                || documentType == DocumentType.GoodsTransferBuyer
                || documentType == DocumentType.WorksTransferBuyer
                || documentType == DocumentType.GeneralTransferBuyer
                || documentType == DocumentType.GeneralTransferCorrectionBuyer;
        }

        public static DocumentType[] NoServiceTypes()
        {
            return Types().Where(t => !IsService(t)).ToArray();
        }

        public static DocumentType[] ServiceTypes()
        {
            return Types().Where(t => t.IsService()).ToArray();
        }

        private static IEnumerable<DocumentType> Types()
        {
            return Enum.GetValues(typeof(DocumentType)).Cast<DocumentType>();
        }

        /// <summary>
        /// ѕроверка: €вл€етс€ ли документ исправлением документа о передаче товара, результатов работ (об оказании услуг), ”ѕƒ, ” ƒ
        /// </summary>
        /// <returns></returns>
        public static bool IsTransferDocumentRevision(this DocumentType documentType)
        {
            return documentType == DocumentType.WorksTransferRevisionSeller
                   || documentType == DocumentType.GoodsTransferRevisionSeller
                   || documentType.IsGeneralTransferRevision();
        }

        /// <summary>
        /// ѕроверка: €вл€етс€ ли документ исправлением ”ѕƒ, ” ƒ
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public static bool IsGeneralTransferRevision(this DocumentType documentType)
        {
            return documentType == DocumentType.GeneralTransferRevisionSeller
                   || documentType == DocumentType.GeneralTransferCorrectionRevisionSeller;
        }

        /// <summary>
        /// ≈сть ли возможность выбора требовани€ ответной подписи
        /// </summary>
        /// <param name="documentType">“ип документа</param>
        /// <returns><c>true</c>, если есть возможность выбора требовани€ ответной подписи</returns>
        public static bool IsNeedSignOptional(this DocumentType documentType)
        {
            return documentType == DocumentType.Untyped
                || documentType == DocumentType.WorksTransferSeller
                || documentType == DocumentType.WorksTransferRevisionSeller
                || documentType == DocumentType.GeneralTransferSeller
                || documentType == DocumentType.GeneralTransferRevisionSeller
                || documentType == DocumentType.GeneralTransferCorrectionSeller
                || documentType == DocumentType.GeneralTransferCorrectionRevisionSeller;
        }

        /// <summary>
        /// явл€етс€ ли документ EDI-документом
        /// </summary>
        /// <param name="documentType">“ип документа</param>
        /// <returns><c>true</c>, если документ €вл€етс€ EDI-документом</returns>
        public static bool IsEdiDocument(this DocumentType documentType)
        {
            return documentType == DocumentType.EdiGeneral
                || documentType == DocumentType.EdiOrders
                || documentType == DocumentType.EdiOrdrsp
                || documentType == DocumentType.EdiDesadv
                || documentType == DocumentType.EdiRecadv;
        }
    }
}