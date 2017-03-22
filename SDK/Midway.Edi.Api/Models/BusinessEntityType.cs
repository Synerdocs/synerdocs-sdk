using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Тип бизнес-сущности
    /// </summary>
    [DataContract]
    public enum BusinessEntityType
    {
        /// <summary>
        /// Неизвестно
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
    }
}
