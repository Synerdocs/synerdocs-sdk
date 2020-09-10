using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос получения состояния товарной маркировки документа.
    /// </summary>
    [DataContract]
    public class DocumentGoodsMarkingStateResponse : OperationResponse
    {
        /// <summary>
        /// Состояние кодов маркировки документа.
        /// Соответствует перечислению <see cref="Midway.ObjectModel.GoodsMarking.GoodsMarkingState"/>
        /// </summary>
        [DataMember]
        public EnumValue State { get; set; }

        /// <summary>
        /// Дата и время изменения состояния.
        /// </summary>
        [DataMember]
        public DateTime OccurredAt { get; set; }
    }
}
