using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.Edi.Api.Errors
{
    /// <summary>
    /// Код ошибки сервиса
    /// </summary>
    [DataContract]
    public enum ServiceErrorCode
    {
        /// <summary>
        /// Нет ошибки
        /// </summary>
        [EnumMember]
        [Description("Нет ошибки")]
        NoError = 0,

        /// <summary>
        /// Неожиданная ошибка сервера
        /// </summary>
        [EnumMember]
        [Description("Неожиданная ошибка сервера")]
        UnexpectedServerError = 1,

        /// <summary>
        /// Неправильный токен аутентификации либо истек срок его действия
        /// </summary>
        [EnumMember]
        [Description("Неправильный токен аутентификации либо истек срок его действия")]
        Unauthorized = 2,

        /// <summary>
        /// Ошибка доступа пользователя к ящику организации
        /// </summary>
        [EnumMember]
        [Description("Ошибка доступа пользователя к ящику организации")]
        BoxAccessError = 3,

        /// <summary>
        /// Организация не зарегистрирована в сервисе Synerdocs как абонент EDI
        /// </summary>
        [EnumMember]
        [Description("Организация не зарегистрирована в сервисе Synerdocs как абонент EDI")]
        SubscriberNotExists = 4,

        /// <summary>
        /// Ошибка получения списка файлов
        /// </summary>
        [EnumMember]
        [Description("Ошибка получения списка файлов")]
        GetFileListError = 5,

        /// <summary>
        /// Ошибка получения файла
        /// </summary>
        [EnumMember]
        [Description("Ошибка получения файла")]
        GetFileError = 6,

        /// <summary>
        /// Файл не найден
        /// </summary>
        [EnumMember]
        [Description("Файл не найден")]
        FileNotFound = 7,

        /// <summary>
        /// Ошибка создания файла
        /// </summary>
        [EnumMember]
        [Description("Ошибка создания файла")]
        CreateFileError = 8,

        /// <summary>
        /// Ошибка архивирования файла
        /// </summary>
        [EnumMember]
        [Description("Ошибка архивирования файла")]
        ArchiveFileError = 9,

        /// <summary>
        /// Файл не найден или не может быть архивирован
        /// </summary>
        [EnumMember]
        [Description("Файл не найден или не может быть архивирован")]
        FileNotFoundOrCanNotBeArchived = 10,

        /// <summary>
        /// Ошибка валидации аргументов метода
        /// </summary>
        [EnumMember]
        [Description("Ошибка валидации аргументов метода")]
        ValidationError = 11,

        /// <summary>
        /// Не удалось найти организацию с указанным ящиком
        /// </summary>
        [EnumMember]
        [Description("Не удалось найти организацию с указанным ящиком")]
        OrganizationNotFound = 12,

        /// <summary>
        /// Не удалось найти точку доставки/отправки с указанным ИД
        /// </summary>
        [EnumMember]
        [Description("Не удалось найти точку доставки/отправки с указанным ИД")]
        LocationNotFound = 13,

        /// <summary>
        /// Доступ к точке доставки/отправки запрещен
        /// </summary>
        [EnumMember]
        [Description("Доступ к точке доставки/отправки запрещен")]
        LocationAccessDenied = 14,

        /// <summary>
        /// Точка доставки/отправки с указанным ИД уже существует
        /// </summary>
        [EnumMember]
        [Description("Точка доставки/отправки с указанным ИД уже существует")]
        LocationAlreadyExists = 15,
    }
}
