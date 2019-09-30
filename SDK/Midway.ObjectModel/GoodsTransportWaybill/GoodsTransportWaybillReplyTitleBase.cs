using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Базовый ответный титул товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillReplyTitleBase : GoodsTransportWaybillTitleBase
    {
        /// <summary>
        /// Идентификация титула грузоотправителя.
        /// </summary>
        [DataMember]
        public FileIdentification ConsignorTitleIdentification { get; set; }
    }
}