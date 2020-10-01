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
        /// Соответствует перечислению <see cref="GoodsMarkingState"/>
        /// </summary>
        [DataMember]
        public EnumValue State { get; set; }

        /// <summary>
        /// Дата и время изменения состояния.
        /// </summary>
        [DataMember]
        public DateTime OccurredAt { get; set; }

        /// <summary>
        /// Описание состояния товарной маркировки.
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
