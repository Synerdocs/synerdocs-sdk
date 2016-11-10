using System.Runtime.Serialization;
using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул покупателя/заказчика Универсального корректировочного документа
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionBuyer
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
        /// Сведения о согласовании изменений
        /// </summary>
        [DataMember]
        public ApprovalInfo ApprovalInfo { get; set; }

        /// <summary>
        /// Информационное поле
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавшем информацию покупателя/заказчика в электронном виде
        /// Подписант
        /// </summary>
        [DataMember]
        public Signer[] Signers { get; set; }

        /// <summary>
        /// Функция документа
        /// </summary>
        [DataMember]
        public EnumValue ExecutedFunction { get; set; }
    }
}
