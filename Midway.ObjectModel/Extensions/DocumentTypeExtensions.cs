using System;
using System.Collections.Generic;
using System.Linq;

namespace Midway.ObjectModel.Extensions
{
    public static class DocumentTypeExtensions
    {
        /// <summary>
        /// Является ли тип документа служебным
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
                   && documentType != DocumentType.ActOfWorkSeller;
        }

        /// <summary>
        /// Является ли тип документа тем или иным видом счета фактуры
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
        /// Является ли тип документа тем или иным видом корректировочного счета фактуры
        /// </summary>
        public static bool IsCorrectionInvoice(this DocumentType documentType)
        {
            return documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceCorrectionRevision;
        }

        /// <summary>
        /// Является ли тип документа тем или иным видом исправленного счета фактуры
        /// </summary>
        public static bool IsRevisionInvoice(this DocumentType documentType)
        {
            return documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision;
        }

        /// <summary>
        /// Является ли тип документа тем или иным видом корректировочного или исправленного счета фактуры
        /// </summary>
        public static bool IsCorrectionOrRevision(this DocumentType documentType)
        {
            return documentType == DocumentType.InvoiceCorrection
                || documentType == DocumentType.InvoiceRevision
                || documentType == DocumentType.InvoiceCorrectionRevision;
        }

        /// <summary>
        /// Является ли документ приложением к другому документу
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
                || (documentType == DocumentType.Untyped && untypedKind == UntypedKind.FormalizedData);
        }

        /// <summary>
        /// Должен ли документ обрабатываться как "нетипизированный"
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public static bool IsUntyped(this DocumentType documentType)
        {
            return documentType == DocumentType.Untyped
                   || documentType == DocumentType.WaybillSeller
                   || documentType == DocumentType.ActOfWorkSeller;
        }

        /// <summary>
        /// Является ли документ формализованным
        /// </summary>
        /// <param name="documentType">Тип документа</param>
        /// <returns>
        /// true - документ формализованный
        /// false - неформализованный или служебный документ
        /// </returns>
        public static bool IsFormalized(this DocumentType documentType)
        {
            return !documentType.IsService() && documentType != DocumentType.Untyped;            
        }

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
        {
            return documentType == DocumentType.Untyped 
                    && untypedKind == UntypedKind.StatementOfInvoiceReglament;
        }

        /// <summary>
        /// Является ли документ подписью
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public static bool IsSign(this DocumentType documentType)
        {
            return documentType == DocumentType.WaybillBuyer
                   || documentType == DocumentType.ActOfWorkBuyer;
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
    }
}