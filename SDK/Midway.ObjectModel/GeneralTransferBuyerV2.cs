using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул покупателя УПД.
    /// Формат УПД, утвержденный ММВ-7-15/820.
    /// </summary>
    [DataContract]
    public class GeneralTransferBuyerV2
    {
        /// <summary>
        /// Идентификатор файла - имя сформированного файла (без расширения).
        /// </summary>
        [DataMember(IsRequired = false)]
        public string FileId { get; set; }

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
        /// Составитель информации покупателя/заказчика.
        /// </summary>
        [DataMember(IsRequired = false)]
        public Drafter Drafter { get; set; }

        /// <summary>
        /// Идентификация первичного документа, информация продавца/исполнителя. 
        /// </summary>
        [DataMember(IsRequired = false)]
        public SellerTitleIdentification SellerTitleIdentification { get; set; }

        /// <summary>
        /// Краткая информация о первичном документе - информация продавца/исполнителя.
        /// </summary>
        [DataMember(IsRequired = true)]
        public DocumentShortInfo SellerTitleShortInfo { get; set; }

        /// <summary>
        /// Сведения о приемке товара.
        /// </summary>
        [DataMember]
        public AcceptanceInfo GoodsAcceptanceInfo { get; set; }

        /// <summary>
        /// Сведения о лице, принявшем товар (получившем груз). 
        /// </summary>
        [DataMember]
        public Person GoodsReceiver { get; set; }

        /// <summary>
        /// Вид операции. Дополнительная информация, позволяющая в автоматизированном режиме определять 
        /// необходимый для конкретного случая порядок использования информации документа у покупателя.
        /// </summary>
        [DataMember(IsRequired = false)]
        public string OperationType { get; set; }

        /// <summary>
        /// Информационное поле.
        /// </summary>
        [DataMember(IsRequired = false)]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавших информацию покупателя/заказчика в электронном виде.
        /// Подписант.
        /// </summary>
        [DataMember(IsRequired = false)]
        public List<Signer> Signers { get; set; }

        /// <summary>
        /// Функция документа, соответствует перечислению <see cref="Midway.ObjectModel.ExecutedFunction"/>.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue ExecutedFunction { get; set; }

        /// <summary>
        /// Информация о Покупателях/заказчиках.
        /// </summary>
        [DataMember]
        public List<Contragent> Buyers { get; set; }

        /// <summary>
        /// Информация покупателя об обстоятельствах закупок для государственных и муниципальных нужд.
        /// </summary>
        [DataMember(IsRequired = false)]
        public BuyerStateOrderInfo BuyerStateOrderInfo { get; set; }
    }
}
