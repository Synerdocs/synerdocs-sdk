namespace Midway.ObjectModel
{
    /// <summary>
    /// Интерфейс подписи.
    /// </summary>
    public interface ISignature
    {
        /// <summary>
        /// Идентификатор подписи.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Идентификатор подписываемого документа.
        /// </summary>
        string DocumentId { get; set; }

        /// <summary>
        /// Содержимое подписи.
        /// </summary>
        byte[] Raw { get; set; }
    }
}
