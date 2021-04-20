#region

using System;
using System.IO;
using System.Linq;
using Midway.ObjectModel;
using Midway.ServiceClient;

#endregion

/* Пример использования API Synerdocs, подробнее на http://www.synerdocs.ru/kis */

namespace Samples.DownloadDocumentFlowArchive
{
    internal class Program
    {
        /// <summary>
        /// Пример выгрузки архива документооборота по документам.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var url = "https://service.synerdocs.ru/exchangeservice.svc";
            var appId = new Guid().ToString();
            var login = "alice1449839904";
            var password = "1449839904";

            var client = new Client(url, false, false, "", "WSHttpsBinding_IExchangeService");

            // авторизация по логину и паролю (тут возможно использовать также 
            // авторизацию по сертификату при необходимости)
            if (client.Authenticate(login, password, appId))
            {
                Console.WriteLine("Успешная авторизация, получен токен:");
                Console.WriteLine(client.Token);
            }
            else
            {
                Console.WriteLine("Ошибка авторизации");
                WaitAndExit();
                return;
            }

            // получение текущего ящика
            var currentBoxInfo = client.GetBoxes().FirstOrDefault();
            if (currentBoxInfo == null)
            {
                Console.WriteLine("Ошибка при получении ящиков");
                WaitAndExit();
                return;
            }

            // выбор текущего ящика
            // в простом случае - у пользователя доступен только один ящик
            // а если пользователь состоит в нескольких организациях - ящиков может быть несколько
            var currentBox = currentBoxInfo.Address;
            Console.WriteLine(currentBox);

            // получаем список исходящих документов
            var documents = client.GetDocumentList(new DocumentListOptions
            {
                // ! для того, чтобы выбрать входящие документы, необходимо указать в поле BoxTo - наш ящик
                BoxTo = null,
                // отправленных от нашего ящика 
                BoxFrom = currentBox,
                // начать с этого индекса для постраничной выборки элементов
                First = 0,
                // кол-во элементов на странице
                Max = 10
            });

            foreach (var document in documents.Items)
            {
                // файл, куда будет сохранен архив документооборота
                var filePath = $"{document.Id}.zip";

                try
                {
                    // получение архива с документооборотом по документу
                    var documentFlow =
                        client.DownloadDocumentFlowArchiveWithoutInformationReceipt(currentBox, document.Id);
                    File.WriteAllBytes(filePath, documentFlow.Content);
                    Console.WriteLine("Получен архив документооборота документа '" +
                        Path.GetFileNameWithoutExtension(documentFlow.Name) + "'");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка" + ex.GetType() + "   " + ex.Message);
                    WaitAndExit();
                    return;
                }
            }

            WaitAndExit();
        }

        /// <summary>
        /// Ожидание реакции пользователя.
        /// </summary>
        static void WaitAndExit()
        {
            Console.WriteLine("Для выхода нажмите enter");
            Console.ReadLine();
        }
    }
}