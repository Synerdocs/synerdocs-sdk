using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Титул покупателя/заказчика Универсального корректировочного документа версии 3.
    /// Формат УКД, утвержденный приказом № ЕД-7-26/736.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionBuyerTitleV3
    {
        /// <summary>
        /// Идентификатор файла - имя сформированного файла (без расширения).
        /// </summary>
        [DataMember(IsRequired = false)]
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
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Составитель информации покупателя/заказчика.
        /// </summary>
        [DataMember]
        public Drafter Drafter { get; set; }

        /// <summary>
        /// Идентификация первичного документа, информация продавца/исполнителя.
        /// </summary>
        [DataMember]
        public SellerTitleIdentification SellerTitleIdentification { get; set; }

        /// <summary>
        /// Краткая информация о первичном документе - информация продавца/исполнителя 
        /// </summary>
        [DataMember]
        public DocumentShortInfo SellerTitleShortInfo { get; set; }

        /// <summary>
        /// Сведения о согласовании изменений.
        /// </summary>
        [DataMember]
        public ApprovalInfo ApprovalInfo { get; set; }

        /// <summary>
        /// Информационное поле факта хозяйственной жизни.
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавшем информацию покупателя/заказчика в электронном виде.
        /// Подписант
        /// </summary>
        [DataMember]
        public Signer[] Signers { get; set; }

        /// <summary>
        /// Функция документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue ExecutedFunction { get; set; }
    }
}
