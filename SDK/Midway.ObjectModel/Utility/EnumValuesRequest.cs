using System.Runtime.Serialization;

namespace Midway.ObjectModel.Utility
{
    /// <summary>
    /// Запрос на получение значений перечислений.
    /// </summary>
    [DataContract]
    [KnownType(typeof(AllEnumValuesRequest))]
    [KnownType(typeof(FullEnumValuesRequest))]
    [KnownType(typeof(SpecifiedEnumValuesRequest))]
    public class EnumValuesRequest
    {
    }
}
