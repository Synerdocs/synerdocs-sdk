using System;

namespace Midway.ServiceClient
{
    internal static class EnumUtils
    {
        public static bool TryParse<TEnum>(string text, out TEnum value)
        {
            if (!Enum.IsDefined(typeof(TEnum), text))
            {
                value = default(TEnum);
                return false;
            }

            value = (TEnum)Enum.Parse(typeof(TEnum), text);
            return true;
        }
    }
}
