using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация для сведений о денежном обязательстве.
    /// </summary>
    [DataContract]
    public class MonetaryObligation
    {
        /// <summary>
        /// Номер строки таблицы информации продавца.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int RowNumber { get; set; }

        /// <summary>
        /// Код объекта капитального строительства федеральной адресной инвестиционной программы
        /// или код мероприятия по информации.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string FaipObjectCode { get; set; }

        /// <summary>
        /// Вид средств, соответствует перечислению <see cref="Midway.ObjectModel.FundsType"/>.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue FundsType { get; set; }

        /// <summary>
        /// Код по бюджетной классификации (покупателя).
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BuyerBudgetCode { get; set; }

        /// <summary>
        /// Код цели покупки.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string PurchasePurposeCode { get; set; }

        /// <summary>
        /// Сумма перечисленного аванса.
        /// </summary>
        [DataMember(IsRequired = true)]
        public decimal Prepayment { get; set; }
    }
}
