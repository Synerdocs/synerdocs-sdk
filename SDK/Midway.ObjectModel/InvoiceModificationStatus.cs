using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус изменения счета-фактуры.
    /// </summary>
    [DataContract]
    public enum InvoiceModificationStatus
    {
        /// <summary>
        /// Счет-фактура не изменен.
        /// </summary>
        [EnumMember]
        Unchanged = 0,

        /// <summary>
        /// Выставлен исправленный счет-фактура.
        /// </summary>
        [EnumMember]
        Revised = 1,

        /// <summary>
        /// Выставлен корректировочный счет-фактура.
        /// </summary>
        [EnumMember]
        Corrected = 2,
    }
}
