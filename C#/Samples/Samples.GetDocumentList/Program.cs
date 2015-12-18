#region

using System;
using System.Linq;
using Midway.ObjectModel;
using Midway.ServiceClient;

#endregion

/* Пример использовани API Synerdocs, подробнее на http://www.synerdocs.ru/kis */

namespace Samples.GetDocumentList
{
    /// <summary>
    /// Примеры авторизации
    /// по логину и паролю
    /// и получение списка документов
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

            var boxInfo = client.GetBoxes().FirstOrDefault();
            if (boxInfo == null)
            {
                Console.WriteLine("Ошибка при получении ящиков");
                return;
            }
            var currentBox = boxInfo.Address;

            Console.WriteLine(currentBox);

            // получаем список исходящих документов
            var docs = client.GetDocumentList(new DocumentListOptions
            {
                BoxTo = null,
                // отправленных от нашего ящика
                BoxFrom = currentBox,
                First = 0,
                Max = 10
            });

            Console.WriteLine(docs.Total);
            foreach (var doc in docs.Items)
                Console.WriteLine(doc.Name);

            Console.WriteLine("Для выхода нажмите enter");
            Console.ReadLine();
        }
    }
}