using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Работа с пользовательским консольным вводов\выводом 
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Опция пользовательского выбора одного значения
        /// из некого списка показаных пользователю значений: например выбор Организации из показаного 
        /// списка организаций
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
        /// Выбрать значение из списка возможных
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
                    Console.Out.WriteLine("Введите значение из предложенного списка");
                    continue;
                }

                line = line.Trim();
                Console.Out.Write("<" + line  + ">");
                var optionById = options.FirstOrDefault(o => String.Equals(o.Id, line, StringComparison.OrdinalIgnoreCase) || String.Equals(o.Name, line, StringComparison.OrdinalIgnoreCase));
                if (optionById != null)
                    return optionById;
                Console.Out.WriteLine("Введите значение из предложенного списка");
            }
        }

        public static bool ChooseYesNo(string caption, bool defaultValue = true)
        {
            var yes = new Option("Y", "Да", defaultValue);
            var no = new Option("N", "Нет", !defaultValue);
            return ChooseOption(caption, new[] {yes, no}) == yes;
        }

        public static string ReadParameter(string caption, string defaultValue = null)
        {
            if(String.IsNullOrEmpty(defaultValue))
            {
                Write(ConsoleColor.White, "{0}:", caption);    
            }
            else
            {
                Write(ConsoleColor.White, "{0}[{1}]:", caption, defaultValue);    
            }
            var line = ReadLine();
            if (line == "" && !String.IsNullOrEmpty(defaultValue))
                return defaultValue;
            return line;
        }

        public static string ReadLine()
        {
            var line = Console.ReadLine();
            if (line == null)
                throw new InputCanceledException();
            line = line.Trim();
            return line;
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
    }

    /// <summary>
    /// Исключение выбрасывется при отмене пользователем начатой операции
    /// </summary>
    public class InputCanceledException : Exception
    {
    }

}