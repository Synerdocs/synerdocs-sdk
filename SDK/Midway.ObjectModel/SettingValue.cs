using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Значение настройки.
    /// </summary>
    [DataContract]
    public class SettingValue
    {
        /// <summary>
        /// Значение в виде строки.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ValueText { get; set; }

        /// <summary>
        /// Тип значения.
        /// </summary>
        [DataMember]
        public EnumValue ValueType { get; set; }
    }
}
