using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Условие фильтра.
    /// </summary>
    [DataContract]
    public class FilterCondition : FilterConditionBase
    {
        /// <summary>
        /// Наименование поля.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue FieldName { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Value { get; set; }

        /// <summary>
        /// Оператор.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue Operator { get; set; }
    }
}
