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
        ChangedDeliveryPlace = 11
    }
}
