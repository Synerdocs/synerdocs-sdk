using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры поиска/фильтрации списка вхождений документов.
    /// </summary>
    [DataContract]
    public class DocumentEntryOptions : DocumentListOptions
    {
        /// <summary>
        /// Типы документооборота.
        /// </summary>
        [DataMember]
        public DocumentFlowType[] DocumentFlowTypes { get; set; }
            = new[]
            {
                DocumentFlowType.SentSigned,
                DocumentFlowType.SentUnsigned,
                DocumentFlowType.SentPrepared,
                DocumentFlowType.SentForward,
            };

        /// <summary>
        /// Статусы транспортной накладной (ТрН).
        /// </summary>
        [DataMember]
        public TransportWaybillStatus[] TransportWaybillStatuses { get; set; }

        /// <summary>
        /// Статусы товарно-транспорной накладной (ТТН).
        /// </summary>
        [DataMember]
        public List<GoodsTransportWaybillStatus> GoodsTransportWaybillStatuses { get; set; }
    }
}