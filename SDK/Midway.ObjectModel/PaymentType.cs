using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип платежа.
    /// </summary>
    [DataContract]
    public enum PaymentType
    {
        /// <summary>
        /// Пусто.
        /// </summary>
        [EnumMember]
        [Description("Пусто")]
        Empty = 0,

        /// <summary>
        /// Срочно.
        /// </summary>
        [EnumMember]
        [Description("Срочно")]
        Urgently = 1
    }
}
