using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип участника ЭДО транспортной накладной.
    /// </summary>
    [DataContract]
    public enum TransportWaybillInterchangeParticipantType
    {
        /// <summary>
        /// Не указан.
        /// </summary>
        [Description("Не указан")]
        None = 0,

        /// <summary>
        /// Грузоотправитель.
        /// </summary>
        [EnumMember]
        [Description("Грузоотправитель")]
        Consignor = 1,

        /// <summary>
        /// Перевозчик.
        /// </summary>
        [EnumMember]
        [Description("Перевозчик")]
        Carrier = 2,

        /// <summary>
        /// Водитель.
        /// </summary>
        [EnumMember]
        [Description("Водитель")]
        Driver = 3,

        /// <summary>
        /// Грузополучатель.
        /// </summary>
        [EnumMember]
        [Description("Грузополучатель")]
        Consigee = 4,
    }
}
