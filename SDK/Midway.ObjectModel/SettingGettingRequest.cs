using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на получение настройки.
    /// </summary>
    [DataContract]
    public class SettingGettingRequest : OperationRequest
    {
        /// <summary>
        /// Тип настройки.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue SettingType { get; set; }

        /// <summary>
        /// Сущность, для которой задана настройка.
        /// </summary>
        [DataMember(IsRequired = true)]
        public Entity SettingEntity { get; set; }
    }
}
