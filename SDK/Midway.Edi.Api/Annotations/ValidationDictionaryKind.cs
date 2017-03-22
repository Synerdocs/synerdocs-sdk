using System.ComponentModel;

namespace Midway.Edi.Api.Annotations
{
    /// <summary>
    /// Наименования справочников для валидации
    /// </summary>
    public enum ValidationDictionaryKind
    {
        /// <summary>
        /// Общероссийский классификатор валют 
        /// </summary>
        [Description("Общероссийский классификатор валют")]
        OKV = 1,

        /// <summary>
        /// Коды субъектов Российской Федерации
        /// </summary>
        [Description("Коды субъектов Российской Федерации")]
        RegionRF = 2,

        /// <summary>
        /// Общероссийский классификатор стран мира
        /// </summary>
        [Description("Общероссийский классификатор стран мира")]
        OKSM = 3,

        /// <summary>
        /// Общероссийский классификатор единиц измерений
        /// </summary>
        [Description("Общероссийский классификатор единиц измерений")]
        OKEI = 4
    }
}
