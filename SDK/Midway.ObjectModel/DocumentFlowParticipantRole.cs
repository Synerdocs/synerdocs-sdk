using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Роль участника документооборота.
    /// </summary>
    [DataContract]
    public enum DocumentFlowParticipantRole
    {
        /// <summary>
        /// Роль не указана.
        /// </summary>
        [EnumMember]
        [Description("Роль не указана")]
        None = 0,

        /// <summary>
        /// Грузоотправитель.
        /// </summary>
        [EnumMember]
        [Description("Грузоотправитель")]
        Consignor = 1,

        /// <summary>
        /// Грузополучатель.
        /// </summary>
        [EnumMember]
        [Description("Грузополучатель")]
        Consignee = 2,

        /// <summary>
        /// Водитель.
        /// </summary>
        [EnumMember]
        [Description("Водитель")]
        Driver = 3,

        /// <summary>
        /// Перевозчик.
        /// </summary>
        [EnumMember]
        [Description("Перевозчик")]
        Carrier = 4,

        /// <summary>
        /// Наблюдатель.
        /// </summary>
        [EnumMember]
        [Description("Наблюдатель")]
        Observer = 5,

        /// <summary>
        /// Экспедитор.
        /// </summary>
        [EnumMember]
        [Description("Экспедитор")]
        Expeditor = 6,
    }
}
