# Synerdocs SDK
Программный интерфейс Synerdocs позволяет выполнять все основные операции по приёму, отправке и обработке юридически значимых электронных документов через сервис обмена.

SDK включает в себя примеры кода работы с сервисм обмена на языке C#. Для запуска примеров неоходима [Visual Studio 2012](https://www.microsoft.com/ru-ru/download/details.aspx?id=30678) или выше. Интеграция с сервисом возможна на любой платформе, которая поддерживаент работу с протоколом [SOAP](https://ru.wikipedia.org/wiki/SOAP), WSDL достпуна по адресу https://service.synerdocs.ru/ExchangeService.svc?wsdl.

Соедржимое SDK:
 * Midway.ObjectModel объяектная модель
 * Midway.ServiceClient клиентская библиотека
 * Midway.ConsoleClient консольный клиент

Как запустить пример:
 * Открыть Mdway.SDK.sln в Visual Studio
 * Запустить сборку
 * Запустить из комндной строки Midway.ConsoleClient\bin\Debug\mclient.exe https://service.synerdocs.ru/ExchangeService.svc


