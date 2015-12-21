#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Midway.ObjectModel;
using Midway.ServiceClient;

#endregion

/* Пример использовани API Synerdocs, подробнее на http://www.synerdocs.ru/kis */

namespace Samples.SendUnsignedDocument
{
    internal class Program
    {
        /// <summary>
        /// Пример авторизации по сертификату
        /// получение данных по ИНН об организации-получателе
        /// отправка документа с подписью сертификатом пользователя
        /// отправка документов без подписания
        /// 
        /// отправка идет так:
        /// 
        /// сообщение1 - получателю1 без указания подразления
        ///   документ1
        ///   документ2
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var url = "https://service.synerdocs.ru/exchangeservice.svc";
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

            // ИНН организации-получателя
            var inn = "1839839970";
            // пусть не знаем КПП, при пустом значении - должно автоматически быть получено головное 
            // при получении списка организации
            var kpp = "";

            // поиск организации получателя по атрибутам
            var organizations = client.GetOrganizationListByInnKpp(inn, kpp);

            // отладочный вывод некоторой информации о найденных организациях
            Console.WriteLine("Организации - получатели:");
            foreach (var organization in organizations)
                Console.WriteLine(organization.Name);

            // создание списка получателей документов в сообщении
            var messageRecipients = organizations.Select(x =>
                new MessageRecipient
                {
                    // ящик получателя, при этом автоматически будет выбрано головное подразделение,
                    // т.к. явно не указали подразделение
                    OrganizationBoxId = x.BoxAddress
                }).ToList();

            // добавление еще одного получателя:
            // выбор по определенному КПП подразделения организации - получателя
            var moreRecipientKpp = "243456789";
            var moreRecipient = client.GetOrganizationByInnKpp("1839840035", null);

            // вывод некоторой инфомрации о найденном получателе:
            Console.WriteLine("Организация - дополнительный получатель:");
            Console.WriteLine(moreRecipient.Name);

            // получим все подразделения организации и выберем нужное по КПП
            // в параметр метода передается текущий выбранный ящик
            var departments = client.GetOrganizationStructure(currentBox, moreRecipient.OrganizationId);
            var moreRecipientDepartment = departments.FirstOrDefault(x => x.Kpp == moreRecipientKpp);
            if (moreRecipientDepartment == null)
            {
                Console.WriteLine("Не удалось найти подразделение организации - дополительного получателя по КПП - " +
                                  moreRecipientKpp);
                return;
            }

            // ! т.к. Отправка документов без подписи нескольким контрагентам невозможна,
            // поэтому каждый из списков получателей содержим только одного получателя

            // Но например при отправке документов с подписью возможно отправлять документы сразу нескольких получателям

            // Пример указания определенного подразделения организации - получателя:
            // добавим полученную информацию о подразделении получателя в нужный список получателей
            var messageRecipientsWithDepartments = new List<MessageRecipient>
            {
                new MessageRecipient
                {
                    // ящик организации - получателя
                    OrganizationBoxId = moreRecipient.BoxAddress,
                    // ИД подразделения организации - получателя (необязательный параметр)
                    DepartmentId = moreRecipientDepartment.Id
                }
            };

            // содержимое неформализованного документа из файла на локальном компьютере
            var filesDir = "../../../../..";
            var filePath = filesDir + "/Documents/Неформализованный текстовый документ.txt";
            var fileBytes = File.ReadAllBytes(filePath);

            // Пример создание документов:
            // созданный объект - документ можно использовать при отправке в сообщениях 
            // только 1 раз, т.к. поля должны быть уникальными
            var document1 = new Document
            {
                Id = Guid.NewGuid().ToString(),
                DocumentType = DocumentType.Untyped,
                UntypedKind = null,
                FileName = "Отправка без подписи - первый документ1 - " + Path.GetFileName(filePath),
                Content = fileBytes,
                Card = null,
                NeedSign = false
            };
            // создание 2го документа
            var document2 = new Document
            {
                Id = Guid.NewGuid().ToString(),
                DocumentType = DocumentType.Untyped,
                UntypedKind = null,
                FileName = "Отправка без подписи - второй документ2 - " + Path.GetFileName(filePath),
                Content = fileBytes,
                Card = null,
                NeedSign = false
            };

            // создаем сообщение для отправки
            var unsignedMessage = new UnsignedMessage
            {
                From = currentBox,
                // документы в сообщение
                Documents = new[]
                {
                    document1,
                    document2
                },
                // получатели
                Recipients = messageRecipients.ToArray()
            };


            // создаем сообщение для отправки по второму списку получателей - для примера c указанием подразделений
            // создание 3го документа
            var document3 = new Document
            {
                // для исключения дублирования ID документов - всегда необходимо создание уникальных идентификаторов документов
                Id = Guid.NewGuid().ToString(),
                DocumentType = DocumentType.Untyped,
                UntypedKind = null,
                FileName = "Отправка без подписи - первый документ3 - " + Path.GetFileName(filePath),
                Content = fileBytes,
                Card = null,
                NeedSign = false
            };
            // создание 4го документа
            var document4 = new Document
            {
                Id = Guid.NewGuid().ToString(),
                DocumentType = DocumentType.Untyped,
                UntypedKind = null,
                FileName = "Отправка без подписи - второй документ4 - " + Path.GetFileName(filePath),
                Content = fileBytes,
                Card = null,
                NeedSign = false
            };
            // создание 2го сообщения
            var unsignedMessage2 = new UnsignedMessage
            {
                From = currentBox,
                // документы в сообщение
                Documents = new[]
                {
                    document3,
                    document4
                },
                // получатели
                Recipients = messageRecipientsWithDepartments.ToArray()
            };
            // пример отправки двух сообщений с разными наборами получателей
            // отправляем сообщение 1
            SentMessage result1;
            try
            {
                result1 = client.SendUnsignedMessage(unsignedMessage);
                Console.WriteLine("Успешно отправлено исходящее сообщение с документами без подписи 1");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при отправке сообщения 1" + ex.Message);
                Console.ReadKey();
                return;
            }
            // отправляем сообщение 2
            SentMessage result2;
            try
            {
                result2 = client.SendUnsignedMessage(unsignedMessage2);
                Console.WriteLine("Успешно отправлено исходящее сообщение с документами без подписи 2");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при отправке сообщения 2" + ex.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Успешно отправлено исходящее сообщения");

            Console.WriteLine("Для выхода нажмите enter");
            Console.ReadLine();
        }
    }
}