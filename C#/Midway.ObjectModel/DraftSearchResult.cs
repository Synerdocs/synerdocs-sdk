namespace Midway.ObjectModel
{
    /// <summary>
    /// Результат поиска черновиков
    /// </summary>
    public class DraftSearchResult
    {
        /// <summary>
        /// Общее количество записей по результатам поиска
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Найденные черновики
        /// </summary>
        public DraftSearchItem[] Items { get; set; }
    }
}
