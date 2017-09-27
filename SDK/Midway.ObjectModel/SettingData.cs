using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные настройки.
    /// </summary>
    [DataContract]
    public class SettingData
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
        public SettingValue Value { get; set; }
    }
}
