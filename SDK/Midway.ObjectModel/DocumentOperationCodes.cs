using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Коды операций над документом.
    /// </summary>
    [Flags]
    [DataContract]
    public enum DocumentOperationCodes
    {
        /// <summary>
        /// Нет доступных операций.
        /// </summary>
        [EnumMember]
        [Description("Нет доступных операций")]
        None = 0,

        /// <summary>
        /// Отметить документ как прочитанный.
        /// </summary>
        [EnumMember]
        [Description("Отметить документ как прочитанный")]
        MarkAsRead = 1 << 0, // 1.

        /// <summary>
        /// Отметить документ как не прочитанный.
        /// </summary>
        [EnumMember]
        [Description("Отметить документ как непрочитанный")]
        MarkAsUnread = 1 << 1, // 2.

        /// <summary>
        /// Подписать документ.
        /// </summary>
        [EnumMember]
        [Description("Подписать документ")]
        Sign = 1 << 2, // 4.

        /// <summary>
        /// Отказать по документу.
        /// </summary>
        [EnumMember]
        [Description("Отказать по документу")]
        Reject = 1 << 3, // 8.

        /// <summary>
        /// Отправить исправление ЭСФ.
        /// </summary>
        [EnumMember]
        [Description("Отправить исправление ЭСФ")]
        SendRevision = 1 << 4, // 16.

        /// <summary>
        /// Отправить корректировку ЭСФ.
        /// </summary>
        [EnumMember]
        [Description("Отправить корректировку ЭСФ")]
        SendCorrection = 1 << 5, // 32.

        /// <summary>
        /// Удалить документ.
        /// </summary>
        [EnumMember]
        [Description("Удалить документ")]
        Delete = 1 << 6, // 64.

        /// <summary>
        /// Ответить на документ.
        /// </summary>
        [EnumMember]
        [Description("Ответить на документ")]
        Reply = 1 << 7, // 128.

        /// <summary>
        /// Распечатать документ.
        /// </summary>
        [EnumMember]
        [Description("Распечатать документ")]
        Print = 1 << 8, // 256.

        /// <summary>
        /// Загрузить документ.
        /// </summary>
        [EnumMember]
        [Description("Загрузить документ")]
        Download = 1 << 9, // 512.

        /// <summary>
        /// Просмотреть регламентные документы.
        /// </summary>
        [EnumMember]
        [Description("Просмотреть регламентные документы")]
        ViewRegulation = 1 << 10, // 1024.

        /// <summary>
        /// Подтвердить получение документа.
        /// </summary>
        [EnumMember]
        [Description("Подтвердить получение документа")]
        ConfirmReceipt = 1 << 11, // 2048.

        /// <summary>
        /// Переместить документ.
        /// </summary>
        [EnumMember]
        [Description("Переместить документ")]
        Move = 1 << 12, // 4096.

        /// <summary>
        /// Согласовать документ.
        /// </summary>
        [EnumMember]
        [Description("Согласовать документ")]
        Approve = 1 << 13, // 8192.

        /// <summary>
        /// Отказать в согласовании документа.
        /// </summary>
        [EnumMember]
        [Description("Отказать в согласовании документа")]
        Disapprove = 1 << 14, // 16384.

        /// <summary>
        /// Настроить права доступа на документ.
        /// </summary>
        [EnumMember]
        [Description("Настроить права доступа на документ")]
        Permissions = 1 << 15, // 32768.

        /// <summary>
        /// Переслать документ.
        /// </summary>
        [EnumMember]
        [Description("Переслать документ")]
        Forward = 1 << 16, // 65536.

        /// <summary>
        /// Аннулировать документ.
        /// </summary>
        [EnumMember]
        [Description("Аннулировать документ")]
        Revoke = 1 << 17, // 131072.

        /// <summary>
        /// Получить груз (для ТН/ТТН).
        /// </summary>
        [EnumMember]
        [Description("Получить груз (для ТН/ТТН)")]
        ReceiveCargo = 1 << 18, // 262144.

        /// <summary>
        /// Сдать груз (для ТН/ТТН).
        /// </summary>
        [EnumMember]
        [Description("Сдать груз (для ТН/ТТН)")]
        DeliverCargo = 1 << 19, // 524288.

        /// <summary>
        /// Подписать грузополучателем Транспортной накладной.
        /// </summary>
        [EnumMember]
        [Description("Подписать грузополучателем Транспортной накладной")]
        SignByConsignee = 1 << 20, // 1048576.

        /// <summary>
        /// Подписать перевозчиком Транспортной накладной.
        /// </summary>
        [EnumMember]
        [Description("Подписать перевозчиком Транспортной накладной")]
        SignByCarrier = 1 << 21, // 2097152.

        /// <summary>
        /// Изменить место доставки Транспортной накладной.
        /// </summary>
        [EnumMember]
        [Description("Изменить место доставки Транспортной накладной")]
        ChangeDeliveryPlace = 1 << 22, // 4194304.

        /// <summary>
        /// Скопировать документ(ы).
        /// </summary>
        [EnumMember]
        [Description("Скопировать документ(ы)")]
        Copy = 1 << 23, // 8388608.

        /// <summary>
        /// Заверить ПЭП грузополучателя Транспортной накладной.
        /// </summary>
        [EnumMember]
        [Description("Заверить ПЭП грузополучателя Транспортной накладной")]
        AssureConsigneeSimpleSignature = 1 << 24, // 16777216.

        /// <summary>
        /// Заверить ПЭП водителя о получении груза Транспортной накладной.
        /// </summary>
        [EnumMember]
        [Description("Заверить ПЭП водителя о получении груза Транспортной накладной")]
        AssureDriverReceiveCargoSimpleSignature = 1 << 25, //33554432.

        /// <summary>
        /// Заверить ПЭП водителя о сдаче груза Транспортной накладной.
        /// </summary>
        [EnumMember]
        [Description("Заверить ПЭП водителя о сдаче груза Транспортной накладной")]
        AssureDriverDeliverCargoSimpleSignature = 1 << 26, //67108864.
    }
}
