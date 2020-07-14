using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Версия формата титула смены водителя и/или ТС транспортной накладной.
    /// </summary>
    [DataContract]
    public enum TransportWaybillDriverOrVehicleChangeTitleFormatVersion
    {
        /// <summary>
        /// Не указана.
        /// </summary>
        [EnumMember]
        [Description("Не указана")]
        None = 0,

        /// <summary>
        /// Версия 1.00.
        /// </summary>
        [EnumMember]
        [Description("Версия 1.00")]
        V100 = 1,
    }
}
