using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Midway.ServiceClient;

namespace Samples.Auth
{
    /// <summary>
    /// Примеры авторизации
    ///  по логину и паролю
    ///  по сертификату
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://service.synerdocs.ru/exchangeservice.svc";
            var appId = new Guid().ToString();
            var login = "alice-synerdocs-test-user1449839904";
            var password = "1449839904";

            var client = new Client(url, enableTracing: false, useStreamRequest: false, applicationVersionValue: "", configEndpointName: "WSHttpsBinding_IExchangeService");

            // авторизуемся по логину и паролю, получаем токен
            if (client.Authenticate(login, password, appId))
            {
                Console.WriteLine("Успешная авторизация по логину и паролю, получен токен:");
                Console.WriteLine(client.Token);
            }
            else
            {
                Console.WriteLine("Ошибка авторизации, неверный логин или пароль?");
            }

            // сертификат для входа по сертификату БЕЗ возможности подписания
            var certificatesDir = "../../../Certificates";
            var certificateBytes = File.ReadAllBytes(certificatesDir + "/Alice/certificate.crt");
            var certificate = new X509Certificate2(certificateBytes);

            // авторизуемся по сертификату
            if (client.AuthenticateWithCertificate(certificate.Thumbprint, appId))
            {
                Console.WriteLine("Успешная авторизация по сертификату, получен токен:");
                Console.WriteLine(client.Token);
            }
            else
            {
                Console.WriteLine("Ошибка авторизации по сертификату");
            }

            Console.WriteLine("Для выхода нажмите enter");
            Console.ReadLine();
        }
    }
}
