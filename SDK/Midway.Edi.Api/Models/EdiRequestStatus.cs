using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Статус обработки заявки на регистрацию точки доставки
    /// </summary>
    [DataContract]
    public enum EdiRequestStatus
    {
        /// <summary>
        /// Заявка отправлена
        /// </summary>
        [EnumMember]
        [Description("Заявка отправлена")]
        RequestSent = 0,

        /// <summary>
        /// Данные зарегистрированы
        /// </summary>
        [EnumMember]
        [Description("Данные зарегистрированы")]
        DataRegistered = 1,

        /// <summary>
        /// Ожидается обновление
        /// </summary>
        [EnumMember]
        [Description("Ожидается обновление")]
        PendingUpdate = 2,

        /// <summary>
        /// Заявка отменена
        /// </summary>
        [EnumMember]
        [Description("Заявка отменена")]
        RequestCanceled = 3,
    }
}
