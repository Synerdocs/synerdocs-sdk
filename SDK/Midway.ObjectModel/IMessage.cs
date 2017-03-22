namespace Midway.ObjectModel
{
    /// <summary>
    /// Интерфейс сообщения
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Документы сообщения
        /// </summary>
        Document[] Documents { get; set; }
    }
}
