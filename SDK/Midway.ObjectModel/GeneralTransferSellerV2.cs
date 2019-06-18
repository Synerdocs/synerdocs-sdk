using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// УПД (СФ, СФ + ДОП (титул продавца/исполнителя), ДОП (титул продавца/исполнителя)).
    /// Формат УПД, утвержденный ММВ-7-15/820.
    /// </summary>
    [DataContract]
    public class GeneralTransferSellerV2
    {
        /// <summary>
        /// Идентификатор файла - имя сформированного файла (без расширения).
        /// </summary>
        [DataMember(IsRequired = false)]
        public string FileId { get; set; }

        /// <summary>
        /// Информация о факторе.
        /// </summary>
        [DataMember(IsRequired = false)]
        public Factor Factor { get; set; }

        /// <summary>
        /// Сведения об участниках электронного документооборота.
        /// </summary>
        [DataMember(IsRequired = false)]
        public ParticipantsServiceInfo ServiceInfo { get; set; }

        /// <summary>
        /// Дата и время формирования документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Порядковый номер и дата счета-фактуры (строка 1 счета-фактуры), документа об отгрузке товаров 
        /// (выполнении работ), передаче имущественных прав (документа об оказании услуг),
        /// а также Наименование первичного документа, определенное организацией
        /// Номер для Функция = ДОП может принимать значение б/н (без номера).
        /// </summary>
        [DataMember(IsRequired = true)]
        public DocumentShortInfo ShortInfo { get; set; }

        /// <summary>
        /// Грузоотправители.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Contragent> Consignors { get; set; }

        /// <summary>
        /// Грузополучатели.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Contragent> Consignees { get; set; }

        /// <summary>
        /// Продавцы (поставщики).
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Contragent> Sellers { get; set; }

        /// <summary>
        /// Покупатели.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<Contragent> Buyers { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        [DataMember(IsRequired = true)]
        public CurrencyInfo Currency { get; set; }

        /// <summary>
        /// Согласованная структура дополнительной информации.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string ApprovedAdditionalInfoFieldStructure { get; set; }

        /// <summary>
        /// Платежно-расчетные документы.
        /// </summary>
        [DataMember(IsRequired = false)]
        public List<PaymentBillingDocument> PaymentBillingDocuments { get; set; }

        /// <summary>
        /// Сведения о факте отгрузки товаров (выполнения работ), передачи имущественных прав 
        /// (о предъявлении оказанных услуг).
        /// </summary>
        [DataMember(IsRequired = true)]
        public TransferAreaV2 TransferArea { get; set; }

        /// <summary>
        /// Информационное поле факта хозяйственной жизни 1.
        /// </summary>
        [DataMember(IsRequired = false)]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Составитель документа.
        /// </summary>
        [DataMember(IsRequired = false)]
        public Drafter Drafter { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавшем информацию продавца/исполнителя в электронном виде.
        /// </summary>
        [DataMember(IsRequired = false)]
        public List<Signer> Signers { get; set; }

        /// <summary>
        /// Сведения об отгруженных товарах (о выполненных работах, оказанных услугах), 
        /// переданных имущественных правах.
        /// </summary>
        [DataMember(IsRequired = true)]
        public GeneralTransferAreaV2 GeneralTransferArea { get; set; }

        /// <summary>
        /// Функция документа, соответствует перечислению <see cref="Midway.ObjectModel.ExecutedFunction"/>.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue ExecutedFunction { get; set; }

        /// <summary>
        /// Документы, подтверждающие отгрузку.
        /// </summary>
        [DataMember(IsRequired = false)]
        public List<ShippingDocumentApprovement> ShippingDocumentApprovements { get; set; }

        /// <summary>
        /// Обстоятельства формирования СЧФ, соответствует перечислению
        /// <see cref="Midway.ObjectModel.CircumstancesOfProducing"/>.
        /// </summary>
        [DataMember(IsRequired = false)]
        public EnumValue CircumstancesOfProducing { get; set; }

        /// <summary>
        /// Информация продавца о государственном заказе казначейства.
        /// </summary>
        [DataMember(IsRequired = false)]
        public SellerStateOrderInfo SellerStateOrderInfo { get; set; }

        /// <summary>
        /// Основания уступки денежного требования.
        /// </summary>
        [DataMember(IsRequired = false)]
        public BasisDocument BasisDocument { get; set; }

        /// <summary>
        /// Сведения о факторе.
        /// </summary>
        [DataMember(IsRequired = false)]
        public Contragent GeneralTransferFactor { get; set; }
    }
}
