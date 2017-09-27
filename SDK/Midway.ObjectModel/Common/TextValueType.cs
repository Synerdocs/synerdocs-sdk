using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Тип значение, представленного простым текстом.
    /// </summary>
    [DataContract]
    public enum TextValueType
    {
        /// <summary>
        /// Значение типа <c>String</c> - строка.
        /// </summary>
        [Description("Строковый тип")]
        [EnumMember]
        String = 0,

        /// <summary>
        /// Значение типа <c>Boolean</c> - <c>true</c> или <c>false</c>.
        /// </summary>
        [Description("Логический тип")]
        [EnumMember]
        Boolean = 1,
    }
}
