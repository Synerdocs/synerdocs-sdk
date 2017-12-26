using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс для условия фильтра.
    /// </summary>
    [DataContract]
    [KnownType(typeof(FilterCondition))]
    [KnownType(typeof(CompositeFilterCondition))]
    public class FilterConditionBase
    {
    }
}
