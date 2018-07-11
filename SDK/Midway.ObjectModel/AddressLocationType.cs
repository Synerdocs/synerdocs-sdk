using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип записи адреса.
    /// </summary>
    [DataContract]
    public enum AddressLocationType
    {
        /// <summary>
        /// Адрес в РФ.
        /// </summary>
        [EnumMember]
        [Description("Адрес в РФ")]
        AddressRF = 0,

        /// <summary>
        /// Неструктурированный адрес.
        /// </summary>
        [EnumMember]
        [Description("Неструктурированный адрес")]
        UnstructuredAddress = 1,

        /// <summary>
        /// Код ГАР.
        /// </summary>
        [EnumMember]
        [Description("Код ГАР")]
        AddressByCode = 2,
    }
}
