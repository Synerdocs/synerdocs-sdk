using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус документооборота получателя
    /// </summary>
    [DataContract]
    public enum RecipientFlowStatus
    {
        /// <summary>
        /// Подпись получателя не требуется
        /// </summary>
        [Description("Подпись получателя не требуется")]
        [EnumMember]
        NoSignNeeded = 0,

        /// <summary>
        /// Требуется подпись получателя
        /// </summary>
        [Description("Требуется подпись получателя")]
        [EnumMember]
        SignRequested = 1,

        /// <summary>
        /// Документ подписан получателем
        /// </summary>
        [Description("Документ подписан получателем")]
        [EnumMember]
        SignReceived = 2,

        /// <summary>
        /// Получатель отказался от подписания документа
        /// </summary>
        [Description("Получатель отказался от подписания документа")]
        [EnumMember]
        SignRejected = 3,
    }
}
