using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Режим отправки сообщения черновика
    /// </summary>
    [DataContract]
    public enum DraftMessageSendMode
    {
        /// <summary>
        /// Отправка внешнему контрагенту
        /// </summary>
        [Description("Отправка внешнему контрагенту")]
        [EnumMember]
        External = 0,

        /// <summary>
        /// Отправка внутреннему подразделению
        /// </summary>
        [Description("Отправка внутреннему подразделению")]
        [EnumMember]
        Internal = 1,
    }
}
