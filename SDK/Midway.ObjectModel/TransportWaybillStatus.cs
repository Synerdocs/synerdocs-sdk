using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус транспортной накладной (ТрН).
    /// </summary>
    [DataContract]
    public enum TransportWaybillStatus
    {
        /// <summary>
        /// Перевозка завершена.
        /// </summary>
        [EnumMember]
        [Description("Перевозка завершена")]
        Signed = 1,

        /// <summary>
        /// Запрошено уточнение.
        /// </summary>
        [EnumMember]
        [Description("Запрошено уточнение")]
        Rejected = 2,

        /// <summary>
        /// Ожидается прием груза для доставки Водителем.
        /// </summary>
        [EnumMember]
        [Description("Ожидается прием груза для доставки Водителем")]
        WaitingForCargoReception = 3,

        /// <summary>
        /// Ожидается подтверждение сдачи груза Водителем.
        /// </summary>
        [EnumMember]
        [Description("Ожидается подтверждение сдачи груза Водителем")]
        WaitingForCargoDelivery = 4,

        /// <summary>
        /// Ожидается принятие Грузополучателем.
        /// </summary>
        [EnumMember]
        [Description("Ожидается принятие Грузополучателем")]
        WaitingForSignByConsignee = 5,

        /// <summary>
        /// Ожидается подтверждение перевозки Перевозчиком (ТЛК).
        /// </summary>
        [EnumMember]
        [Description("Ожидается подтверждение перевозки Перевозчиком (ТЛК)")]
        WaitingForSignByCarrier = 6,

        /// <summary>
        /// Отказано в приеме груза Грузополучателем.
        /// </summary>
        [EnumMember]
        [Description("Отказано в приеме груза Грузополучателем")]
        RejectedByConsignee = 7,

        /// <summary>
        /// Перевозчик (ТЛК) отказал в подтверждении.
        /// </summary>
        [EnumMember]
        [Description("Перевозчик (ТЛК) отказал в подтверждении")]
        RejectedByCarrier = 8,
    }
}
