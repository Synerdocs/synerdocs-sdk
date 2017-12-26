using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Тип оператора составного фильтра.
    /// </summary>
    [DataContract]
    public enum CompositeFilterOperatorType
    {
        /// <summary>
        /// И.
        /// </summary>
        [EnumMember]
        [Description("И")]
        And = 1,

        /// <summary>
        /// ИЛИ.
        /// </summary>
        [EnumMember]
        [Description("ИЛИ")]
        Or = 2
    }
}
