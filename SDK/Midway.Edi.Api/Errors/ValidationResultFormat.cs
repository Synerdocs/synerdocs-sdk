using System.Runtime.Serialization;

namespace Midway.Edi.Api.Errors
{
    /// <summary>
    /// Формат результата валидации
    /// </summary>
    [DataContract]
    public enum ValidationResultFormat
    {
        /// <summary>
        /// Результаты валидации представлены в виде линейного списка
        /// </summary>
        [EnumMember]
        List = 0,

        /// <summary>
        /// Результаты валидации представлены в виде дерева объектов
        /// </summary>
        [EnumMember]
        Tree = 1,
    }
}
