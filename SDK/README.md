## Примеры на языке C&#35;

SDK включает в себя примеры кода, написанные на языке C# под платформу .NET, для взаимодействия с сервисом обмена Synerdocs:

* **Midway.ConsoleClient** - консольный клиент;
* **Samples** - примеры операций в сервисе обмена;
* **Midway.ObjectModel** - библиотечная объектная модель API;
* **Midway.ServiceClient** - клиентская библиотека для вызова методов API через SOAP-подключение.

Консольный клиент и примеры в своей работе используют библиотеки **Midway.ObjectModel** и **Midway.ServiceClient**.

### Начало работы

1. Скачайте и распакуйте содержимое репозитория последней версии ([Download ZIP](https://github.com/Synerdocs/synerdocs-sdk/archive/master.zip)) или нужной версии ([Releases](https://github.com/Synerdocs/synerdocs-sdk/releases)).
2. Откройте решение (solution) **Synerdocs.SDK.sln** в Visual Studio (необходима [Visual Studio 2012](https://www.microsoft.com/ru-ru/download/details.aspx?id=30678) или выше).
3. Выберите нужный проект для запуска в Visual Studio (*Set as StartUp Project*) и запустите отладку проекта (*Debug -> Start Debugging*).

### Консольный клиент

Консольный клиент является полноценным клиентом, позволяющим выполнять большинство операций, используя API Synerdocs.

Код консольного клиента является ознакомительным и служит примером использования методов и классов API.

#### Запуск консольного клиента из Visual Studio в режиме отладки

1. Откройте настройки отладки проекта **Midway.ConsoleClient** через контекстное меню (*Properties -> Debug*).
2. В параметры запуска (*Start Options / Command line arguments*) добавьте: `https://testservice.synerdocs.ru/exchangeservice.svc`
3. Запустите проект в режиме отладки (*Debug -> Start Debugging*), при необходимости используйте точки останова.

#### Запуск скомпилированного консольного клиента

1. Скомпилируйте проект **Midway.ConsoleClient** в Visual Studio или скачайте скомпилированную версию консольного клиента в разделе [Downloads](https://github.com/Synerdocs/synerdocs-sdk/releases).
2. Введите в командной строке и нажмите *Enter*: `mclient.exe https://testservice.synerdocs.ru/exchangeservice.svc`

### Примеры (Samples)

Примеры содержат часто используемые операции в сервисе обмена Synerdocs, [подробнее](https://github.com/Synerdocs/synerdocs-sdk/tree/master/SDK/Samples).

#### Запуск примеров из Visual Studio в режиме отладки

1. Укажите нужный проект примера из папки **Samples** солюшена для его запуска по умолчанию в Visual Studio (*Set as Start up project*).
2. Запустите проект в режиме отладки (*Debug -> Start Debugging*), при необходимости используйте точки останова.

#### Запуск примеров, использующих сертификаты

Информацию по использованию СКЗИ и сертификатов читайте [здесь](https://github.com/Synerdocs/synerdocs-sdk/tree/master/Certificates).
