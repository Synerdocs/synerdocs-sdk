using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Критерии для выборки информации по организации
    /// </summary>
    [DataContract]
    public enum OrganizationByCriteria
    {
        /// <summary>
        /// Выборка по ИД
        /// </summary>
        [EnumMember]
        ById = 0x0,

        /// <summary>
        /// Выборка по ИНН/КПП
        /// </summary>
        [EnumMember]
        ByInnKpp = 0x1,

        /// <summary>
        /// Выборка по адресу ящика
        /// </summary>
        [EnumMember]
        ByBoxAddress = 0x2,

        /// <summary>
        /// Выборка по коду организации в рамках системы ЭДО
        /// </summary>
        [EnumMember]
        ByServiceCode = 0x3
    }
}
