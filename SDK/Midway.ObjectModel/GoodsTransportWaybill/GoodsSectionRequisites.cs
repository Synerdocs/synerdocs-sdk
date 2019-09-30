using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Реквизиты товарного раздела.
    /// </summary>
    [DataContract]
    public class GoodsSectionRequisites
    {
        /// <summary>
        /// Количество листов.
        /// </summary>
        [DataMember]
        public decimal? SheetCount { get; set; }

        /// <summary>
        /// Номера бланков.
        /// </summary>
        [DataMember]
        public string FormsNumbers { get; set; }

        /// <summary>
        /// Количество порядковых номеров прописью.
        /// </summary>
        [DataMember]
        public string SequentialNumberCountText { get; set; }

        /// <summary>
        /// Количество наименований прописью.
        /// </summary>
        [DataMember]
        public string PositionCountText { get; set; }

        /// <summary>
        /// Количество мест прописью.
        /// </summary>
        [DataMember]
        public string AreaCountText { get; set; }

        /// <summary>
        /// Масса нетто.
        /// </summary>
        [DataMember]
        public Quantity NetWeight { get; set; }

        /// <summary>
        /// Масса брутто.
        /// </summary>
        [DataMember]
        public Quantity GrossWeight { get; set; }

        /// <summary>
        /// Количество приложений.
        /// </summary>
        [DataMember]
        public string AttachmentCount { get; set; }

        /// <summary>
        /// Всего отпущено на сумму.
        /// </summary>
        [DataMember]
        public string TotalSoldFor { get; set; }
    }
}