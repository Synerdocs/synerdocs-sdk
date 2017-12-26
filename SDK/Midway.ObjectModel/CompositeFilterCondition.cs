using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Условие составного фильтра.
    /// </summary>
    [DataContract]
    public class CompositeFilterCondition : FilterConditionBase
    {
        /// <summary>
        /// Список условий фильтрации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<FilterConditionBase> Conditions { get; set; }

        /// <summary>
        /// Оператор составного фильтра.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue Operator { get; set; }
    }
}
