using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип суммы налога.
    /// </summary>
    [DataContract]
    public enum VatAmountType
    {
        /// <summary>
        /// Отсутствует (сумма налога не указана).
        /// </summary>
        [EnumMember]
        [Description("Отсутствует")]
        None = 0,

        /// <summary>
        /// Присутствует числовое значение сумма налога.
        /// </summary>
        [EnumMember]
        [Description("Присутствует числовое значение сумма налога")]
        WithAmount = 1,

        /// <summary>
        /// Без НДС.
        /// </summary>
        [EnumMember]
        [Description("Без НДС")]
        WithoutVat = 2
    }
}
