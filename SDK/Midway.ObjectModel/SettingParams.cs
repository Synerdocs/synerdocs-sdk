using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры настроек.
    /// </summary>
    [DataContract]
    [KnownType(typeof(SettingType))]
    public class SettingParams
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Идентификатор контрагента.
        /// </summary>
        [DataMember]
        public int? OrganizationId { get; set; }

        /// <summary>
        /// Тип настройки.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue SettingType { get; set; }
    }
}
