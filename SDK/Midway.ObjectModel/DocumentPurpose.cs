using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Назначение документа.
    /// </summary>
    [DataContract]
    public enum DocumentPurpose
    {
        /// <summary>
        /// Не задано.
        /// </summary>
        [Description("Не задано")]
        None = 0,

        /// <summary>
        /// Исправление.
        /// </summary>
        [EnumMember]
        [Description("Исправление")]
        Revision = 1,

        /// <summary>
        /// Корректировка.
        /// </summary>
        [EnumMember]
        [Description("Корректировка")]
        Correction = 2,

        /// <summary>
        /// Подтверждение.
        /// </summary>
        [EnumMember]
        [Description("Подтверждение")]
        Confirmation = 3,

        /// <summary>
        /// Отклонение / Отказ.
        /// </summary>
        [EnumMember]
        [Description("Отклонение")]
        Rejection = 4,

        /// <summary>
        /// Аннулирование.
        /// </summary>
        [EnumMember]
        [Description("Аннулирование")]
        Revocation = 5,

        /// <summary>
        /// Получение.
        /// </summary>
        [EnumMember]
        [Description("Получение")]
        Reception = 6,

        // До 10 зарезервировано под общие функции документа.

        /// <summary>
        /// Счет-фактура.
        /// </summary>
        [EnumMember]
        [Description("Счет-фактура")]
        Invoice = 11,

        /// <summary>
        /// Отгрузка товаров (выполнение работ), передача имущественных прав (оказание услуг).
        /// </summary>
        [EnumMember]
        [Description("Передача")]
        Transfer = 12,

        /// <summary>
        /// Маркировка товаров.
        /// </summary>
        [EnumMember]
        [Description("Маркировка товара")]
        GoodsMarking = 13,

        /// <summary>
        /// Прослеживаемость товара.
        /// </summary>
        [EnumMember]
        [Description("Прослеживаемость товара")]
        GoodsTraceability = 14,

        /// <summary>
        /// Погрузка.
        /// </summary>
        [EnumMember]
        [Description("Погрузка")]
        Loading = 15,

        /// <summary>
        /// Разгрузка.
        /// </summary>
        [EnumMember]
        [Description("Разгрузка")]
        Unloading = 16,

        /// <summary>
        /// Заверение.
        /// </summary>
        [EnumMember]
        [Description("Заверение")]
        Assurance = 17,
    }
}
