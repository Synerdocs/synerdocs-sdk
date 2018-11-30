using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Переадресовка.
    /// </summary>
    [DataContract]
    public class PlaceChange
    {
        /// <summary>
        /// Дата и время переадресовки.
        /// </summary>
        [DataMember]
        public DateTime? ChangedAt { get; set; }

        /// <summary>
        /// Форма переадресовки.
        /// </summary>
        [DataMember]
        public string Form { get; set; }

        /// <summary>
        /// Сведения о лице, от которого получено указание на переадресовку.
        /// </summary>
        [DataMember]
        public PlaceChangeInitiatorBase Initiator { get; set; }

        /// <summary>
        /// Новый пункт.
        /// </summary>
        [DataMember]
        public CargoOperation PlaceChangeInfo { get; set; }

        /// <summary>
        /// Грузополучатель.
        /// </summary>
        [DataMember]
        public CounterpartyBase Consignee { get; set; }

        /// <summary>
        /// Иные сведения.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
