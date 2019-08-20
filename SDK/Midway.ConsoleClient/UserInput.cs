using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Работа с пользовательским консольным вводом-выводом.
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Размер буфера для ввода текста.
        /// </summary>
        private const int ReadlineBufferSize = 8192;
        private static string nodePrefix = "*---";

        /// <summary>
        /// Опция пользовательского выбора одного значения
        /// из некого списка показаных пользователю значений: например выбор Организации из показаного 
        /// списка организаций.
        /// </summary>
        public class Option
        {
            private readonly string _id;
            private readonly string _name;
            readonly bool _isDefault;
            private readonly object _data;

            public Option(string id, string name, bool isDefault, object data = null)
            {
                _id = id;
                _name = name;
                _isDefault = isDefault;
                _data = data;
            }

            public string Id
            {
                get { return _id; }
            }

            public string Name
            {
                get { return _name; }
            }

            public bool IsDefault
            {
                get { return _isDefault; }
            }

            public object Data
            {
                get { return _data; }
            }
        }

        /// <summary>
        /// Выбрать значение из списка возможных.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Option ChooseOption(string caption, IEnumerable<Option> options)
        {
            if (caption == null) throw new ArgumentNullException("caption");
            if (options == null) throw new ArgumentNullException("options");
            Console.Out.WriteLine(caption);
            foreach (var option in options)
            {
                Console.Out.WriteLine("\t[{1}] {0}", option.Name, option.Id); 
            }
            var defaultOption = options.FirstOrDefault(o => o.IsDefault);

            while (true)
            {

                if (defaultOption != null)
                {
                    Write(ConsoleColor.White, "{0} [{1}]:", caption, (object)defaultOption.Id);
                }
                else
                {
                    Write(ConsoleColor.White, "{0} :", caption);
                }

                var line = Console.ReadLine();
                // пользователь нажал ^C
                if (line == null)
                {
                    throw new InputCanceledException();
                }

                if (line == "")
                {
                    if (defaultOption != null)
                        return defaultOption;
                    Console.Out.WriteLine("Выберите значение из списка");
                    continue;
                }

                line = line.Trim();
                Console.Out.Write("<" + line  + ">");
                var optionById = options.FirstOrDefault(o => String.Equals(o.Id, line, StringComparison.OrdinalIgnoreCase) || String.Equals(o.Name, line, StringComparison.OrdinalIgnoreCase));
                if (optionById != null)
                    return optionById;
                Console.Out.WriteLine("Выберите значение из списка");
            }
        }
        /// <summary>
        /// Выбрать значение из списка возможных.
        /// </summary>
        /// <param name="caption">Заголовок выбора.</param>
        /// <param name="values">Возможные значения.</param>
        /// <returns>Выбранное значение.</returns>
        public static Option ChooseOption<T>(string caption, IEnumerable<T> values)
            => ChooseOption(caption, values
                .Select((v, i) => new Option(
                    (i + 1).ToString(),
                    typeof(T).IsEnum
                        ? EnumHelper.GetDescription(v)
                        : v.ToString(),
                    isDefault: false,
                    data: v))
                .ToList());

        public static bool ChooseYesNo(string caption, bool defaultValue = true)
        {
            var yes = new Option("Y", "Да", defaultValue);
            var no = new Option("N", "Нет", !defaultValue);
            return ChooseOption(caption, new[] {yes, no}) == yes;
        }

        public static string ReadParameter(string caption, string defaultValue = null)
        {
            if(String.IsNullOrEmpty(defaultValue))
                Write(ConsoleColor.White, "{0}:", caption);
            else
                Write(ConsoleColor.White, "{0}[{1}]:", caption, defaultValue);
            
            var line = ReadLine();
            if (line == "" && !String.IsNullOrEmpty(defaultValue))
                return defaultValue;
            return line;
        }

        public static string ReadLine()
        {
            using (var inputStream = Console.OpenStandardInput(ReadlineBufferSize))
            {
                var bytes = new byte[ReadlineBufferSize];
                var outputLength = inputStream.Read(bytes, 0, ReadlineBufferSize);
                var chars = Console.InputEncoding.GetChars(bytes, 0, outputLength);
                var line = new String(chars);
                line = line.Trim();
                return line;
            }
        }

        public static void Error(string text, params object [] args)
        {
            var color = ConsoleColor.Red;
            WriteLine(color, text, args);
        }

        public static void Warning(string text, params object[] args)
        {
            var color = ConsoleColor.Yellow;
            WriteLine(color, text, args);
        }

        public static void Success(string text, params object[] args)
        {
            var color = ConsoleColor.Green;
            WriteLine(color, text, args);
        }

        public static void Information(string text, params object[] args)
        {
            var color = ConsoleColor.Cyan;
            WriteLine(color, text, args);
        }

        public static void Separator()
        {
            Console.Out.WriteLine("------------------------------------------------------------");
        }

        public static void WriteLine(ConsoleColor color, string text, params object[] args)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Out.WriteLine(text, args);
            Console.ForegroundColor = old;
        }

        public static void Write(ConsoleColor color, string text, params object[] args)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Out.Write(text, args);
            Console.ForegroundColor = old;
        }

        public static string ReadPassword(string caption)
        {
            Console.Write("{0}: ", caption);

            var sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }

                Console.Write('*');
                sb.Append(cki.KeyChar);
            }

            return sb.ToString();
        }

        private static string GetFormattedFieldValue<T>(string prefix, string name, T value)
        {
            return $"{prefix}{name} : {value}";
        }

        private static bool IsHaveInnerFields(Type type)
        {
            if (type.IsPrimitive
                || type == typeof(System.String)
                || type == typeof(System.DateTime)
                || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)))
                return false;

            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return props.Count() > 0;
        }

        private static List<string> GetFormattedField(Type propType, string prefix, string propName, object propValue)
        {
            var result = new List<string>();

            if (IsHaveInnerFields(propType))
            {
                result.Add(GetFormattedFieldValue(prefix, propName, propValue));
                var nextLevelPrefix = prefix + nodePrefix;
                result.AddRange(GetFormattedObjectFields(propValue, nextLevelPrefix));
            }
            else
            {
                result.Add(GetFormattedFieldValue(prefix, propName, propValue));
            }

            return result;
        }

        /// <summary>
        /// Получить строковые представления модели.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
         public static List<string> GetFormattedObjectFields(object model, string prefix = "")
         {
                var type = model.GetType();
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var result = new List<string>();

                foreach (var prop in props)
                {
                    var propName = prop.Name;
                    var propValue = prop.GetValue(model, null);

                    if (propValue == null)
                    {
                        result.Add(GetFormattedFieldValue(prefix, propName, "null"));
                    }
                    else
                    {
                        var propType = propValue.GetType();
                        if (propType.IsArray)
                        {
                            var arr = (Array)propValue;
                            for (int i = 0; i < arr.Length; i++)
                            {
                                var arrPropName = $"{propName}[{i}]";
                                var value = arr.GetValue(i);
                                var arrPropType = value.GetType();
                                result.AddRange(GetFormattedField(arrPropType, prefix, arrPropName, value));
                            }
                        }
                        else result.AddRange(GetFormattedField(propType, prefix, propName, propValue));
                    }
                }
                return result;
           }
          
        /// <summary>
        /// Получить строковые представления данных объекта и вывести их в консоль.
        /// </summary>
        /// <param name="model"></param>
        public static void FormatAndOutputObjectFields(object model)
        {
            var formattedFields = GetFormattedObjectFields(model);
            Console.Out.WriteLine();
            foreach (var item in formattedFields)
                Console.Out.WriteLine(item);
        }
    }

    /// <summary>
    /// Исключение выбрасывется при отмене пользователем начатой операции.
    /// </summary>
    public class InputCanceledException : Exception
    {
    }

}