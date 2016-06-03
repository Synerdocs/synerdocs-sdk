using System.Linq;
using System.ComponentModel;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Хелпер для работы с перечислениями
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Получить описание элемента перечисления из его атрибута Description
        /// </summary>
        /// <typeparam name="TEnum">Тип перечисления</typeparam>
        /// <param name="value">Значение перечисления</param>
        /// <returns>Описание элемента перечисления</returns>
        public static string GetDescription<TEnum>(this TEnum value)
            where TEnum : struct
        { 
            var descriptionAttribute = (typeof(TEnum))
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault()
                as DescriptionAttribute;
            if (descriptionAttribute == null)
                return string.Empty;
            return descriptionAttribute.Description;
        }

        /// <summary>
        /// Проверяет, равен ли объект перечисления одному из параметров
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool In<TEnum>(this TEnum value, params TEnum[] args)
             where TEnum : struct
        {
            return args.Contains(value);
        }
    }
}
