namespace Midway.ObjectModel.Extensions
{
    /// <summary>
    /// Методы расширения для функции, которую выполняет документ.
    /// </summary>
    public static class ExecutedFunctionExtensions
    {
        /// <summary>
        /// Позволяет ли функция документа его подписывать.
        /// </summary>
        /// <param name="documentFunction">Функция документа.</param>
        /// <returns><c>true</c>, если функция документа позволяет его подписывать; иначе - <c>false</c>.</returns>
        public static bool IsSigningAvailable(this ExecutedFunction documentFunction)
            => documentFunction == ExecutedFunction.Transfer
               || documentFunction == ExecutedFunction.TransferCorrection
               || documentFunction == ExecutedFunction.InvoiceAndTransfer
               || documentFunction == ExecutedFunction.InvoiceAndTransferCorrection;
    }
}
