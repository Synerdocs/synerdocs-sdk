using System.Collections.Generic;
using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о факте отгрузки товаров (выполнения работ), передачи имущественных прав (о предъявлении оказанных услуг).
    /// Формат УПД, утвержденный ММВ-7-15/820.
    /// </summary>
    [DataContract]
    public class TransferAreaV2
    {
        /// <summary>
        /// Основание отгрузки товаров.
        /// </summary>
        [DataMember]
        public List<BasisDocument> BasisDocuments { get; set; }

        /// <summary>
        /// Сведения о лице, передавшем товар.
        /// </summary>
        [DataMember]
        public Person Bailor { get; set; }

        /// <summary>
        /// Список транспортных накладных.
        /// </summary>
        [DataMember]
        public List<NumberDate> LadingBills { get; set; }

        /// <summary>
        /// Перевозчик.
        /// </summary>
        [DataMember]
        public Contragent Carrier { get; set; }

        /// <summary>
        /// Сведения о транспортировке и грузе.
        /// </summary>
        [DataMember]
        public string TransportationData { get; set; }

        /// <summary>
        /// Сведения о передаче вещи, изготовленной по договору подряда.
        /// </summary>
        [DataMember]
        public TransferInfo ThingsTransferInfo { get; set; }

        /// <summary>
        /// Вид операции.
        /// Дополнительная информация, позволяющая в автоматизированном режиме определять необходимый 
        /// для конкретного случая порядок использования информации документа у продавца.
        /// </summary>
        [DataMember]
        public string OperationType { get; set; }

        /// <summary>
        /// Сведения о передаче.
        /// </summary>
        [DataMember]
        public AcceptanceInfo TransferData { get; set; }

        /// <summary>
        /// Информационное поле факта хозяйственной жизни.
        /// </summary>
        [DataMember]
        public InfoFieldFull InfoField { get; set; }

        /// <summary>
        /// Период оказания услуг.
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTimeRange DateTimeRange { get; set; }
    }
}
