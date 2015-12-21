using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус документооборота отправителя
    /// </summary>
    [DataContract]
    public enum SenderFlowStatus
    {
        /// <summary>
        /// Отправлен подписанный документ
        /// </summary>
        [Description("Отправлен подписанный документ")]
        [EnumMember]
        SentSigned = 0,

        /// <summary>
        /// Документ отправлен без подписи
        /// </summary>
        [Description("Документ отправлен без подписи")]
        [EnumMember]
        SentUnsigned = 1,
    }
}
