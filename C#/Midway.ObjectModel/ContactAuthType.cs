using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип авторизации контактов
    /// </summary>
    [DataContract]
    public enum ContactAuthType : byte
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
//        [EnumMember]
        [Description("Неизвестно")]
        Unknown = 0x0,

        /// <summary>
        /// Пользователь сам выбирает, что делать с приглашением к обмену
        /// </summary>
        [EnumMember]
        [Description("По выбору пользователя")]
        Manual = 0x1,

        /// <summary>
        /// Автоматически принимать все приглашения к обмену
        /// </summary>
        [EnumMember]
        [Description("Принимать все приглашения")]
        Accept = 0x2,

        /// <summary>
        /// Автоматически отклонять все приглашения к обмену
        /// </summary>
        [EnumMember]
        [Description("Отклонять все приглашения")]
        Reject = 0x3,
    }
}
