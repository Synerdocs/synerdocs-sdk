using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус создания усовершенствованной подписи.
    /// </summary>
    [DataContract]
    [Flags]
    public enum EnhancedSignCreateStatus
    {
        /// <summary>
        /// Усовершенствованная подпись находится в процессе создания.
        /// </summary>
        [EnumMember]
        [Description("Усовершенствованная подпись находится в процессе создания")]
        InProgress = 0x00,

        /// <summary>
        /// Усовершенствованная подпись создана.
        /// </summary>
        [EnumMember]
        [Description("Усовершенствованная подпись создана")]
        Success = 0x01,

        /// <summary>
        /// Не удалось создать усовершенствованную подпись.
        /// </summary>
        [EnumMember]
        [Description("Не удалось создать усовершенствованную подпись")]
        Failed = 0x02
    }
}
