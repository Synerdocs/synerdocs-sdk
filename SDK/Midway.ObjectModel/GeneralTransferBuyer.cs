using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул покупателя/заказчика Универсального передаточного документа
    /// </summary>
    [DataContract]
    public class GeneralTransferBuyer
    {
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
        /// Составитель информации покупателя/заказчика
        /// </summary>
        [DataMember]
        public Drafter Drafter { get; set; }

        /// <summary>
        /// Идентификация первичного документа, информация продавца/исполнителя 
        /// </summary>
        [DataMember]
        public SellerTitleIdentification SellerTitleIdentification { get; set; }

        /// <summary>
        /// Краткая информация о первичном документе - информация продавца/исполнителя 
        /// </summary>
        [DataMember]
        public DocumentShortInfo SellerTitleShortInfo { get; set; }

        /// <summary>
        /// Сведения о приемке товара
        /// </summary>
        [DataMember]
        public AcceptanceInfo GoodsAcceptanceInfo { get; set; }

        /// <summary>
        /// Сведения о лице, принявшем товар (получившем груз) 
        /// </summary>
        [DataMember]
        public Person GoodsReceiver { get; set; }

        /// <summary>
        /// Вид операции
        /// Дополнительная информация, позволяющая в автоматизированном режиме определять необходимый для конкретного случая порядок использования информации документа у покупателя
        /// </summary>
        [DataMember]
        public string OperationType { get; set; }

        /// <summary>
        /// Информационное поле
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавших информацию покупателя/заказчика в электронном виде
        /// Подписант
        /// </summary>
        [DataMember]
        public Signer[] Signers { get; set; }

        /// <summary>
        /// Функция
        /// </summary>
        [DataMember]
        public EnumValue ExecutedFunction { get; set; }
    }
}