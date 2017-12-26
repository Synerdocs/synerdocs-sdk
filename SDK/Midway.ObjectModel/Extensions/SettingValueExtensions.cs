using System;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel.Extensions
{
    /// <summary>
    /// Методы расширения для SettingValue.
    /// </summary>
    public static class SettingValueExtensions
    {
        /// <summary>
        /// Получить типизированное значение настройки.
        /// </summary>
        /// <param name="settingValue">Значение настройки.</param>
        /// <returns>Типизированное значение настройки.</returns>
        public static object ToTypifiedValue(this SettingValue settingValue)
        {
            switch (settingValue.ValueType.Code)
            {
                case (int)TextValueType.String:
                    return settingValue.ValueText;
                case (int)TextValueType.Boolean:
                    return Convert.ToBoolean(settingValue.ValueText);
                default:
                    throw new ArgumentOutOfRangeException(nameof(settingValue.ValueType));
            }
        }
    }
}
