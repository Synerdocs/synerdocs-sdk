using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус организации как абонента EDI
    /// </summary>
    [DataContract]
    public enum EdiSubscriberStatus
    {
        /// <summary>
        /// Не зарегистрирована как абонент EDI
        /// </summary>
        [EnumMember]
        [Description("Не зарегистрирована как абонент EDI")]
        NotRegistered = 0,

        /// <summary>
        /// Ожидается регистрация как абонента
        /// </summary>
        [EnumMember]
        [Description("Ожидается регистрация как абонента EDI")]
        Pending = 1,

        /// <summary>
        /// Зарегистрирована как абонент EDI
        /// </summary>
        [EnumMember]
        [Description("Зарегистрирована как абонент EDI")]
        Registered = 2,
    }
}
