using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Категория сообщения валидации
    /// </summary>
    [DataContract]
    public enum ValidationMessageCategory
    {
        /// <summary>
        /// Неизвестная категория
        /// </summary>
        [EnumMember]
        [Description("Неизвестная категория")]
        Unknown = 0,

        /// <summary>
        /// Требуется значение
        /// </summary>
        [EnumMember]
        [Description("Требуется значение")]
        Required = 1,

        /// <summary>
        /// Неправильный формат
        /// </summary>
        [EnumMember]
        [Description("Неправильный формат")]
        Format = 2,

        /// <summary>
        /// Неправильная длина
        /// </summary>
        [EnumMember]
        [Description("Неправильная длина")]
        Length = 3,
    }
}
