using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип документооборота (для фильтрации)
    /// </summary>
    [DataContract]
    public enum DocumentFlowType
    {
        /// <summary>
        /// Документооборот для документа отправленного с подписью
        /// </summary>
        [Description("С подписью")]
        [EnumMember]
        SentSigned = 0,

        /// <summary>
        /// Документооборот для документа отправленного без подписи
        /// </summary>
        [Description("Без подписи")]
        [EnumMember]
        SentUnsigned = 1,

        /// <summary>
        /// Документооборот для документа созданного из неподписанного
        /// </summary>
        [Description("Подготовлен")]
        [EnumMember]
        SentPrepared = 2,

        /// <summary>
        /// Документооборот для пересланного документа
        /// </summary>
        [Description("Переслан")]
        [EnumMember]
        SentForward = 3,
    }
}
