using Midway.ObjectModel.Common;

namespace Midway.ObjectModel.Extensions
{
    /// <summary>
    /// Расширения для типа оператора фильтра
    /// </summary>
    public static class FilterOperatorTypeExtensions
    {
        /// <summary>
        /// Является ли тип оператора фильтра сравнением двух заданных полей
        /// </summary>
        /// <param name="filterOperatorType"></param>
        public static bool IsFieldsComparison(this FilterOperatorType filterOperatorType)
        {
            return filterOperatorType == FilterOperatorType.EqualsField
                   || filterOperatorType == FilterOperatorType.NotEqualsField
                   || filterOperatorType == FilterOperatorType.GreaterField
                   || filterOperatorType == FilterOperatorType.LessField
                   || filterOperatorType == FilterOperatorType.GreaterOrEqualsField
                   || filterOperatorType == FilterOperatorType.LessOrEqualsField;
        }
    }
}
