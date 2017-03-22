using System;
using System.Threading.Tasks;
using Midway.Edi.Api.Models;

namespace Midway.Edi.Api.Client.Gateways
{
    /// <summary>
    /// Шлюз к сервису EDI
    /// </summary>
    public interface IEdiServiceGateway
    {
        /// <summary>
        /// Получить список файлов
        /// </summary>
        /// <param name="request">Запрос получения списка файлов</param>
        /// <returns>Ответ получения списка файлов</returns>
        GetFileListResponse GetFileList(GetFileListRequest request);

        /// <summary>
        /// Получить асинхронно список файлов
        /// </summary>
        /// <param name="request">Запрос получения списка файлов</param>
        /// <returns>Ответ получения списка файлов</returns>
        Task<GetFileListResponse> GetFileListAsync(GetFileListRequest request);

        /// <summary>
        /// Получить документ
        /// </summary>
        /// <param name="request">Запрос получения документа</param>
        /// <returns>Ответ получения документа</returns>
        GetDocumentResponse GetDocument(GetDocumentRequest request);

        /// <summary>
        /// Получить асинхронно документ
        /// </summary>
        /// <param name="request">Запрос получения документа</param>
        /// <returns>Ответ получения документа</returns>
        Task<GetDocumentResponse> GetDocumentAsync(GetDocumentRequest request);

        /// <summary>
        /// Отправить документ
        /// </summary>
        /// <param name="request">Запрос отправки документа</param>
        /// <returns>Ответ отправки документа</returns>
        SendDocumentResponse SendDocument(SendDocumentRequest request);

        /// <summary>
        /// Отправить асинхронно документ
        /// </summary>
        /// <param name="request">Запрос отправки документа</param>
        /// <returns>Ответ отправки документа</returns>
        Task<SendDocumentResponse> SendDocumentAsync(SendDocumentRequest request);

        /// <summary>
        /// Архивировать документ
        /// </summary>
        /// <param name="request">Запрос архивирования документа</param>
        /// <returns>Ответ архивирования документа</returns>
        ArchiveDocumentResponse ArchiveDocument(ArchiveDocumentRequest request);

        /// <summary>
        /// Архивировать асинхронно документ
        /// </summary>
        /// <param name="request">Запрос архивирования документа</param>
        /// <returns>Ответ архивирования документа</returns>
        Task<ArchiveDocumentResponse> ArchiveDocumentAsync(ArchiveDocumentRequest request);

        /// <summary>
        /// Получить точку доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="id">Внешний ИД точка доставки/отправки</param>
        /// <returns>Результат получения точки доставки/отправки</returns>
        EdiLocationResponse GetLocation(RequestParameters parameters, Guid id);

        /// <summary>
        /// Получить асинхронно точку доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="id">Внешний ИД точка доставки/отправки</param>
        /// <returns>Результат получения точки доставки/отправки</returns>
        Task<EdiLocationResponse> GetLocationAsync(RequestParameters parameters, Guid id);

        /// <summary>
        /// Выполнить поиск точек доставки/отправки для заданной организации и/или GLN
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="options">Параметры поиска</param>
        /// <returns>Результаты поиска</returns>
        EdiLocationListResponse SearchLocations(RequestParameters parameters, EdiLocationListOptions options);

        /// <summary>
        /// Выполнить асинхронно поиск точек доставки/отправки для заданной организации
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="options">Параметры поиска</param>
        /// <returns>Результаты поиска</returns>
        Task<EdiLocationListResponse> SearchLocationsAsync(RequestParameters parameters, EdiLocationListOptions options);

        /// <summary>
        /// Создать новую точку доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="location">Точка доставки/отправки</param>
        /// <returns>Результат создания точки доставки/отправки</returns>
        EdiLocationResponse CreateLocation(RequestParameters parameters, EdiLocation location);

        /// <summary>
        /// Создать асинхронно новую точку доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="location">Точка доставки/отправки</param>
        /// <returns>Результат создания точки доставки/отправки</returns>
        Task<EdiLocationResponse> CreateLocationAsync(RequestParameters parameters, EdiLocation location);

        /// <summary>
        /// Изменить существующую точку доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="location">Точка доставки/отправки</param>
        /// <returns>Результат изменения точки доставки/отправки</returns>
        EdiLocationResponse UpdateLocation(RequestParameters parameters, EdiLocation location);

        /// <summary>
        /// Изменить асинхронно существующую точку доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="location">Точка доставки/отправки</param>
        /// <returns>Результат изменения точки доставки/отправки</returns>
        Task<EdiLocationResponse> UpdateLocationAsync(RequestParameters parameters, EdiLocation location);

        /// <summary>
        /// Удалить существующую точку доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="id">Внешний ИД точки доставки/отправки</param>
        /// <returns>Результат удаления точки доставки/отправки</returns>
        EdiLocationResponse DeleteLocation(RequestParameters parameters, Guid id);

        /// <summary>
        /// Удалить асинхронно существующую точку доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="id">Внешний ИД точки доставки/отправки</param>
        /// <returns>Результат удаления точки доставки/отправки</returns>
        Task<EdiLocationResponse> DeleteLocationAsync(RequestParameters parameters, Guid id);

        /// <summary>
        /// Отменить запрос на регистрацию точки доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="id">Внешний ИД точки доставки/отправки</param>
        /// <returns>Результат отмены заявки на регистрацию точки доставки/отправки</returns>
        EdiLocationResponse CancelLocationRegistrationRequest(RequestParameters parameters, Guid id);

        /// <summary>
        /// Отменить асинхронно запрос на регистрацию точки доставки/отправки
        /// </summary>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="id">Внешний ИД точки доставки/отправки</param>
        /// <returns>Результат отмены заявки на регистрацию точки доставки/отправки</returns>
        Task<EdiLocationResponse> CancelLocationRegistrationRequestAsync(RequestParameters parameters, Guid id);
    }
}
