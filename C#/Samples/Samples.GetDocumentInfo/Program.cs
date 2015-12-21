#region

using System;
using System.Linq;
using Midway.ObjectModel;
using Midway.ServiceClient;

#endregion

/* Пример использовани API Synerdocs, подробнее на http://www.synerdocs.ru/kis */

namespace Samples.GetDocumentInfo
{
    internal class Program
    {
        /// <summary>
        /// Пример авторизации по сертификату
        /// получение данных по ИНН об организации-получателе
        /// отправка документа с подписью сертификатом пользователя
        /// отправка документ без подписания
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var url = "https://service.synerdocs.ru/exchangeservice.svc";
            var appId = new Guid().ToString();

            var client = new Client(url, false, false, "", "WSHttpsBinding_IExchangeService");

            // авторизация по логину и паролю (тут возможно использовать также 
            // авторизацию по сертификату при необходимости)
            var login = "alice1449839904";
            var password = "1449839904";
            if (client.Authenticate(login, password))
            {
                Console.WriteLine("Успешная авторизация, получен токен:");
                Console.WriteLine(client.Token);
            }
            else
            {
                Console.WriteLine("Ошибка авторизации");
                Console.ReadKey();
                return;
            }

            // получение текущего ящика
            var currentBoxInfo = client.GetBoxes().FirstOrDefault();
            if (currentBoxInfo == null)
            {
                Console.WriteLine("Ошибка при получении ящиков");
                return;
            }
            // выбор текущего ящика - от него будем отправлять документы
            // в простом случае - у пользователя доступен только один ящик
            // а если пользователь состоит в нескольких организациях - ящиков может быть несколько
            var currentBox = currentBoxInfo.Address;

            // ранее сохраненный или полученный ИД документа внутри сообщения, доступного для текущего авторизованного пользователя:

            // ИД документа - может быть и в формате "50008423799c4c82944b5b82c38be02e"
            var documentId = "50008423-799c-4c82-944b-5b82c38be02e";

            try
            {
                // получение тела (бинарного содержимого) документа
                var documentContent = client.GetDocumentContent(currentBox, documentId);
                Console.WriteLine("Получено содержимое документа NBytes=" + documentContent.Length);

                // запрос информации о документе с указаним того, какую информацию необходимо получить
                var docInfo = client.GetFullDocumentInfo(currentBox, documentId, new FullDocumentInfoRequestParams
                {
                    GetCard = true,
                    GetContent = false,
                    GetRelatedDocuments = true,
                    GetServiceDocuments = true,
                    GetSigns = true
                });
                if (docInfo != null)
                {
                    Console.WriteLine("Получена информация о документе");

                    // получении информации о сообщении документооборота, в которое входит документ
                    var messageId = docInfo.MessageId;
                    var message = client.GetMessage(currentBox, messageId);
                    if (message != null)
                        Console.WriteLine("Получена информации о сообщении документооборота");
                }

                // получение полной информации о документе включая информацию документооборотам и вхождениям,
                // с указаним того, какую информацию необходимо получить
                // результат метода дублирует информацию, которую можно получать из других методов API
                // например информацию о подписях и т.д.
                var flowDocumentInfo = client.GetFlowDocumentInfo(currentBox, documentId,
                    new FlowDocumentInfoRequestParams
                    {
                        GetSigns = true,
                        GetServiceDocuments = true,
                        GetRelatedDocuments = true,
                        FlowResult = DocumentFlowResultMode.FullInfo
                    });
                if (flowDocumentInfo != null)
                    Console.WriteLine("Получена информация о документе с докуметооборотами");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка" + ex.GetType() + "   " + ex.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Для выхода нажмите enter");
            Console.ReadLine();
        }
    }
}