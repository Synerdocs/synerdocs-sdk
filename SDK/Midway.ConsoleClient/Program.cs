using System;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Консольное приложение (Консольный клиент) - содержит примеры кода для демонстрации работы с API Synerdocs.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            if (args.Length == 0)
            {
                PrintUsage();
                return;
            }

            Console.Out.WriteLine("Для выхода из программы нажмите горячие клавиши Ctrl+C");

            new Shell().Run(args);
        }

        private static void PrintUsage()
        {
            Console.Out.WriteLine("Использование:");
            Console.Out.WriteLine("mclient <service-url>");
            Console.Out.WriteLine("Пример: ");
            Console.Out.WriteLine("mclient https://service.synerdocs.ru/ExchangeService.svc");
            Console.ReadKey();
        }

    }
}