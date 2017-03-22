using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип документа в виде объекта перечисления
    /// </summary>
    [DataContract]
    public class DocumentTypeEnum : EnumValue, IEnumValue
    {
        /// <summary>
        /// Значение перечисления. Используется только при отправке, при получении всегда равно
        /// NULL для поддержки обратной совместимости при добавлении новых элементов перечисления
        /// </summary>
        [DataMember]
        public DocumentType? Value { get; set; }

        object IEnumValue.Value => Value;
    }
}
