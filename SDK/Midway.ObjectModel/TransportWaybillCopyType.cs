using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип экземпляра транспортной накладной.
    /// </summary>
    [DataContract]
    public enum TransportWaybillCopyType
    {
        /// <summary>
        /// Не указан.
        /// </summary>
        [Description("Не указан")]
        None = 0,

        /// <summary>
        /// Первый.
        /// </summary>
        [EnumMember]
        [Description("Первый")]
        First = 1,

        /// <summary>
        /// Второй.
        /// </summary>
        [EnumMember]
        [Description("Второй")]
        Second = 2,

        /// <summary>
        /// Третий.
        /// </summary>
        [EnumMember]
        [Description("Третий")]
        Third = 3,

        /// <summary>
        /// Четвертый.
        /// </summary>
        [EnumMember]
        [Description("Четвертый")]
        Fourth = 4,
    }
}
