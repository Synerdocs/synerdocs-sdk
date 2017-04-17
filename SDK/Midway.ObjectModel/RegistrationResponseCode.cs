using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Код результата регистрации абонента
    /// </summary>
    [DataContract]
    public enum RegistrationResponseCode
    {
        /// <summary>
        /// Регистрация прошла успешно
        /// </summary>
        [EnumMember]
        [Description("Регистрация прошла успешно")]
        Success = 0,

        /// <summary>
        /// Ошибка
        /// </summary>
        [EnumMember]
        [Description("Ошибка")]
        Error = 1
    }
}
