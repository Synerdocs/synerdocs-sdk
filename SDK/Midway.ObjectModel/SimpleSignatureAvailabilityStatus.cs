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

        /// <summary>
        /// Не указан номер телефона для использования в простой ЭП.
        /// </summary>
        [EnumMember]
        [Description("Не указан номер телефона для использования в простой ЭП")]
        PhoneNumberNotSpecified = 5,

        /// <summary>
        /// Не указан документ, удостоверяющий личность для использования в простой ЭП.
        /// Для граждан РФ это СНИЛС, для иностранного гражданина это
        /// данные документа, удостоверяющего личность + код страны.
        /// </summary>
        [EnumMember]
        [Description("Не указан документ, удостоверяющий личность для использования в простой ЭП." +
            "Для граждан РФ это СНИЛС, для иностранного гражданина это " +
            "данные документа, удостоверяющего личность + код страны")]
        IdentityDocumentNotSpecified = 6,
    }
}
