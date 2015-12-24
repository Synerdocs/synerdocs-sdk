using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип адреса
    /// </summary>
    [DataContract]
    public enum AddressType : byte
    {
        /// <summary>
        /// Неизвестно (для внутреннего использования - нет в API)
        /// </summary>
        [Description("Неизвестно")]
        Unknown = 0x0,

        /// <summary>
        /// Юридический адрес (для ЮЛ и ИП)
        /// </summary>
        [EnumMember]
        [Description("Юридический адрес")]
        Legal = 0x1,

        /// <summary>
        /// Почтовый адрес (для ЮЛ и ИП)
        /// </summary>
        [EnumMember]
        [Description("Почтовый адрес")]
        Mailing = 0x2,

        /// <summary>
        /// Адрес регистрации (для ФЛ)
        /// </summary>
        [EnumMember]
        [Description("Адрес регистрации")]
        Registration = 0x3,
    }
}
