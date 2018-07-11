using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Расходы перевозчика и предъявляемые грузоотправителю платежи.
    /// </summary>
    [DataContract]
    public class CarriagePayment
    {
        /// <summary>
        /// Вид расходов перевозчика и платежей, предъявляемых грузоотправителю.
        /// </summary>
        [DataMember]
        public NameCodeObject Type { get; set; }

        /// <summary>
        /// Величина расходов перевозчика и платежей, предъявляемых грузоотправителю.
        /// </summary>
        [DataMember]
        public Amount Amount { get; set; }
    }
}
