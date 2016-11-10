using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул заказчика документа о передаче результатов работ (документа об оказании услуг)
    /// </summary>
    [DataContract]
    public class WorksTransferBuyer
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
        /// Дата и время формирования документа о передаче результатов работ (документа об оказании услуг), информация заказчика
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Составитель информации заказчика
        /// </summary>
        [DataMember]
        public Drafter Drafter { get; set; }

        /// <summary>
        /// Идентификация документа о передаче результатов работ (документа об оказании услуг), информация исполнителя 
        /// </summary>
        [DataMember]
        public SellerTitleIdentification SellerTitleIdentification { get; set; }

        /// <summary>
        /// Краткая информация о первичном документе - информация исполнителя
        /// </summary>
        [DataMember]
        public DocumentShortInfo SellerTitleShortInfo { get; set; }

        /// <summary>
        /// Сведения о приемке результатов работ (подтверждение факта оказания услуг)
        /// </summary>
        [DataMember]
        public AcceptanceInfo WorksAcceptanceInfo { get; set; }

        /// <summary>
        /// Сведения о получении вещи, изготовленной по договору подряда 
        /// </summary>
        [DataMember]
        public AcceptanceInfo ThingsAcceptanceInfo { get; set; }

        /// <summary>
        /// Вид операции
        /// Дополнительная информация, позволяющая в автоматизированном режиме определять необходимый для конкретного случая порядок использования информации документа у заказчика
        /// </summary>
        [DataMember]
        public string OperationType { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Сведения о лицах, подписавших информацию заказчика в электронном виде
        /// Подписант
        /// </summary>
        [DataMember]
        public Signer[] Signers { get; set; }
    }
}
