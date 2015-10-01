using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус организации в сервисе
    /// </summary>
    [DataContract]
    public enum OrganizationStatus
    {
        /// <summary>
        /// Не известно
        /// (также используется для приглашения новой организации)
        /// </summary>
        [Description("Новая организация")]
        Unknown = 0,

        /// <summary>
        /// Активная организация
        /// </summary>
        [EnumMember]
        [Description("Активный")]
        Active = 1,

        /// <summary>
        /// Тестовая организация (по умолчанию при регистрации)
        /// </summary>
        [EnumMember]
        [Description("Тестовый")]
        Test = 2,

        /// <summary>
        /// Организация, не зарегистрированная в сервисе
        /// </summary>
        [EnumMember]
        [Description("Неактивный")]
        NonActive = 3,
    }
}
