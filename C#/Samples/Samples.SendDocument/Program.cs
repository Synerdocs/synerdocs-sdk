#region

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Midway.Crypto;
using Midway.ObjectModel;
using Midway.ServiceClient;

#endregion

/* Пример использовани API Synerdocs, подробнее на http://www.synerdocs.ru/kis */

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
            var certificate = TryInstallOrGetCertificate();
            if (certificate == null)
                return;

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
            var filesDir = "../../../../../ExamplesOfUserFiles";
            var filePath = filesDir + "/Documents/Неформализованный текстовый документ.txt";
            var filePath2 = filesDir + "/Documents/Первый неформализованный документ1.png";
            var fileBytes = File.ReadAllBytes(filePath);
            var fileBytes2 = File.ReadAllBytes(filePath2);
            // создание подписей к бинарному содержимому файла
            var signature = CryptoApiHelper.Sign(certificate, fileBytes, true);
            var signature2 = CryptoApiHelper.Sign(certificate, fileBytes2, true);

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
            // создание еще одного документа (опционально)
            var document2 = new Document
            {
                Id = Guid.NewGuid().ToString(),
                DocumentType = DocumentType.Untyped,
                UntypedKind = null,
                FileName = Path.GetFileName(filePath2),
                Content = fileBytes2,
                Card = null,
                NeedSign = false
            };

            // создаем сообщение для отправки
            var message = new Message
            {
                Id = Guid.NewGuid().ToString(),
                From = currentBox,
                // документы
                Documents = new[]
                {
                    document,
                    document2
                },
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
                    },
                    new Sign
                    {
                        Id = Guid.NewGuid().ToString(),
                        DocumentId = document2.Id,
                        Raw = signature2
                    }
                }
            };
            SentMessage result;
            try
            {
                result = client.SendMessage(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при отправке документов: " + ex.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Успешно отправлено исходящее сообщение MessageId = {0}", result.MessageId);

            Console.WriteLine("Для выхода нажмите enter");
            Console.ReadLine();
        }

        /// <summary>
        /// Получение сертификата С ЗАКРЫТЫМ КЛЮЧОМ - для возможности подписания
        /// Необходимо наличие КриптоПро на локальном компьютере нужной версии
        /// Для установки на локальный компьютер использовать
        /// "../../Certificates/Alice/install_certificate.pfx"
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
        /// Запуск установки при необходимости и(или) получение сертификата с закрытым ключом)
        /// </summary>
        /// <returns></returns>
        private static X509Certificate2 TryInstallOrGetCertificate()
        {
            // сертификат для входа по сертификату и подписания
            X509Certificate2 certificate;
            try
            {
                certificate = GetCertificate();
            }
            catch (Exception)
            {
                var successPfxInstalled = OnGetCertificateError();
                // если была успешно запущена установка сертификта из хранилища
                if (successPfxInstalled)
                {
                    try
                    {
                        certificate = GetCertificate();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(
                            "Ошибка при получении сертификата с закрытым ключом. Возможно установка сертификата прошла с ошибками");
                        Console.ReadLine();
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка при получении сертификата с закрытым ключом");
                    Console.ReadLine();
                    return null;
                }
            }
            return certificate;
        }

        /// <summary>
        /// Обработка ошибки получения установленного сертификата с закрытым ключом
        /// </summary>
        private static bool OnGetCertificateError()
        {
            Console.WriteLine("Тестовый сертификат не найден на локальном компьютере " +
                              "или произошла ошибка при получении сертификата. \n" +
                              "Установите сертификат (если он не установлен) из файла, пример пути до файла установки сертификата: \n" +
                              "/Certficates/Alice/install_certificate.pfx \n" +
                              "Пароль на контейнер при установке сертификата - 1,  \n" +
                              "При установке выбирать параметры по умолчанию  \n" +
                              "Инструкция - /Certficates/manual.pdf \n" +
                              "После успешной установки перезапуститет пример" +
                              "Или проверьте установленное ПО для подписания (КриптоПро)" +
                              "\n" +
                              "Нажмите Y для запуска /Certficates/Alice/install_certificate.pfx \n"
                );
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                var filesDir = "../../../../../ExamplesOfUserFiles";
                var pfxInstaller = filesDir + @"/Certificates/Alice/install_certificate.pfx";

                if (!File.Exists(pfxInstaller))
                {
                    Console.WriteLine(
                        "Установочный pfx файл сертификата не найден, обратитесь в службу поддержки для получения тестового сертификата");
                    return false;
                }
                // запуск файла pfx - установщика сертификата с закрытым ключом в Windows
                Process.Start(
                    Path.Combine(Environment.CurrentDirectory, pfxInstaller)
                    );
                Console.WriteLine("Нажмите любую клавишу для проложения");
                Console.ReadKey();
                return true;
            }
            return false;
        }
    }
}