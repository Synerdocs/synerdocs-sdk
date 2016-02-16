using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус сообщения
    /// </summary>
    [DataContract]
    public enum MessageStatus : short
    {
        /// <summary>
        /// Отправлено
        /// </summary>
        [EnumMember]
        Sent = 0x0,

        /// <summary>
        /// Ожидается отправление в очереди
        /// </summary>
        [EnumMember]
        Pending = 0x1,

        /// <summary>
        /// Не удалось отправить сообщение из-за ошибки
        /// </summary>
        [EnumMember]
        DeliveryError = 0x2,

        /// <summary>
        /// Получено сервисом\Не обработано
        /// </summary>
        [EnumMember]
        NotTreated = 0x3
    }
}