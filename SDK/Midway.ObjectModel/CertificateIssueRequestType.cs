using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип заявки на издание сертификата.
    /// </summary>
    [DataContract]
    public enum CertificateIssueRequestType
    {
        /// <summary>
        /// Регистрация.
        /// </summary>
        [EnumMember]
        [Description("Регистрация")]
        Registration = 1,

        /// <summary>
        /// Изменение.
        /// </summary>
        [EnumMember]
        [Description("Изменение")]
        Change = 2,

        /// <summary>
        /// Продление.
        /// </summary>
        [EnumMember]
        [Description("Продление")]
        Prolongation = 3,

        /// <summary>
        /// Восстановление.
        /// </summary>
        [EnumMember]
        [Description("Восстановление")]
        Recovery = 4,

        /// <summary>
        /// Отключение.
        /// </summary>
        [EnumMember]
        [Description("Отключение")]
        Disabling = 5,

        /// <summary>
        /// Информирование.
        /// </summary>
        [EnumMember]
        [Description("Информирование")]
        Informing = 6,
    }
}
