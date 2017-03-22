using System.Runtime.Serialization;
using Midway.Edi.Api.Common;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Статус обработки заявки на регистрацию в виде объекта перечисления
    /// </summary>
    [DataContract]
    public class EdiRequestStatusEnum : EnumValue, IEnumValue
    {
        /// <summary>
        /// Значение перечисления. Используется только при отправке, при получении всегда равно
        /// NULL для поддержки обратной совместимости при добавлении новых элементов перечисления
        /// </summary>
        [DataMember]
        public EdiRequestStatus? Value { get; set; }

        object IEnumValue.Value => Value;
    }
}
