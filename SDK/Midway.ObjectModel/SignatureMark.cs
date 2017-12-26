using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Признак подписи.
    /// </summary>
    [DataContract]
    public enum SignatureMark
    {
        /// <summary>
        /// Признак не указан.
        /// </summary>
        [EnumMember]
        [Description("Признак не указан")]
        None = 0,

        /// <summary>
        /// Груз получен.
        /// </summary>
        [EnumMember]
        [Description("Груз получен")]
        CargoReceived = 1,

        /// <summary>
        /// Груз сдан.
        /// </summary>
        [EnumMember]
        [Description("Груз сдан")]
        CargoDelivered = 2,
    }
}
