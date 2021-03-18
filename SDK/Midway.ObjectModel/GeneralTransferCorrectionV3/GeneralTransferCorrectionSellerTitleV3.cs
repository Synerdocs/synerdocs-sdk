using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Универсальный корректировочный документ (КСФ, КСФ + ДИС (титул продавца/исполнителя),
    /// ДИС (титул продавца/исполнителя)) версии 3 по приказу ММВ-7-15/189.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionSellerTitleV3
    {
        /// <summary>
        /// Идентификатор файла - имя сформированного файла (без расширения).
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FileId { get; set; }

        /// <summary>
        /// Сведения об участниках электронного документооборота.
        /// </summary>
        [DataMember]
        public ParticipantsServiceInfo ServiceInfo { get; set; }

        /// <summary>
        /// Дата и время формирования документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Порядковый номер и дата корректировочного счета-фактуры, документа об изменении стоимости
        /// отгруженных товаров (выполненных работ, оказанных услуг), переданных имущественных прав.
        /// А также Сведения по исправлению: № и дата,
        /// наименование первичного документа, определенное организацией:
        /// 1. При Функция = КСЧФ не формируется.
        /// 2. При Функция = КСЧФДИС принимает значение
        /// «Корректировочный счет-фактура и документ об изменении стоимости отгруженных
        /// товаров(выполненных работ, оказанных услуг), переданных имущественных прав»
        /// (или самостоятельно сформированное).
        /// 3. При Функция = ДИС самостоятельно установленное наименование документа или
        /// Документ об изменении стоимости отгруженных товаров(выполненных работ, оказанных услуг),
        /// переданных имущественных прав(по умолчанию)).
        /// </summary>
        [DataMember]
        public DocumentShortInfo ShortInfo { get; set; }

        // <summary>
        /// Исходные документы.
        /// </summary>
        [DataMember]
        public List<DocumentShortInfo> OriginalDocuments { get; set; }

        /// <summary>
        /// Продавец (поставщик).
        /// </summary>
        [DataMember]
        public CounterpartyBase Seller { get; set; }

        /// <summary>
        /// Покупатель.
        /// </summary>
        [DataMember]
        public CounterpartyBase Buyer { get; set; }

        /// <summary>
        /// Идентификатор государственного контракта.
        /// </summary>
        [DataMember]
        public string StateContractId { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        [DataMember]
        public CurrencyInfo Currency { get; set; }

        /// <summary>
        /// Информационное поле события (факта хозяйственной жизни).
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Сведения о факте согласования.
        /// </summary>
        [DataMember]
        public ApprovalFactData ApprovalArea { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавшем информацию продавца/исполнителя в электронном виде.
        /// Подписант.
        /// </summary>
        [DataMember]
        public List<Signer> Signers { get; set; }

        /// <summary>
        /// Функция документа.
        /// Соответствует перечислению <see cref="Midway.ObjectModel.ExecutedFunction"/>.
        /// </summary>
        [DataMember]
        public EnumValue ExecutedFunction { get; set; }

        /// <summary>
        /// Составитель документа.
        /// </summary>
        [DataMember]
        public Drafter Drafter { get; set; }

        /// <summary>
        /// Сведения об изменении стоимости ранее отгруженных товаров (выполненных работ, оказанных услуг),
        /// переданных имущественных прав.
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionAreaV3 GeneralTransferCorrectionArea { get; set; }

        /// <summary>
        /// Информация о факторе.
        /// </summary>
        [DataMember]
        public Factor Factor { get; set; }
    }
}
