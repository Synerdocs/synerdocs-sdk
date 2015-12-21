using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус подписания документа несколькими получателями
    /// </summary>
    [DataContract]
    public enum DocumentMultiSignStatus
    {
        /// <summary>
        /// Подпись получателей не требуется
        /// </summary>
        [Description("Подпись не требуется")]
        [EnumMember]
        NoSignNeeded = 0x00,

        /// <summary>
        /// Ожидается подпись получателей
        /// </summary>
        [Description("Требуется подпись")]
        [EnumMember]
        WaitingForSign = 0x01,

        /// <summary>
        /// Документ подписан всеми получателями
        /// </summary>
        [Description("Подписан всеми получателями")]
        [EnumMember]
        Signed = 0x02,

        /// <summary>
        /// Получатель отказался подписывать документ
        /// </summary>
        [Description("Отказано")]
        [EnumMember]
        SignRejected = 0x03,

        /// <summary>
        /// Документ подписан несколькими, но не всеми получателями
        /// </summary>
        [Description("Подписан несколькими, но не всеми получателями")]
        [EnumMember]
        PartlySigned = 0x04,
    }
}
