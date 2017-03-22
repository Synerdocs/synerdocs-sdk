using System.Runtime.Serialization;
using Midway.Edi.Api.Common;

namespace Midway.Edi.Api.Errors
{
    /// <summary>
    /// Формат результата валидации в виде объекта перечисления
    /// </summary>
    [DataContract]
    public class ValidationResultFormatEnum : EnumValue, IEnumValue
    {
        /// <summary>
        /// Значение перечисления. Используется только при отправке, при получении всегда равно
        /// NULL для поддержки обратной совместимости при добавлении новых элементов перечисления
        /// </summary>
        [DataMember]
        public ValidationResultFormat? Value { get; set; }

        object IEnumValue.Value => Value;
    }
}
