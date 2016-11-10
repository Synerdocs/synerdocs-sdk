using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Разность суммы до и после редактирования
    /// </summary>
    [DataContract]
    public class AmountChange
    {
        /// <summary>
        /// Увеличение
        /// </summary>
        [DataMember]
        public decimal? AmountInc { get; set; }

        /// <summary>
        /// Уменьшение
        /// </summary>
        [DataMember]
        public decimal? AmountDec { get; set; }
    }
}
