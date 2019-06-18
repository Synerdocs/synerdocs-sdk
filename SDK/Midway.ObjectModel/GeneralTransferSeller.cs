using System.Runtime.Serialization;
using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Универсальный передаточный документ (СФ, СФ + ДОП (титул продавца/исполнителя), ДОП (титул продавца/исполнителя)).
    /// </summary>
    [DataContract]
    public class GeneralTransferSeller
    {
        /// <summary>
        /// Идентификатор файла - имя сформированного файла (без расширения).
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// Сведения об участниках электронного документооборота.
        /// </summary>
        [DataMember]
        public ParticipantsServiceInfo ServiceInfo { get; set; }

        /// <summary>
        /// Дата и время формирования документа.
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Порядковый номер и дата счета-фактуры (строка 1 счета-фактуры), документа об отгрузке товаров (выполнении работ), 
        /// передаче имущественных прав (документа об оказании услуг).
        /// А также Наименование первичного документа, определенное организацией.
        /// Номер для Функция=ДОП может принимать значение б/н (без номера).
        /// </summary>
        [DataMember]
        public DocumentShortInfo ShortInfo { get; set; }

        /// <summary>
        /// Грузоотправитель тот же, что и продавец.
        /// </summary>
        [DataMember]
        public bool ConsignorIsSeller { get; set; }

        /// <summary>
        /// Грузоотправитель.
        /// </summary>
        [DataMember]
        public Contragent Consignor { get; set; }

        /// <summary>
        /// Грузополучатель.
        /// </summary>
        [DataMember]
        public Contragent Consignee { get; set; }

        /// <summary>
        /// Продавец (поставщик).
        /// </summary>
        [DataMember]
        public Contragent Seller { get; set; }

        /// <summary>
        /// Покупатель.
        /// </summary>
        [DataMember]
        public Contragent Buyer { get; set; }

        /// <summary>
        /// Идентификатор государственного контракта
        /// </summary>
        [DataMember]
        public string StateContractId { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        [DataMember]
        public CurrencyInfo Currency { get; set; }

        /// <summary>
        /// Платежно-расчетные документы.
        /// </summary>
        [DataMember]
        public NumberDate[] PaymentBillingDocuments { get; set; }

        /// <summary>
        /// Сведения о факте отгрузки  товаров (выполнения  работ), передачи имущественных прав (о предъявлении оказанных услуг).
        /// </summary>
        [DataMember]
        public TransferArea TransferArea { get; set; }

        /// <summary>
        /// Информационное поле факта хозяйственной жизни 1.
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Составитель документа.
        /// </summary>
        [DataMember]
        public Drafter Drafter { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавшем информацию продавца/исполнителя в электронном виде.
        /// </summary>
        [DataMember]
        public Signer[] Signers { get; set; }

        /// <summary>
        /// Функция документа, соответствует перечислению <see cref="Midway.ObjectModel.ExecutedFunction"/>.
        /// </summary>
        [DataMember]
        public EnumValue ExecutedFunction { get; set; }

        /// <summary>
        /// Сведения об отгруженных товарах (о выполненных работах, оказанных услугах), переданных имущественных правах.
        /// </summary>
        [DataMember]
        public GeneralTransferArea GeneralTransferArea { get; set; }

        /// <summary>
        /// Информация о факторе.
        /// </summary>
        [DataMember]
        public Factor Factor { get; set; }
    }
}
