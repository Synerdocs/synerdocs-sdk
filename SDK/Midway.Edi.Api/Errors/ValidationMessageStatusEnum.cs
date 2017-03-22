using System.Runtime.Serialization;
using Midway.Edi.Api.Common;

namespace Midway.Edi.Api.Errors
{
    /// <summary>
    /// Статус сообщения валидации в виде объекта перечисления
    /// </summary>
    [DataContract]
    public class ValidationMessageStatusEnum : EnumValue, IEnumValue
    {
        /// <summary>
        /// Значение перечисления. Используется только при отправке, при получении всегда равно
        /// NULL для поддержки обратной совместимости при добавлении новых элементов перечисления
        /// </summary>
        [DataMember]
        public ValidationMessageStatus? Value { get; set; }

        object IEnumValue.Value => Value;
    }
}
