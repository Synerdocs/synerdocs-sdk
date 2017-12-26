using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип документа.
    /// </summary>
    [DataContract]
    public enum TitleType
    {
        /// <summary>
        /// Акт выполненных работ.
        /// </summary>
        [EnumMember]
        Act,

        /// <summary>
        /// Товарная накладная.
        /// </summary>
        [EnumMember]
        Torg12
    }
}
