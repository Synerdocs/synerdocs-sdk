using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Таблица товаров.
    /// </summary>
    [DataContract]
    public class GoodsTable
    {
        /// <summary>
        /// Товарные позиции.
        /// </summary>
        [DataMember]
        public List<GoodsItem> Items { get; set; }

        /// <summary>
        /// Всего по товарным позициям.  
        /// </summary>
        [DataMember]
        public GoodsItemsTotal ItemsTotal { get; set; }
    }
}