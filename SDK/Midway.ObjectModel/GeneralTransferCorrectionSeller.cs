using System.Runtime.Serialization;
using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Универсальный корректировочный документ
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionSeller
    {
        public GeneralTransferCorrectionSeller()
        {
            ExecutedFunction = new EnumValue
            {
                Code = 4,
                Name = "InvoiceAndTransferCorrection",
                Description = "КСЧФДИС"
            };
        }

        /// <summary>
        /// Идентификатор файла - имя сформированного файла (без расширения)
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// Сведения об участниках электронного документооборота
        /// </summary>
        [DataMember]
        public ParticipantsServiceInfo ServiceInfo { get; set; }

        /// <summary>
        /// Дата и время формирования документа
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Порядковый номер и дата корректировочного счета-фактуры, документа об изменении стоимости отгруженных товаров (выполненных работ, оказанных услуг), переданных имущественных прав
        /// А также Сведения по исправлению: № и дата,
        /// Наименование первичного документа, определенное организацией:
        /// При Функция=КСЧФ не формируется. 
        /// При Функция = КСЧФДИС принимает значение «Корректировочный счет-фактура и документ об изменении стоимости отгруженных товаров(выполненных работ, оказанных услуг), переданных имущественных прав» (или самостоятельно сформированное). 
        /// При Функция = ДИС самостоятельно установленное наименование документа или Документ об изменении стоимости отгруженных товаров(выполненных работ, оказанных услуг), переданных имущественных прав(по умолчанию))
        /// </summary>
        [DataMember]
        public DocumentShortInfo ShortInfo { get; set; }

        // <summary>
        /// Исходные документы
        /// </summary>
        [DataMember]
        public DocumentShortInfo[] OriginalDocuments { get; set; }

        /// <summary>
        /// Продавец (поставщик)
        /// </summary>
        [DataMember]
        public Contragent Seller { get; set; }

        /// <summary>
        /// Покупатель
        /// </summary>
        [DataMember]
        public Contragent Buyer { get; set; }

        /// <summary>
        /// Идентификатор государственного контракта
        /// </summary>
        [DataMember]
        public string StateContractId { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        [DataMember]
        public CurrencyInfo Currency { get; set; }

        /// <summary>
        /// Информационное поле события (факта хозяйственной жизни)
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Сведения о факте согласования
        /// </summary>
        [DataMember]
        public ApprovalArea ApprovalArea { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавшем информацию продавца/исполнителя в электронном виде
        /// Подписант
        /// </summary>
        [DataMember]
        public Signer[] Signers { get; set; }

        /// <summary>
        /// Функция
        /// </summary>
        [DataMember]
        public EnumValue ExecutedFunction { get; set; }

        /// <summary>
        /// Составитель документа
        /// </summary>
        [DataMember]
        public Drafter Drafter { get; set; }

        /// <summary>
        /// Сведения об изменении стоимости ранее отгруженных товаров (выполненных работ, оказанных услуг), переданных имущественных прав
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionArea GeneralTransferCorrectionArea { get; set; }

        /// <summary>
        /// Фактор
        /// </summary>
        [DataMember]
        public Factor Factor { get; set; }
    }
}
