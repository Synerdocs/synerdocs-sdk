using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Итоговый результат приемки товара.
    /// </summary>
    [DataContract]
    public enum GoodsAcceptanceResultType
    {
        /// <summary>
        /// Товары (работы, услуги, права) приняты без расхождений (претензий).
        /// </summary>
        [EnumMember]
        [Description("Товары (работы, услуги, права) приняты без расхождений (претензий)")]
        Accepted = 1,

        /// <summary>
        /// Товары (работы, услуги, права) приняты с расхождениями (претензией).
        /// </summary>
        [EnumMember]
        [Description("Товары (работы, услуги, права) приняты с расхождениями (претензией)")]
        AcceptedWithDivergence = 2,

        /// <summary>
        /// Товары (работы, услуги, права) не приняты.
        /// </summary>
        [EnumMember]
        [Description("Товары (работы, услуги, права) не приняты")]
        NotAccepted = 3,
    }
}
