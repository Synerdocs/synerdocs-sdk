using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Типы тегов для документа
    /// </summary>
    [DataContract]
    public enum DocumentTagType
    {
        /// <summary>
        /// Пользовательский тег
        /// </summary>
        [Description("Пользовательский")]
        UserDefined = 1,

        /// <summary>
        /// Тег "Согласовано"
        /// </summary>
        [EnumMember]
        [Description("Согласовано")]
        Approved = 2,

        /// <summary>
        /// Тег "Отказано в согласовании"
        /// </summary>
        [EnumMember]
        [Description("Отказано в согласовании")]
        Disapproved = 3
    }
}
