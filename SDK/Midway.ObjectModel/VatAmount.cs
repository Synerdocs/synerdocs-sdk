using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сумма налога.
    /// </summary>
    [DataContract]
    public class VatAmount
    {
        /// <summary>
        /// Тип суммы налога.
        /// Соответствует перечислению <see cref="ObjectModel.VatAmountType"/>.
        /// </summary>
        [DataMember]
        public EnumValue VatAmountType { get; set; }

        /// <summary>
        /// Значение суммы налога.
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }
    }
}