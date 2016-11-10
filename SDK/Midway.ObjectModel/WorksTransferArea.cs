using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание работ
    /// </summary>
    [DataContract]
    public class WorksTransferArea
    {
        /// <summary>
        /// Начало работ
        /// </summary>
        [DataMember]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Окончание работ
        /// </summary>
        [DataMember]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Работы
        /// </summary>
        [DataMember]
        public WorksTransferItem[] Items { get; set; }

        /// <summary>
        /// Итого по документу
        /// </summary>
        [DataMember]
        public WorksTransferTotal Total { get; set; }
    }
}
