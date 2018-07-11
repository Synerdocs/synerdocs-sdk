using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание условий хранения груза в терминале грузоперевозчика.
    /// </summary>
    [DataContract]
    public class CarrierStoragePolicies
    {
        /// <summary>
        /// Размер платы за хранение груза в терминале перевозчика.
		/// Усказывается размер оплаты, который зависит от других параметров перевозки.
        /// </summary>
        [DataMember]
        public Amount PaymentAmount { get; set; }

        /// <summary>
        /// Условия оплаты за хранение груза в терминале перевозчика.
        /// </summary>
        [DataMember]
        public string PaymentPolicy { get; set; }

        /// <summary>
        /// Продолжительность хранения груза у перевозчика.
        /// </summary>
        [DataMember]
        public CarrierStorageDuration Duration { get; set; }

        /// <summary>
        /// Иные условия хранения груза в терминале перевозчика.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalPolicies { get; set; }
    }
}
