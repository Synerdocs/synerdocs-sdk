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
        MarkAsRead = 1 << 1, // 1.

        /// <summary>
        /// Отметить документ как не прочитанный.
        /// </summary>
        [EnumMember]
        [Description("Отметить документ как не прочитанный")]
        MarkAsUnread = 1 << 2, // 2.

        /// <summary>
        /// Подписать документ.
        /// </summary>
        [EnumMember]
        [Description("Подписать документ")]
        Sign = 1 << 3, // 4.

        /// <summary>
        /// Отказать по документу.
        /// </summary>
        [EnumMember]
        [Description("Отказать по документу")]
        Reject = 1 << 4, // 8.

        /// <summary>
        /// Отправить исправление ЭСФ.
        /// </summary>
        [EnumMember]
        [Description("Отправить исправление ЭСФ")]
        SendRevision = 1 << 5, // 16.

        /// <summary>
        /// Отправить корректировку ЭСФ.
        /// </summary>
        [EnumMember]
        [Description("Отправить корректировку ЭСФ")]
        SendCorrection = 1 << 6, // 32.

        /// <summary>
        /// Удалить документ.
        /// </summary>
        [EnumMember]
        [Description("Удалить документ")]
        Delete = 1 << 7, // 64.

        /// <summary>
        /// Ответить на документ.
        /// </summary>
        [EnumMember]
        [Description("Ответить на документ")]
        Reply = 1 << 8, // 128.

        /// <summary>
        /// Распечатать документ.
        /// </summary>
        [EnumMember]
        [Description("Распечатать документ")]
        Print = 1 << 9, // 256.

        /// <summary>
        /// Загрузить документ.
        /// </summary>
        [EnumMember]
        [Description("Загрузить документ")]
        Download = 1 << 10, // 512.

        /// <summary>
        /// Просмотреть регламентные документы.
        /// </summary>
        [EnumMember]
        [Description("Просмотреть регламентные документы")]
        ViewRegulation = 1 << 11, // 1024.

        /// <summary>
        /// Подтвердить получение документа.
        /// </summary>
        [EnumMember]
        [Description("Подтвердить получение документа")]
        ConfirmReceipt = 1 << 12, // 2048.

        /// <summary>
        /// Переместить документ.
        /// </summary>
        [EnumMember]
        [Description("Переместить документ")]
        Move = 1 << 13, // 4096.

        /// <summary>
        /// Согласовать документ.
        /// </summary>
        [EnumMember]
        [Description("Согласовать документ")]
        Approve = 1 << 14, // 8192.

        /// <summary>
        /// Отказать в согласовании документа.
        /// </summary>
        [EnumMember]
        [Description("Отказать в согласовании документа")]
        Disapprove = 1 << 15, // 16384.

        /// <summary>
        /// Настроить права доступа на документ.
        /// </summary>
        [EnumMember]
        [Description("Настроить права доступа на документ")]
        Permissions = 1 << 16, // 32768.

        /// <summary>
        /// Переслать документ.
        /// </summary>
        [EnumMember]
        [Description("Переслать документ")]
        Forward = 1 << 17, // 65536.

        /// <summary>
        /// Аннулировать документ.
        /// </summary>
        [EnumMember]
        [Description("Аннулировать документ")]
        Revoke = 1 << 18, // 131072.

        /// <summary>
        /// Получить груз (для ТН/ТТН).
        /// </summary>
        [EnumMember]
        [Description("Получить груз (для ТН/ТТН)")]
        ReceiveCargo = 1 << 19, // 262144.

        /// <summary>
        /// Сдать груз (для ТН/ТТН).
        /// </summary>
        [EnumMember]
        [Description("Сдать груз (для ТН/ТТН)")]
        DeliverCargo = 1 << 20, // 524288.

        /// <summary>
        /// Подписать грузополучателем Транспортной накладной.
        /// </summary>
        [EnumMember]
        [Description("Подписать грузополучателем Транспортной накладной")]
        SignByConsignee = 1 << 21, // 1048576.

        /// <summary>
        /// Подписать перевозчиком Транспортной накладной.
        /// </summary>
        [EnumMember]
        [Description("Подписать перевозчиком Транспортной накладной")]
        SignByCarrier = 1 << 22, // 2097152.
    }
}
