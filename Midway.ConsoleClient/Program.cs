using System;

namespace Midway.ConsoleClient
{
    public class Program
    {
        public static void Main(string [] args)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                delegate(object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                         System.Security.Cryptography.X509Certificates.X509Chain chain,
                         System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    { 
                        return true;
                    };
            
            if (args.Length == 0)
            {
                PrintUsage();
                return;
            }
            
            Console.Out.WriteLine("Для выхода и программы нажмите Ctrl+C");
            
            new Shell().Run(args);            
        }

        private static void PrintUsage()
        {
            Console.Out.WriteLine("Использование:");
            Console.Out.WriteLine("mclient <service-url>");
            Console.Out.WriteLine("Пример: ");
            Console.Out.WriteLine("mclient http://localhost:5001/ExchangeService.svc");
        }

    }
}