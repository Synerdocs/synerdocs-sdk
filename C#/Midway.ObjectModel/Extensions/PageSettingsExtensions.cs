using Midway.ObjectModel.Common;

namespace Midway.ObjectModel.Extensions
{
    /// <summary>
    /// Расширения для работы с настройками постраничной выборки
    /// </summary>
    public static class PageSettingsExtensions
    {
        /// <summary>
        /// Ограничить пределы количества возвращаемых элементов
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="lowBound">Нижний предел</param>
        /// <param name="highBound">Верхний предел</param>
        public static void Restrict(this PageSettings settings, int lowBound, int highBound)
        {
            if (settings.PageSize > highBound)
                settings.PageSize = highBound;
            else if (settings.PageSize < lowBound)
                settings.PageSize = lowBound;
        }
    }
}
