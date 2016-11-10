using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание товаров
    /// </summary>
    [DataContract]
    public class GoodsTransferArea
    {
        /// <summary>
        /// Товары 
        /// </summary>
        [DataMember]
        public GoodsTransferItem[] Items { get; set; }

        /// <summary>
        /// Итого по документу
        /// </summary>
        [DataMember]
        public GoodsTransferTotal Total { get; set; }
    }
}
