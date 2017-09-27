using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип квалификации подписи.
    /// </summary>
    [DataContract]
    public enum SignQualificationType
    {
        /// <summary>
        /// Директор.
        /// </summary>
        [EnumMember]
        [Description("Директор")]
        Director = 1,

        /// <summary>
        /// Бухгалтер.
        /// </summary>
        [EnumMember]
        [Description("Бухгалтер")]
        Accountant = 2,

        /// <summary>
        /// Директор и бухгалтер.
        /// </summary>
        [EnumMember]
        [Description("Директор и бухгалтер")]
        DirectorAndAccountant = 3,

        /// <summary>
        /// Ответственный исполнитель.
        /// </summary>
        [EnumMember]
        [Description("Ответственный исполнитель")]
        ResponsiblePerson = 4,
    }
}
