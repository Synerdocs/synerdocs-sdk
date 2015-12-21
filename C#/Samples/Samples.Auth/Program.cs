#region

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Midway.ServiceClient;

#endregion

/* Пример использовани API Synerdocs, подробнее на http://www.synerdocs.ru/kis */

namespace Samples.Auth
{
    /// <summary>
    /// Примеры авторизации
    /// по логину и паролю
    /// по сертификату
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var url = "https://service.synerdocs.ru/exchangeservice.svc";
            var appId = new Guid().ToString();
            var login = "alice1449839904";
            var password = "1449839904";

            var client = new Client(url, false, false, "", "WSHttpsBinding_IExchangeService");

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

            // сертификат для входа по сертификату БЕЗ возможности подписания, т.к. в certificate при таком способе
            // получения сертификата нет закрытого ключа, необходимого для подписания
            var filesDir = "../../../../..";
            // путь до файла сертификата
            var certificatePath = filesDir + "/Certificates/certificate.crt";
            // бинарное содержимое сертификата
            var certificateBytes = File.ReadAllBytes(certificatePath);
            // структура данных с отобржаением свойств сертификата
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