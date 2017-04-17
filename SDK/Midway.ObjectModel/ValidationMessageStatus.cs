using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус сообщения валидации
    /// </summary>
    [DataContract]
    public enum ValidationMessageStatus
    {
        /// <summary>
        /// Успешная проверка
        /// </summary>
        [EnumMember]
        [Description("Успешная проверка")]
        Success = 0,

        /// <summary>
        /// Предупреждение
        /// </summary>
        [EnumMember]
        [Description("Предупреждение")]
        Warning = 1,

        /// <summary>
        /// Ошибка
        /// </summary>
        [EnumMember]
        [Description("Ошибка")]
        Error = 2,
    }
}
