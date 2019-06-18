using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Платежный документ.
    /// </summary>
    [DataContract]
    public class PaymentBillingDocument : NumberDate
    {
        /// <summary>
        /// Сумма.
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }
    }
}
