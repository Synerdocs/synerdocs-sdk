using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Формат содержимого
    /// </summary>
    [DataContract]
    public enum ContentFormat
    {
        /// <summary>
        /// Неизвестный формат
        /// </summary>
        [EnumMember]
        [Description("Неизвестный")]
        Unknown = 0,

        /// <summary>
        /// Формат XML
        /// </summary>
        [EnumMember]
        [Description("XML")]
        Xml = 1,

        /// <summary>
        /// Формат PDF
        /// </summary>
        [EnumMember]
        [Description("PDF")]
        Pdf = 2,

        /// <summary>
        /// Формат JSON
        /// </summary>
        [EnumMember]
        [Description("JSON")]
        Json = 3
    }
}
