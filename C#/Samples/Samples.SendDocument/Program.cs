#region

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Midway.Crypto;
using Midway.ObjectModel;
using Midway.ServiceClient;

#endregion

namespace Samples.SendDocument
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

            // сертификат для входа по сертификату и подписания
            X509Certificate2 certificate;
            try
            {
                certificate = GetCertificate();
            }
            catch (Exception)
            {
                OnGetCertificateError();
                Console.ReadLine();
                return;
            }

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

            // ИНН организации-получателя
            var inn = "1839839904";
            // не знаем КПП, при пустом значении - должно найти головное подразделение организации
            var kpp = "";

            // поиск организации получателя по атрибутам
            var organizations = client.GetOrganizationListByInnKpp(inn, kpp);
            foreach (var organization in organizations)
                Console.WriteLine(organization.Name);

            // содержимое неформализованного документа из файла на локальном компьютере
            var filePath = "../../Documents/simple_text_document.txt";
            var fileBytes = File.ReadAllBytes(filePath);
            // создание подписи к бинарному содержимому файла
            var signature = CryptoApiHelper.Sign(certificate, fileBytes, true);

            // получение текущего ящика
            var boxInfo = client.GetBoxes().FirstOrDefault();
            if (boxInfo == null)
            {
                Console.WriteLine("Ошибка при получении ящиков");
                return;
            }
            var currentBox = boxInfo.Address;

            // создание документа
            var document = new Document
            {
                Id = Guid.NewGuid().ToString(),
                DocumentType = DocumentType.Untyped,
                UntypedKind = null,
                FileName = Path.GetFileName(filePath),
                Content = fileBytes,
                Card = null,
                NeedSign = false
            };

            // создаем сообщение для отправки
            var message = new Message
            {
                Id = Guid.NewGuid().ToString(),
                From = currentBox,
                // документы
                Documents = new[] { document },
                // получатели
                Recipients = organizations.Select(x =>
                    new MessageRecipient
                    {
                        OrganizationBoxId = x.BoxAddress
                    }).ToArray(),
                // прикрепляем подписи
                Signs = new[]
                {
                    new Sign
                    {
                        Id = Guid.NewGuid().ToString(),
                        DocumentId = document.Id,
                        Raw = signature
                    }
                }
            };
            var result = client.SendMessage(message);

            Console.WriteLine("Успешно отправлено исходящее сообщение MessageId = {0}", result.MessageId);

            Console.WriteLine("Для выхода нажмите enter");
            Console.ReadLine();
        }

        /// <summary>
        /// Получение сертификата С ЗАКРЫТЫМ КЛЮЧОМ - для возможности подписания
        /// Необходимо наличие КриптоПро на локальном компьютере нужной версии
        /// 
        /// Для установки на локальный компьютер использовать 
        /// "../../Certificates/Alice/install_certificate.pfx"
        /// 
        /// Пароль на контейнер  - "1"
        /// </summary>
        /// <returns></returns>
        private static X509Certificate2 GetCertificate()
        {
            // Отпечаток сертификата, который должен быть установлен в системе
            var thumbprint = "2A7758BA286F826A964699E834A77194C351780F";

            Func<X509Certificate2, bool> certCondition =
                x => x.Thumbprint != null
                     && x.Thumbprint.Equals(thumbprint, StringComparison.InvariantCultureIgnoreCase);

            // открываем хранилище сертификатов на локальном компьютере
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            // разрешенные значения поля "алгоритм подписи" сертификатов (алгоритм ГОСТ)
            var validGostAlgorithms = new[]
            {
                "1.2.643.2.2.4",
                "1.2.643.2.2.3"
            };

            var validCertificates = store.Certificates.Cast<X509Certificate2>()
                // использующие алгоритм ГОСТ
                .Where(x => validGostAlgorithms.Contains(x.SignatureAlgorithm.Value));

            var allowed = validCertificates.Where(certCondition).ToArray();
            if (allowed.Count() > 1)
                throw new InvalidOperationException("Найдено более одного сертификата, удовлетворяющего" +
                                                    " условию поиска");

            var cert = allowed.FirstOrDefault();
            if (cert == null)
                throw new InvalidOperationException("Не найдено ни одного сертификата, удовлетворяющего" +
                                                    " условию поиска и подходящего для работы в сервисе");

            if (!cert.HasPrivateKey)
                throw new InvalidOperationException(string.Format(
                    "Не найден закрытый ключ для сертификата с отпечатком {0}", cert.Thumbprint));

            return cert;
        }

        /// <summary>
        /// Обработка ошибки получения установленного сертификата с закрытым ключом
        /// </summary>
        private static void OnGetCertificateError()
        {
            Console.WriteLine("Тестовый сертификат не найден на локальном компьютере " +
                              "или произошла ошибка при получении сертификата. " +
                              "Установите сертификат (если он не установлен) из файла, пример пути до файла установки сертификата: \n" +
                              "/Certficates/Alice/install_certificate.pfx \n" +
                              "Пароль на контейнер при установке сертификата - 1, " +
                              "При установке выбирать параметры по умолчанию" +
                              "Инструкция - /Certficates/manual.pdf \n" +
                              "Или проверьте установленное ПО для подписания (КриптоПро)" +
                              "\n" +
                              "Нажмите Y для запуска /Certficates/Alice/install_certificate.pfx"
                );
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                // запуск pfx установщика сертификат
                var certificatesDir = "../../../Certificates";
                System.Diagnostics.Process.Start(
                    Path.Combine(Environment.CurrentDirectory, certificatesDir + @"/Certificates/Alice/install_certificate.pfx")
                    );
            }
        }
    }
}