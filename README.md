# Synerdocs SDK
Программный интерфейс сервиса обмена Synerdocs позволяет выполнять операции по приёму, отправке и обработке электронных документов.

SDK включает в себя примеры кода работы с сервисом обмена на языке C#. Содержимое SDK:
 * Midway.ObjectModel объектная модель
 * Midway.ServiceClient клиентская библиотека
 * Midway.ConsoleClient консольный клиент

Для запуска примеров необходима [Visual Studio 2012](https://www.microsoft.com/ru-ru/download/details.aspx?id=30678) или выше. Интеграция с сервисом возможна на любой платформе, которая поддерживаент работу с протоколом [SOAP](https://ru.wikipedia.org/wiki/SOAP), WSDL доступна по адресу https://service.synerdocs.ru/ExchangeService.svc?wsdl.

Как запустить пример:
 * Открыть Mdway.SDK.sln в Visual Studio
 * Запустить сборку
 * Запустить из командной строки 
```
Midway.ConsoleClient\bin\Debug\mclient.exe https://service.synerdocs.ru/ExchangeService.svc
```
