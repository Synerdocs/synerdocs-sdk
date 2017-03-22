using System.ComponentModel;

namespace Midway.Edi.Api.Annotations
{
    /// <summary>
    /// Перечисление с набором типов доступных атрибутов валидации
    /// </summary>
    public enum ValidationAttributeType
    {
        /// <summary>
        /// Валидатор наличия значения
        /// </summary>
        [Description("Валидатор наличия значения")]
        Required = 1,

        /// <summary>
        /// Валидатор наличия пары Код-Наименование
        /// </summary>
        [Description("Валидатор наличия пары Код-Наименование")]
        CodeNameRequired = 2,

        /// <summary>
        /// Валидатор соответствия кода по справочнику
        /// </summary>
        [Description("Валидатор соответствия кода по справочнику")]
        CodeDictionary = 3,

        /// <summary>
        /// Валидатор соответствия наименования по справочнику
        /// </summary>
        [Description("Валидатор соответствия наименования по справочнику")]
        NameDictionary = 4,

        /// <summary>
        /// Валидатор соответствия кода наименованию по справочнику
        /// </summary>
        [Description("Валидатор соответствия кода наименованию по справочнику")]
        CodeNameDictionary = 5,

        /// <summary>
        /// Валидатор номера телефона
        /// </summary>
        [Description("Валидатор номера телефона")]
        PhoneFormat = 6,

        /// <summary>
        /// Валидатор формата ИНН юридического лица, физического лица или ИП
        /// </summary>
        [Description("Валидатор формата ИНН юридического лица, физического лица или ИП")]
        InnFormat = 7,

        /// <summary>
        /// Валидатор формата ИНН физического лица или ИП
        /// </summary>
        [Description("Валидатор формата ИНН физического лица или ИП")]
        IndividualInnFormat = 8,

        /// <summary>
        /// Валидатор формата ИНН юридического лица
        /// </summary>
        [Description("Валидатор формата ИНН юридического лица")]
        LegalEntityInnFormat = 9,

        /// <summary>
        /// Валидатор формата ОГРН юридического лица, физического лица или ИП
        /// </summary>
        [Description("Валидатор формата ОГРН юридического лица, физического лица или ИП")]
        OgrnFormat = 10,

        /// <summary>
        /// Валидатор формата ОГРН физического лица или ИП
        /// </summary>
        [Description("Валидатор формата ОГРН физического лица или ИП")]
        IndividualOgrnFormat = 11,

        /// <summary>
        /// Валидатор формата ОГРН юридического лица
        /// </summary>
        [Description("Валидатор формата ОГРН юридического лица")]
        LegalEntityOgrnFormat = 12,

        /// <summary>
        /// Валидатор формата КПП
        /// </summary>
        [Description("Валидатор формата КПП")]
        KppFormat = 13,

        /// <summary>
        /// Валидатор формата номера GLN
        /// </summary>
        [Description("Валидатор формата номера GLN")]
        GlnFormat = 14,

        /// <summary>
        /// Валидатор номеров GS1 (EAN, UPC, GTIN и GLN) по контрольной цифре
        /// </summary>
        [Description("Валидатор номеров GS1 (EAN, UPC, GTIN и GLN) по контрольной цифре")]
        GS1CheckDigit = 15,
    }
}
