using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о счет-фактуре
    /// </summary>
    public class NumberDateSum
    {
        /// <summary>
        /// Номер счет-фактуры, указанный пользователем
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата отправки счет-фактуры
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Сумма счет-фактуры
        /// Для СФ - сумма
        /// Для КСФ - разница между увеличением и уменьшением суммы
        /// </summary>
        public decimal? Sum { get; set; }
    }
}
