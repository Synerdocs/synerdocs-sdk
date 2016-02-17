using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип организации
    /// </summary>
    [DataContract]
    public enum OrganizationType
    {
        /// <summary>
        /// Неизвестно (для внутреннего использования - нет в API)
        /// </summary>
        [Description("Неизвестно")]
        Unknown = 0,

        /// <summary>
        /// Юридическое лицо (ЮЛ)
        /// </summary>
        [EnumMember]
        [Description("Юридическое лицо")]
        LegalEntity = 1,

        /// <summary>
        /// Индивидуальный предприниматель (ИП)
        /// </summary>
        [EnumMember]
        [Description("Индивидуальный предприниматель")]
        IndividualEntrepreneur = 2,

        /// <summary>
        /// Физическое лицо (ФЛ)
        /// </summary>
        [EnumMember]
        [Description("Физическое лицо")]
        Individual = 3,
    }
}
