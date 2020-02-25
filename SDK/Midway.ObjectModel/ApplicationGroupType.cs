using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Перечисление групп приложений.
    /// </summary>
    [DataContract]
    public enum ApplicationGroupType
    {
        /// <summary>
        /// Семейство интеграционных решений 1С, включающее все существующие конфигурации.
        /// </summary>
        [EnumMember]
        [Description("Интеграционные решения 1С")]
        Integration1C = 1,

        /// <summary>
        /// Внешние интеграционные решения, работающие через API.
        /// </summary>
        [EnumMember]
        [Description("Внешние интеграционные решения")]
        ExternalIntegrationProjects = 2,

        /// <summary>
        /// Доверенные интеграционные решения, работающие через API.
        /// </summary>
        [EnumMember]
        [Description("Доверенные интеграционные решения")]
        TrustedIntegrationProjects = 3,

        /// <summary>
        /// Сервисы интеграции Synerdocs.
        /// </summary>
        [EnumMember]
        [Description("Сервисы интеграции")]
        IntegrationService = 4,
    }
}
