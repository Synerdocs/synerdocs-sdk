using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация продавца о государственном заказе.
    /// </summary>
    [DataContract]
    public class SellerStateOrderInfo
    {
        /// <summary>
        /// Идентификатор государственного контракта.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Id { get; set; }

        /// <summary>
        /// Номер и дата госконтракта.
        /// </summary>
        [DataMember(IsRequired = true)]
        public NumberDate NumberDate { get; set; }

        /// <summary>
        /// Лицевой счет.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string BusinessAccount { get; set; }

        /// <summary>
        /// Код по бюджетной классификации.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string BudgetCode { get; set; }

        /// <summary>
        /// Код цели продажи.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string SellPurposeCode { get; set; }

        /// <summary>
        /// Наименование и код территориального органа федерального казначейства.
        /// </summary>
        [DataMember(IsRequired = false)]
        public NameCodeObject TreasureDepartment { get; set; }
    }
}
