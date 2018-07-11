using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип подписанта документа.
    /// </summary>
    [DataContract]
    public enum SignerType
    {
        /// <summary>
        /// Не указан.
        /// </summary>
        [Description("Не указан")]
        None = 0,

        /// <summary>
        /// Работник организации.
        /// </summary>
        [EnumMember]
        [Description("Работник организации")]
        Employee = 1,

        /// <summary>
        /// Работник организации - составителя информации.
        /// </summary>
        [EnumMember]
        [Description("Работник организации - составителя информации")]
        DrafterEmployee = 2,

        /// <summary>
        /// Работник иной уполномоченной организации.
        /// </summary>
        [EnumMember]
        [Description("Работник иной уполномоченной организации")]
        OtherOrganizationEmployee = 3,

        /// <summary>
        /// Уполномоченное физическое лицо.
        /// </summary>
        [EnumMember]
        [Description("Уполномоченное физическое лицо")]
        AuthorizedPerson = 4
    }
}
