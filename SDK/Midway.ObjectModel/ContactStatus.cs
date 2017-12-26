using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статусы контакта.
    /// </summary>
    [DataContract]
    public enum ContactStatus : byte
    {
        /// <summary>
        /// Не авторизован. Обмен невозможен.
        /// </summary>
        [EnumMember]
        [Description("Не авторизован")]
        NonAuthorized = 0x0,

        /// <summary>
        /// Действующий. Обмен разрешен.
        /// </summary>
        [EnumMember]
        [Description("Действующий")]
        Active = 0x1,

        /// <summary>
        /// Удален. Обмен невозможен (не используется).
        /// </summary>
        [EnumMember]
        [Description("Удален")]
        Deleted = 0x2,

        /// <summary>
        /// Исходящий запрос авторизации.
        /// </summary>
        [EnumMember]
        [Description("Отправлено приглашение к обмену")]
        OutgoingAuthRequest = 0x3,

        /// <summary>
        /// Входящий запрос авторизации.
        /// </summary>
        [EnumMember]
        [Description("Получено приглашение к обмену")]
        IncomingAuthRequest = 0x4,

        /// <summary>
        /// Отклоненный запрос входящей авторизации. Обмен невозможен.
        /// </summary>
        [EnumMember]
        [Description("Отклонено приглашение к обмену")]
        AuthRejected = 0x5,

        /// <summary>
        /// Любой, кроме действующего (для поиска).
        /// </summary>
        [EnumMember]
        [Description("Любой, кроме действующего")]
        NonActive = 0x6,

        /// <summary>
        /// Отклоненный запрос исходящей авторизации. Обмен и запросы авторизации запрещены.
        /// </summary>
        [EnumMember]
        [Description("Обмен запрещен")]
        OutgoingAuthRejected = 0x7,

        /// <summary>
        /// Отозванный запрос исходящей авторизации. Обмен невозможен.
        /// </summary>
        [EnumMember]
        [Description("Отозвано отправленное приглашение к обмену")]
        OutgoingAuthCancelled = 0x8,

        /// <summary>
        /// Отозванный запрос входящей авторизации. Обмен невозможен.
        /// </summary>
        [EnumMember]
        [Description("Отозвано полученное приглашение к обмену")]
        IncomingAuthCancelled = 0x9,
    }
}
