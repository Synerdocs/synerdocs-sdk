using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Настройки постраничной выборки
    /// </summary>
    [DataContract]
    public class PageSettings
    {
        /// <summary>
        /// Настройка для возвращения первых 100 записей
        /// </summary>
        public static readonly PageSettings First100 = new PageSettings { First = 0, PageSize = 100 };

        /// <summary>
        /// Индекс первого возвращенного элемента (начинается с 0)
        /// </summary>
        [DataMember]
        public int First { get; set; }

        /// <summary>
        /// Количество возвращаемых элементов
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
    }
}
