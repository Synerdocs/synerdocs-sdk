using System;
using System.Linq;
using System.ComponentModel;
using Midway.ObjectModel;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Хелпер для работы с перечислениями.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Получить описание элемента перечисления из его атрибута Description.
        /// </summary>
        /// <typeparam name="TEnum">Тип перечисления.</typeparam>
        /// <param name="value">Значение перечисления.</param>
        /// <returns>Описание элемента перечисления.</returns>
        public static string GetDescription<TEnum>(this TEnum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((attributes.Length > 0))
                    return attributes.First().Description;
                return value.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Проверяет, равен ли объект перечисления одному из параметров.
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

        /// <summary>
        /// Преобразовать обычное перечисление в перечисление для API.
        /// </summary>
        /// <typeparam name="TEnum">Тип обычного перечисления.</typeparam>
        /// <param name="value">Значение обычного перечисления.</param>
        /// <returns>Значение перечисления для API.</returns>
        public static EnumValue ToEnumValue<TEnum>(this TEnum value)
            where TEnum : struct
        {
            var type = typeof(TEnum);
            var @enum = Convert.ChangeType(value, type);
            if (!Enum.IsDefined(type, @enum))
                throw new ArgumentOutOfRangeException(nameof(value));

            return new EnumValue
                   {
                       Code = (int) Convert.ChangeType(@enum, typeof (int)),
                       Name = @enum.ToString(),
                       Description = @enum.GetDescription()
                   };
        }
    }
}
