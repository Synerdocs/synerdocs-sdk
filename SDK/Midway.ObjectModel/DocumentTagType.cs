using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Типы тегов для документа.
    /// </summary>
    [DataContract]
    public enum DocumentTagType
    {
        /// <summary>
        /// Пользовательский тег.
        /// </summary>
        [EnumMember]
        [Description("Пользовательский")]
        UserDefined = 1,

        /// <summary>
        /// Тег "Согласовано".
        /// </summary>
        [EnumMember]
        [Description("Согласовано")]
        Approved = 2,

        /// <summary>
        /// Тег "Отказано в согласовании".
        /// </summary>
        [EnumMember]
        [Description("Отказано в согласовании")]
        Disapproved = 3,

        /// <summary>
        /// Тег "Перемещен".
        /// </summary>
        [EnumMember]
        [Description("Перемещен")]
        Moved = 4,

        /// <summary>
        /// Тег "Исправлен".
        /// </summary>
        [EnumMember]
        [Description("Исправлен")]
        Revised = 5,

        /// <summary>
        /// Тег "Откорректирован".
        /// </summary>
        [EnumMember]
        [Description("Откорректирован")]
        Corrected = 6,

        /// <summary>
        /// Тег "Получен груз для доставки".
        /// </summary>
        [EnumMember]
        [Description("Получен груз для доставки")]
        CargoReceived = 7,

        /// <summary>
        /// Тег "Груз сдан".
        /// </summary>
        [EnumMember]
        [Description("Груз сдан")]
        CargoDelivered = 8,

        /// <summary>
        /// Тег "Подписан грузополучателем".
        /// </summary>
        [EnumMember]
        [Description("Подписан грузополучателем")]
        SignedByConsignee = 9,

        /// <summary>
        /// Тег "Подписан перевозчиком".
        /// </summary>
        [EnumMember]
        [Description("Подписан перевозчиком")]
        SignedByCarrier = 10,

        /// <summary>
        /// Тег "Изменен пункт доставки".
        /// </summary>
        [EnumMember]
        [Description("Изменен пункт доставки")]
        ChangedDeliveryPlace = 11,

        /// <summary>
        /// Тег "ПЭП грузополучателя заверена".
        /// </summary>
        [EnumMember]
        [Description("ПЭП грузополучателя заверена")]
        AssuredConsigneeSimpleSignature = 12,

        /// <summary>
        /// Тег "ПЭП водителя о получении груза заверена".
        /// </summary>
        [EnumMember]
        [Description("ПЭП водителя о получении груза заверена")]
        AssuredDriverReceiveCargoSimpleSignature = 13,

        /// <summary>
        /// Тег "ПЭП водителя о сдаче груза заверена".
        /// </summary>
        [EnumMember]
        [Description("ПЭП водителя о сдаче груза заверена")]
        AssuredDriverDeliverCargoSimpleSignature = 14,

        /// <summary>
        /// Тег "Изменен водитель и/или ТС".
        /// </summary>
        [EnumMember]
        [Description("Изменен водитель и/или ТС")]
        ChangedDriverOrVehicle = 15,

        /// <summary>
        /// Тег "Подписан экспедитором".
        /// </summary>
        [EnumMember]
        [Description("Подписан экспедитором")]
        SignedByExpeditor = 16,

        /// <summary>
        /// Подписан грузоотправителем.
        /// </summary>
        [EnumMember]
        [Description("Подписан грузоотправителем")]
        SignedByConsignor = 17,

        /// <summary>
        /// Груз принят грузополучателем.
        /// </summary>
        [EnumMember]
        [Description("Груз принят грузополучателем")]
        CargoAcceptedByConsignee = 18,

        /// <summary>
        /// Получение груза подписано перевозчиком.
        /// </summary>
        [EnumMember]
        [Description("Получение груза подписано перевозчиком")]
        CargoReceptionSignedByCarrier = 19,

        /// <summary>
        /// Доставка груза подписана перевозчиком.
        /// </summary>
        [EnumMember]
        [Description("Доставка груза подписана перевозчиком")]
        CargoDeliverySignedByCarrier = 20,
    }
}
