namespace Midway.ObjectModel
{
    /// <summary>
    /// ѕараметры поиска черновиков
    /// </summary>
    public class DraftSearchOptions
    {
        /// <summary>
        /// »ндекс первого черновика (отсчет ведетс€ с самого свежего черновика, с 0)
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// ћаксимальное количество возвращаемых черновиков
        /// ѕараметр може принимать значение от 0 до 100
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// €щик
        /// </summary>
        public string BoxId { get; set; }

        /// <summary>
        /// “ип документа
        /// </summary>
        public DocumentType? DocumentType { get; set; }
    }
}
