using System;
using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Операция с грузом (прием или сдача).
    /// </summary>
    [DataContract]
    public class CargoOperation
    {
        /// <summary>
        /// Адрес места погрузки.
        /// </summary>
        [DataMember]
        public Address Address { get; set; }

        /// <summary>
        /// Дата и время подачи транспортного средства под погрузку или разгрузку.
        /// </summary>
        [DataMember]
        public DateTime? HandledAt { get; set; }

        /// <summary>
        /// Фактический промежуток времени между прибытием и убытием ТС.
        /// </summary>
        [DataMember]
        public DateTimeRange Duration { get; set; }

        /// <summary>
        /// Фактическое состояние груза, тары, упаковки, маркировки и опломбирования.
        /// </summary>
        [DataMember]
        public CargoState CargoState { get; set; }

        /// <summary>
        /// Должность, подпись, расшифровка подписи грузоотправителя/грузополучателя (уполномоченного лица).
        /// </summary>
        [DataMember]
        public SignerBase AuthorizedSignatureBy { get; set; }

        /// <summary>
        /// Иные сведения.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
