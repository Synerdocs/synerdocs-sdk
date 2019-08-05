using System;
using System.Linq;
using System.Collections.Generic;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Базовый контроллер консольного приложения.
    /// </summary>
    public abstract class ControllerBase
    {
        /// <summary>
        /// Запустить контроллер.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        public void Run(string[] args)
        {          
            var commandCodes
                = new Queue<string>(Array.IndexOf(args, "-CommandCodes") is var index && index >= 0
                    ? args.ElementAtOrDefault(index + 1)?.Split(',') ?? Enumerable.Empty<string>()
                    : Enumerable.Empty<string>());

            while (true)
            {
                var commands = GetCommands();
                PrintAvailableCommands(commands);
                Console.Write(">");

                var commandCode = commandCodes.Any()
                    ? commandCodes.Dequeue()
                    : UserInput.ReadLine();

                if (commands.TryGetValue(commandCode, out var command))
                {
                    var commandAction = command.Item1;
                    if (commandAction == null)
                    {
                        UserInput.Information("Выход");
                        return;
                    }

                    try
                    {
                        commandAction();
                        var commanTitle = command.Item2;
                        UserInput.Success($"Команда \"{commanTitle}\" выполнена");
                    }
                    catch (InputCanceledException)
                    {
                        UserInput.Warning("Команда прервана");
                    }
                    catch (Exception ex)
                    {
                        var message = "При выполнении команды произошла неожиданная ошибка";
                        LogError(message, ex);

                        UserInput.Error(message);
                        UserInput.Error(ex.ToString());
                    }
                }
                else
                {
                    UserInput.Error($"Неправильно указано имя команды \"{commandCode}\"");
                }
            }
        }

        /// <summary>
        /// Получить доступные команды.
        /// </summary>
        /// <returns>Доступные комманды.</returns>
        protected abstract Dictionary<string, Tuple<Action, string>> GetCommands();

        /// <summary>
        /// Записать в лог сообщение об ошибке.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="exception">Исключение.</param>
        protected abstract void LogError(string message, Exception exception);

        /// <summary>
        /// Напечатать доступные команды.
        /// </summary>
        /// <param name="commands">Доступные команды.</param>
        private void PrintAvailableCommands(Dictionary<string, Tuple<Action, string>> commands)
        {
            Console.WriteLine("Доступные команды:");
            foreach (var command in commands)
                Console.WriteLine(" {0,-6}{1}", command.Key, command.Value.Item2);
        }
    }
}
