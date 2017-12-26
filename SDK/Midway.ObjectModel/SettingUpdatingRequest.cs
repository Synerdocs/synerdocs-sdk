using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на изменение настройки.
    /// </summary>
    [DataContract]
    public class SettingUpdatingRequest : OperationRequest
    {
        /// <summary>
        /// Тип настройки.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue SettingType { get; set; }

        /// <summary>
        /// Значение настройки.
        /// </summary>
        [DataMember(IsRequired = true)]
        public SettingValue SettingValue { get; set; }

        /// <summary>
        /// Сущность, для которой задана настройка.
        /// </summary>
        [DataMember(IsRequired = true)]
        public Entity SettingEntity { get; set; }
    }
}
