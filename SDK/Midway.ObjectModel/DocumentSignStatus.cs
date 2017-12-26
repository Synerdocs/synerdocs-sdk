using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус подписания документа получателем.
    /// </summary>
    [DataContract]
    public enum DocumentSignStatus
    {
        /// <summary>
        /// Подпись получателя не требуется.
        /// </summary>
        [Description("Подпись не требуется")]
        [EnumMember]
        NoSignNeeded = 0,

        /// <summary>
        /// Ожидается подпись получателя.
        /// </summary>
        [Description("Требуется подпись")]
        [EnumMember]
        WaitingForSign = 1,

        /// <summary>
        /// Документ подписан получателем.
        /// </summary>
        [Description("Подписан")]
        [EnumMember]
        Signed = 2,

        /// <summary>
        /// Получатель отказался подписывать документ.
        /// </summary>
        [Description("Отказано")]
        [EnumMember]
        SignRejected = 3,
    }
}
