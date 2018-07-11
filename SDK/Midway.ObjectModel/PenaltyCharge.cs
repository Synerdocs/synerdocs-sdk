using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание размеров и порядка начисления штарфа.
    /// </summary>
    [DataContract]
    public class PenaltyCharge
    {
        /// <summary>
        /// Вид штрафа.
        /// </summary>
        [DataMember]
        public NameCodeObject Type { get; set; }

        /// <summary>
        /// Размер штрафа.
        /// </summary>
        [DataMember]
        public Amount Value { get; set; }

        /// <summary>
        /// Порядок исчисления срока.
        /// </summary>
        [DataMember]
        public string CalculationRoutine { get; set; }

        /// <summary>
        /// Иные условия наложения штрафа.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalPolicies { get; set; }
    }
}
