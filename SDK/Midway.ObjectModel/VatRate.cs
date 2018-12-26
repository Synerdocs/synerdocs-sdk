using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Налоговая ставка.
    /// </summary>
    [DataContract]
    public enum VatRate
    {
        /// <summary>
        /// НДС 0%.
        /// </summary>
        [EnumMember]
        [Description("0%")]
        Zero = 0,

        /// <summary>
        /// НДС 10%.
        /// </summary>
        [EnumMember]
        [Description("10%")]
        Percent10 = 1,

        /// <summary>
        /// НДС 18%.
        /// </summary>
        [EnumMember]
        [Description("18%")]
        Percent18 = 2,

        /// <summary>
        /// НДС 20%.
        /// </summary>
        [EnumMember]
        [Description("20%")]
        Percent20 = 3,

        /// <summary>
        /// НДС 10/110.
        /// </summary>
        [EnumMember]
        [Description("10/110")]
        Fraction10 = 4,

        /// <summary>
        /// НДС 18/118.
        /// </summary>
        [EnumMember]
        [Description("18/118")]
        Fraction18 = 5,

        /// <summary>
        /// Без НДС.
        /// </summary>
        [EnumMember]
        [Description("Без НДС")]
        WithoutVat = 6,

        /// <summary>
        /// НДС не указан.
        /// </summary>
        [EnumMember]
        [Description("Не указано")]
        NotSpecified = 7,

        /// <summary>
        /// НДС 20/120.
        /// </summary>
        [EnumMember]
        [Description("20/120")]
        Fraction20 = 8,

        /// <summary>
        /// НДС исчисляется налоговым агентом.
        /// </summary>
        [EnumMember]
        [Description("НДС исчисляется налоговым агентом")]
        CalculatedByTaxAgent = 9
    }
}
