using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Товарный раздел грузоотправителя.
    /// </summary>
    [DataContract]
    public class ConsignorGoodsSection
    {
        /// <summary>
        /// Таблица товаров.
        /// </summary>
        [DataMember]
        public GoodsTable GoodsTable { get; set; }

        /// <summary>
        /// Реквизиты товарного раздела.
        /// </summary>
        [DataMember]
        public GoodsSectionRequisites Requisites { get; set; }

        /// <summary>
        /// Информация о подписании товарного раздела.
        /// </summary>
        [DataMember]
        public GoodsSectionSigningInfo SigningInfo { get; set; }
    }
}