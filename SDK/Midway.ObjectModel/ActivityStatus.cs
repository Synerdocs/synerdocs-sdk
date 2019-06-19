using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус работы.
    /// </summary>
    [DataContract]
    public enum ActivityStatus
    {
        /// <summary>
        /// Действующий.
        /// </summary>
        [EnumMember]
        [Description("Действующий")]
        Active = 1,

        /// <summary>
        /// Недействующий.
        /// </summary>
        [EnumMember]
        [Description("Недействующий")]
        Inactive = 2
    }
}