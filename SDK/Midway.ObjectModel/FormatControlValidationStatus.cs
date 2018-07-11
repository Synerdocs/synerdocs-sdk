using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус проверки черновика документа.
    /// </summary>
    [DataContract]
    public enum FormatControlValidationStatus
    {
        /// <summary>
        /// Не определено / Не выполнялась.
        /// </summary>
        [EnumMember]
        [Description("Не определено")]
        None = 0,

        /// <summary>
        /// Успешно.
        /// </summary>
        [EnumMember]
        [Description("Успешно")]
        Success = 1,

        /// <summary>
        /// Ошибка.
        /// </summary>
        [EnumMember]
        [Description("Ошибка")]
        Error = 2,

        /// <summary>
        /// Предупреждение.
        /// </summary>
        [EnumMember]
        [Description("Предупреждение")]
        Warning = 3
    }
}
