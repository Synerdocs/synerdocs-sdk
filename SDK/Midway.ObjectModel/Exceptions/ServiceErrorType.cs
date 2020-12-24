namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// Тип ошибки
    /// </summary>
    public enum ServiceErrorType
    {
        /// <summary>
        /// Ошибка валидации сообщения
        /// </summary>
        ValidationFormat = 0,
        /// <summary>
        /// Внутренняя ошибка сервера
        /// </summary>
        InternalServer = 1,
        /// <summary>
        /// Ошибка доставки сообщения
        /// </summary>
        Delivery
    }
}
