using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация покупателя о государственном заказе.
    /// </summary>
    [DataContract]
    public class BuyerStateOrderInfo
    {
        /// <summary>
        /// Идентификационный код закупки.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string PurchaseId { get; set; }

        /// <summary>
        /// Номер лицевого счета покупателя.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BusinessAccount { get; set; }

        /// <summary>
        /// Наименование финансового органа покупателя.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FinancialOrganizationName { get; set; }

        /// <summary>
        /// Номер регистровой записи покупателя по Реестру участников бюджетного процесса.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string RegistryNumber { get; set; }

        /// <summary>
        /// Учетный номер бюджетного обязательства покупателя.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string BudgetNumber { get; set; }

        /// <summary>
        /// Код территориального органа Федерального казначейства покупателя.
        /// </summary>
        [DataMember(IsRequired = false)]
        public NameCodeObject TreasureDepartment { get; set; }

        /// <summary>
        /// Код покупателя в Общероссийском классификаторе территорий муниципальных образований.
        /// </summary>
        [DataMember(IsRequired = true)]
        public NameCodeObject OktmoBuyer { get; set; }

        /// <summary>
        /// Код места поставки в Общероссийском классификаторе территорий муниципальных образований.
        /// </summary>
        [DataMember(IsRequired = false)]
        public NameCodeObject OktmoDeliveryPlace { get; set; }

        /// <summary>
        /// Предельная дата оплаты.
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Учетный номер денежного обязательства.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string MonetaryObligationNumber { get; set; }

        /// <summary>
        /// Очередность платежа.
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? PaymentOrder { get; set; }

        /// <summary>
        /// Тип платежа, соответствует перечислению <see cref="Midway.ObjectModel.PaymentType"/>.
        /// </summary>
        [DataMember(IsRequired = false)]
        public EnumValue PaymentType { get; set; }

        /// <summary>
        /// Информация для сведений о денежном обязательстве.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<MonetaryObligation> MonetaryObligations { get; set; }
    }
}
