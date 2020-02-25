using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на обновление настройки допуска организации к группе приложений.
    /// </summary>
    [DataContract]
    public class OrganizationApplicationGroupAccessValueSettingRequest
    {
        /// <summary>
        /// ИД организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int OrganizationId { get; set; }

        /// <summary>
        /// ИД группы приложений.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue ApplicationGroup { get; set; }

        /// <summary>
        /// Флаг возможности доступа организации к группе приложений.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool Enabled { get; set; }
    }
}
