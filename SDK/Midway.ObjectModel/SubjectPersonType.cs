using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип владельца (субъекта) сертификата
    /// </summary>
    [DataContract]
    public enum SubjectPersonType
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        [EnumMember]
        [Description("Неизвестно")]
        Unknown = 0x00,

        /// <summary>
        /// Личный
        /// </summary>
        [EnumMember]
        [Description("Личный")]
        Individual = 0x01,

        /// <summary>
        /// Индивидуальный предприниматель
        /// </summary>
        [EnumMember]
        [Description("Индивидуальный предприниматель")]
        IndividualEntrepreneur = 0x02,

        /// <summary>
        /// Юридическое лицо
        /// </summary>
        [EnumMember]
        [Description("Юридическое лицо")]
        LegalEntity = 0x03
    }
}
