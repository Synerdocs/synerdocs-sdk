﻿namespace Midway.ObjectModel
{
    /// <summary>
    /// Подтипы неформализованных документов
    /// </summary>
    public static class UntypedKind
    {
        public static readonly string Contract = "Договор";
        public static readonly string Letter = "Письмо";
        public static readonly string Agreement = "Дополнительное соглашение к договору";
        public static readonly string PaymentOrder = "Платёжное поручение";
        public static readonly string Act = "Акт о выполнении работ";
        public static readonly string Waybill = "Товарная накладная";
        public static readonly string StatementOfInvoiceReglament = "Заявление об участии в ЭДО счетов-фактур";
        public static readonly string ActOfVariance = "Акт об установленном расхождении";
        public static readonly string Accounts = "Акт сверки";
        public static readonly string TransportWaybill = "Товарно-транспортная накладная";
        public static readonly string Order = "Заказ";
        public static readonly string RevocationOffer = "Предложение об аннулировании";
        public static readonly string FormalizedData = "Структурированные данные";
        public static readonly string SignFailure = "Отказ от подписи";
    }
}
