# Synerdocs SDK
Программный интерфейс сервиса обмена Synerdocs позволяет выполнять операции по приёму, отправке и обработке электронных документов.

SDK включает в себя примеры кода работы с сервисом обмена на языке C#. Содержимое SDK:
 * Midway.ObjectModel объектная модель
 * Midway.ServiceClient клиентская библиотека
 * Midway.ConsoleClient консольный клиент
 * Samples - консольные примеры использования библиотек

Для запуска примеров необходима [Visual Studio 2012](https://www.microsoft.com/ru-ru/download/details.aspx?id=30678) или выше. Интеграция с сервисом возможна на любой платформе, которая поддерживаент работу с протоколом [SOAP](https://ru.wikipedia.org/wiki/SOAP), WSDL доступна по адресу https://service.synerdocs.ru/ExchangeService.svc?wsdl.

Как запустить пример:
 * Открыть Mdway.SDK.sln в Visual Studio
 * Запустить сборку
 * Запустить из командной строки 
```
Midway.ConsoleClient\bin\Debug\mclient.exe https://service.synerdocs.ru/ExchangeService.svc
```

Либо:

### для запуска консольного клиента в режиме отладки:

 * Выбрать для проекта ```Midway.ConsoleClient``` в контекстном меню Properties -> Debug 
 * убедиться, что настроен параметр запуска в режиме отладки из командной строки:
    Start Options \ Command line arguments     
	https://testservice.synerdocs.ru/exchangeservice.svc
 * Запустить проект в режиме отладки Debug -> Start Debugging, использовать отладку при необходимости

### для запуска консольных приложений - примеров использования библиотек:

 * Указать нужный проект - пример использования из ```\Samples``` для запуска по умолчанию в Visual Studio (Set as Start up project)
 * Запустить выбранный проект в режиме отладки Debug -> Start Debugging 


## Ссылки. Форматы документов, используемых в сервисе

### Cчета-фактуры (ИСФ, КСФ и ИКСФ):

 * [Приказ от 04.03.2015 № ММВ-7-6/93](https://www.nalog.ru/rn18/about_fts/docs/5433729/)  Об утверждении форматов счета-фактуры, журнала учета полученных и выставленных счетов-фактур, книги покупок и книги продаж, дополнительных листов книги покупок и книги продаж в электронной форме

### ТН и акты:

 * [Приказ от 21.03.2012 № ММВ-7-6/172](https://www.nalog.ru/rn18/about_fts/docs/3908415/) Об утверждении форматов первичных учетных документов
 * и [изменения к приказу и акутальные схемы](https://www.nalog.ru/rn18/about_fts/docs/5330915/)

### Прочее:
 * [online валидатор](http://www.utilities-online.info/xsdvalidation/) XML документов по XSD схемам

