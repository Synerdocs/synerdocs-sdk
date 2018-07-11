using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Стоимость услуг перевозчика и порядок расчета провозной платы.
    /// </summary>
    [DataContract]
    public class CarriageCostAndPaymentPolicy
    {
        /// <summary>
        /// Cтоимость услуги перевозчика.
        /// </summary>
        [DataMember]
        public Amount ServiceAmount { get; set; }

        /// <summary>
        /// Порядок (механизм) расчета (исчислений) платы за услуги перевозчика.
        /// </summary>
        [DataMember]
        public string CalculationRoutine { get; set; }

        /// <summary>
        /// Расходы перевозчика и предъявляемые грузоотправителю платежи.
        /// </summary>
        [DataMember]
        public List<CarriagePayment> Payments { get; set; }

        /// <summary>
        /// Полное наименование организации плательщика (грузоотправителя).
        /// </summary>
        [DataMember]
        public CounterpartyBase Payer { get; set; }
    }
}
