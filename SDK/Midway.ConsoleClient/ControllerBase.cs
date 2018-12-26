using System;
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
        public void Run()
        {
            while (true)
            {
                var commands = GetCommands();
                PrintAvailableCommands(commands);
                Console.Write(">");

                var commandName = UserInput.ReadLine();
                if (commands.TryGetValue(commandName, out var command))
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
                    UserInput.Error($"Неправильно указано имя команды \"{commandName}\"");
                }
            }
        }

        /// <summary>
        /// Получить доступные комманды.
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
