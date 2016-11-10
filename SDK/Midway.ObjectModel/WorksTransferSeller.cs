using System.Runtime.Serialization;
using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул исполнителя документа о передаче результатов работ (документа об оказании услуг)
    /// </summary>
    [DataContract]
    public class WorksTransferSeller
    {
        public WorksTransferSeller()
        {
            ShortInfo = new DocumentShortInfo
            {
                Name = "Акт о передаче результатов работ (Акт об оказании услуг)"
            };

            WorksTransferInfo = new TransferInfo()
            {
                Description = "Результаты работ переданы (услуги оказаны)"
            };
        }

        /// <summary>
        /// ИД-файла
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// Сведения об участнике документооборота
        /// </summary>
        [DataMember]
        public ParticipantsServiceInfo ServiceInfo { get; set; }

        /// <summary>
        /// Дата и время формирования документа о передаче товара, информация продавца
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Составитель информации исполнителя
        /// </summary>
        [DataMember]
        public Drafter Drafter { get; set; }

        /// <summary>
        ///Порядковый номер, дата документа и наименование первичного документа
        /// </summary>
        [DataMember]
        public DocumentShortInfo ShortInfo { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        [DataMember]
        public CurrencyInfo Currency { get; set; }

        /// <summary>
        /// Заголовок содержания операции
        /// </summary>
        [DataMember]
        public string DocumentTitle { get; set; }

        /// <summary>
        /// Исполнитель
        /// </summary>
        [DataMember]
        public Contragent Seller { get; set; }

        /// <summary>
        /// Заказчик
        /// </summary>
        [DataMember]
        public Contragent Buyer { get; set; }

        /// <summary>
        /// Документы-основания
        /// </summary>
        [DataMember]
        public BasisDocument[] BasisDocuments { get; set; }

        /// <summary>
        /// Вид операции
        /// </summary>
        [DataMember]
        public string OperationType { get; set; }

        /// <summary>
        /// Описание работ
        /// </summary>
        [DataMember]
        public WorksTransferArea[] WorksTransferAreas { get; set; }

        /// <summary>
        /// Информационное поле
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Сведения об отпуске товара
        /// </summary>
        [DataMember]
        public TransferInfo WorksTransferInfo { get; set; }

        /// <summary>
        /// Сведения о передаче вещи, изготовленной по договору подряда
        /// </summary>
        [DataMember]
        public TransferInfo ThingsTransferInfo { get; set; }

        /// <summary>
        /// ИнфПолСтр
        /// </summary>
        [DataMember]
        public NameCodeObject[] InfoTexts { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавшем информацию исполнителя в электронном виде
        /// </summary>
        [DataMember]
        public Signer[] Signers { get; set; }

        /// <summary>
        /// Идентификатор государственного контракта
        /// </summary>
        [DataMember]
        public string StateContractId { get; set; }

        /// <summary>
        /// Фактор
        /// </summary>
        [DataMember]
        public Factor Factor { get; set; }
    }
}
