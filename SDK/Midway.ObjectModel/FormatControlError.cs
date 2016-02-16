namespace Midway.ObjectModel
{
    public class FormatControlError
    {
        /// <summary>
        /// Статус ошибки
        /// </summary>
        public ValidationStatus Status { get; set; }

        /// <summary>
        /// Индекс поля 
        /// </summary>
        public int Index { get; set; }
    }
}
