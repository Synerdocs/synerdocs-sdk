using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Режим получения документооборота
    /// </summary>
    [DataContract]
    public enum DocumentFlowResultMode
    {
        /// <summary>
        /// Не получать документооборот
        /// </summary>
        [Description("Не получать документооборот")]
        [EnumMember]
        None = 0,

        /// <summary>
        /// Только документооборот
        /// </summary>
        [Description("Только документооборот")]
        [EnumMember]
        FlowOnly = 1,

        /// <summary>
        /// Документооборот с информацией об организациях
        /// и подразделениях отправителя и получателя
        /// </summary>
        [Description("Документооборот с информацией об организациях и подразделениях отправителя и получателя")]
        [EnumMember]
        FullInfo = 2,
    }
}
