using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул продавца Документа о передаче товаров при торговых операциях
    /// </summary>
    [DataContract]
    public class GoodsTransferSeller
    {
        public GoodsTransferSeller()
        {
            ShortInfo = new DocumentShortInfo
            {
                Name = "Товарная накладная"
            };

            GoodsTransferInfo = new TransferInfo()
            {
                Description = "Перечисленные в документе ценности переданы"
            };
        }

        /// <summary>
        /// Ид файла
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
        /// Составитель документа передачи товаров
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
        /// Грузоотправитель
        /// </summary>
        [DataMember]
        public Contragent Consignor { get; set; }

        /// <summary>
        /// Грузополучатель
        /// </summary>
        [DataMember]
        public Contragent Consignee { get; set; }

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
        /// Документы-основания
        /// </summary>
        [DataMember]
        public BasisDocument[] BasisDocuments { get; set; }

        /// <summary>
        /// Перевозчик
        /// </summary>
        [DataMember]
        public Contragent Carrier { get; set; }

        /// <summary>
        /// Вид операции
        /// </summary>
        [DataMember]
        public string OperationType { get; set; }

        /// <summary>
        /// Информационное поле хозяйственной жизни
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Описание товаров
        /// </summary>
        [DataMember]
        public GoodsTransferArea GoodsTransferArea { get; set; }

        /// <summary>
        /// Сведения об отпуске товара
        /// </summary>
        [DataMember]
        public TransferInfo GoodsTransferInfo { get; set; }

        /// <summary>
        /// Сведения о лице, передавшем товар 
        /// </summary>
        [DataMember]
        public Person Bailor { get; set; }

        /// <summary>
        /// Количество приложений
        /// </summary>
        [DataMember]
        public string AnnexCount { get; set; }

        /// <summary>
        /// Дополнительные поля
        /// </summary>
        [DataMember]
        public NameCodeObject[] InfoTexts { get; set; }

        /// <summary>
        /// Транспортные накладные
        /// </summary>
        [DataMember]
        public NumberDate[] LadingBills { get; set; }

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
        /// Информация о факторе
        /// </summary>
        [DataMember]
        public Factor Factor { get; set; }
    }
}
