using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус подписания документа получателем
    /// </summary>
    [DataContract]
    public enum DocumentSignStatus
    {
        /// <summary>
        /// Подпись получателя не требуется
        /// </summary>
        [Description("Подпись не требуется")]
        [EnumMember]
        NoSignNeeded = 0x00,

        /// <summary>
        /// Ожидается подпись получателя
        /// </summary>
        [Description("Требуется подпись")]
        [EnumMember]
        WaitingForSign = 0x01,

        /// <summary>
        /// Документ подписан получателем
        /// </summary>
        [Description("Подписан")]
        [EnumMember]
        Signed = 0x02,

        /// <summary>
        /// Получатель отказался подписывать документ
        /// </summary>
        [Description("Отказано")]
        [EnumMember]
        SignRejected = 0x03,
    }
}
