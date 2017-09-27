using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Пол.
    /// </summary>
    [DataContract]
    public enum Gender
    {
        /// <summary>
        /// Мужской.
        /// </summary>
        [EnumMember]
        [Description("Мужской")]
        Male = 1,

        /// <summary>
        /// Женский.
        /// </summary>
        [EnumMember]
        [Description("Женский")]
        Female = 2,

        /// <summary>
        /// Неприменимо.
        /// </summary>
        [EnumMember]
        [Description("Неприменимо")]
        Unapplicable = 3
    }
}
