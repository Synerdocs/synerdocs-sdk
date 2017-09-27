using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус доступности использования простой ЭП.
    /// </summary>
    [DataContract]
    public enum SimpleSignatureAvailabilityStatus
    {
        /// <summary>
        /// Использование простой ЭП доступно.
        /// </summary>
        [EnumMember]
        [Description("Использование простой ЭП доступно")]
        Available = 0,

        /// <summary>
        /// Использование простой ЭП отключено.
        /// </summary>
        [EnumMember]
        [Description("Использование простой ЭП отключено")]
        Disabled = 1,

        /// <summary>
        /// Не приняты правила использования простой ЭП.
        /// </summary>
        [EnumMember]
        [Description("Не приняты правила использования простой ЭП")]
        RegulationNotAccepted = 2,

        /// <summary>
        /// Не указан СНИЛС для использования в простой ЭП.
        /// </summary>
        [EnumMember]
        [Description("Не указан СНИЛС для использования в простой ЭП")]
        SnilsNotSpecified = 3,

        /// <summary>
        /// Подписание простой ЭП недоступно для данного типа документа.
        /// </summary>
        [EnumMember]
        [Description("Подписание простой ЭП недоступно для данного типа документа")]
        DocumentTypeNotAllowed = 4,
    }
}
