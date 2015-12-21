using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип документооборота
    /// </summary>
    [DataContract]
    public enum FlowType
    {
        /// <summary>
        /// Документооборот для документа, отправленного с подписью
        /// </summary>
        [Description("Документооборот для документа, отправленного с подписью")]
        [EnumMember]
        SentSigned = 0,

        /// <summary>
        /// Документооборот для документа, отправленного без подписи
        /// </summary>
        [Description("Документооборот для документа, отправленного без подписи")]
        [EnumMember]
        SentUnsigned = 1,

        /// <summary>
        /// Документооборот для пересланного документа
        /// </summary>
        [Description("Документооборот для пересланного документа")]
        [EnumMember]
        SentForward = 2,

        /// <summary>
        /// Внутренний документооборот
        /// </summary>
        [Description("Внутренний документооборот")]
        [EnumMember]
        SentInternal = 3,
    }
}
