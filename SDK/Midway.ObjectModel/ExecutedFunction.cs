using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип функции, которую выполняет документ.
    /// </summary>
    [DataContract]
    public enum ExecutedFunction
    {
        /// <summary>
        /// СЧФ - счет-фактура, применяемый при расчетах по налогу на добавленную стоимость.
        /// </summary>
        [Description("СЧФ")]
        [EnumMember]
        Invoice = 0,

        /// <summary>
        /// СЧФДОП - счет-фактура, применяемый при расчетах по налогу на добавленную стоимость, и документ об отгрузке товаров (выполнении работ), передаче имущественных прав (документ об оказании услуг).
        /// </summary>
        [Description("СЧФДОП")]
        [EnumMember]
        InvoiceAndTransfer = 1,

        /// <summary>
        /// ДОП - документ об отгрузке товаров (выполнении работ), передаче имущественных прав (документ об оказании услуг).
        /// </summary>
        [Description("ДОП")]
        [EnumMember]
        Transfer = 2,

        /// <summary>
        /// КСЧФ - корректировочный счет-фактура, применяемый при расчетах по налогу на добавленную стоимость.
        /// </summary>
        [Description("КСЧФ")]
        [EnumMember]
        InvoiceCorrection = 3,

        /// <summary>
        /// КСЧФДИС - корректировочный счет-фактура, применяемый при расчетах по налогу на добавленную стоимость, и документ об изменении стоимости отгруженных товаров (выполненных работ, оказанных услуг), переданных имущественных прав.
        /// </summary>
        [Description("КСЧФДИС")]
        [EnumMember]
        InvoiceAndTransferCorrection = 4,

        /// <summary>
        /// ДИС - документ об изменении стоимости отгруженных товаров (выполненных работ, оказанных услуг), переданных имущественных прав.
        /// </summary>
        [Description("ДИС")]
        [EnumMember]
        TransferCorrection = 5
    }
}
