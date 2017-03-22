namespace Midway.ObjectModel
{
    /// <summary>
    /// Интерфейс для объекта перечисления
    /// </summary>
    public interface IEnumValue
    {
        /// <summary>
        /// Числовой код
        /// </summary>
        int Code { get; }

        /// <summary>
        /// Значение перечисления
        /// </summary>
        object Value { get; }
    }
}
