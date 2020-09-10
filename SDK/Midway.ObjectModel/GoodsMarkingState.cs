using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Состояние товарной маркировки документа.
    /// </summary>
    [DataContract]
    public enum GoodsMarkingState
    {
        /// <summary>
        /// Значение не определено.
        /// </summary>
        [EnumMember]
        [Description("Не определено")]
        Undefined = 0,

        /// <summary>
        /// Состояние, возникающее, когда ожидается отправка кодов маркировки в ГИС МТ.
        /// </summary>
        [EnumMember]
        [Description("Готовится отправка в ГИС МТ")]
        WaitingSend = 1,

        /// <summary>
        /// Состояние, возникающее, когда коды маркировки были доставлены в ГИС МТ.
        /// </summary>
        [EnumMember]
        [Description("ГИС МТ: Обработка")]
        Delivered = 2,

        /// <summary>
        /// Состояние, возникающее, когда коды маркировки не были приняты ГИС МТ.
        /// </summary>
        [EnumMember]
        [Description("ГИС МТ: Ошибка при обработке")]
        Rejected = 3,

        /// <summary>
        /// Состояние, возникающее, когда коды маркировки были приняты ГИС МТ.
        /// </summary>
        [EnumMember]
        [Description("ГИС МТ: Успешная обработка")]
        Accepted = 4,
    }
}
