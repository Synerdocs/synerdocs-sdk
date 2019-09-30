using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус товарно-транспортной накладной (ТТН).
    /// </summary>
    [DataContract]
    public enum GoodsTransportWaybillStatus
    {
        /// <summary>
        /// Перевозка завершена.
        /// </summary>
        [EnumMember]
        [Description("Перевозка завершена")]
        Signed = 1,

        /// <summary>
        /// Ожидается прием груза для доставки Водителем.
        /// </summary>
        [EnumMember]
        [Description("Ожидается прием груза для доставки Водителем")]
        WaitingForCargoReception = 2,

        /// <summary>
        /// Ожидается подтверждение сдачи груза Водителем.
        /// </summary>
        [EnumMember]
        [Description("Ожидается подтверждение сдачи груза Водителем")]
        WaitingForCargoDelivery = 3,

        /// <summary>
        /// Ожидается принятие Грузополучателем.
        /// </summary>
        [EnumMember]
        [Description("Ожидается принятие Грузополучателем")]
        WaitingForSignByConsignee = 4,

        /// <summary>
        /// Отказано в приеме груза Грузополучателем.
        /// </summary>
        [EnumMember]
        [Description("Отказано в приеме груза Грузополучателем")]
        RejectedByConsignee = 5
    }
}
