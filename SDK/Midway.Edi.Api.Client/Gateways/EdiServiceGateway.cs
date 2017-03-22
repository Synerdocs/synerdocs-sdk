using System;
using System.Threading.Tasks;
using System.Configuration;
using Midway.Edi.Api.Models;
using Midway.Edi.Api.Client.EdiServiceReference;

namespace Midway.Edi.Api.Client.Gateways
{
    /// <summary>
    /// Шлюз к сервису EDI
    /// </summary>
    public class EdiServiceGateway : IEdiServiceGateway
    {
        private static readonly string EdiServiceEndpointKey = "midway:EdiServiceEndpoint";

        /// <summary>
        /// Наименование конфигурации конечной точки
        /// </summary>
        public string EndpointConfigurationName { get; set; }

        /// <summary>
        /// Удаленный адрес
        /// </summary>
        public string RemoteAddress { get; set; }

        /// <summary>
        /// Создать новый экземпляр шлюза к сервису EDI с конечной точкой из файла конфигурации
        /// </summary>
        public EdiServiceGateway()
        {
            EndpointConfigurationName = ConfigurationManager.AppSettings[EdiServiceEndpointKey];
        }

        /// <summary>
        /// Создать новый экземпляр шлюза к сервису EDI с указанием наименования конфигурации конечной точки
        /// </summary>
        /// <param name="endpointConfigurationName">Наименование конфигурации конечной точки</param>
        public EdiServiceGateway(string endpointConfigurationName)
        {
            EndpointConfigurationName = endpointConfigurationName;
        }

        /// <summary>
        /// Создать новый экземпляр шлюза к сервису EDI с указанием наименования конфигурации конечной точки и удаленного адреса
        /// </summary>
        /// <param name="endpointConfigurationName">Наименование конфигурации конечной точки</param>
        /// <param name="remoteAddress">Удаленный адрес</param>
        public EdiServiceGateway(string endpointConfigurationName, string remoteAddress)
            : this(endpointConfigurationName)
        {
            RemoteAddress = remoteAddress;
        }

        public GetFileListResponse GetFileList(GetFileListRequest request)
        {
            var response = Invoke(_ => _.GetFileList(request));
            return response;
        }

        public Task<GetFileListResponse> GetFileListAsync(GetFileListRequest request)
        {
            var response = InvokeAsync(_ => _.GetFileListAsync(request));
            return response;
        }

        public GetDocumentResponse GetDocument(GetDocumentRequest request)
        {
            var response = Invoke(_ => _.GetDocument(request));
            return response;
        }

        public Task<GetDocumentResponse> GetDocumentAsync(GetDocumentRequest request)
        {
            var response = InvokeAsync(_ => _.GetDocumentAsync(request));
            return response;
        }

        public SendDocumentResponse SendDocument(SendDocumentRequest request)
        {
            var response = Invoke(_ => _.SendDocument(request));
            return response;
        }

        public Task<SendDocumentResponse> SendDocumentAsync(SendDocumentRequest request)
        {
            var response = InvokeAsync(_ => _.SendDocumentAsync(request));
            return response;
        }

        public ArchiveDocumentResponse ArchiveDocument(ArchiveDocumentRequest request)
        {
            var response = Invoke(_ => _.ArchiveDocument(request));
            return response;
        }

        public Task<ArchiveDocumentResponse> ArchiveDocumentAsync(ArchiveDocumentRequest request)
        {
            var response = InvokeAsync(_ => _.ArchiveDocumentAsync(request));
            return response;
        }

        public EdiLocationResponse GetLocation(RequestParameters parameters, Guid id)
        {
            var response = Invoke(_ => _.GetLocation(parameters, id));
            return response;
        }

        public Task<EdiLocationResponse> GetLocationAsync(RequestParameters parameters, Guid id)
        {
            var response = InvokeAsync(_ => _.GetLocationAsync(parameters, id));
            return response;
        }

        public EdiLocationListResponse SearchLocations(RequestParameters parameters, EdiLocationListOptions options)
        {
            var response = Invoke(_ => _.SearchLocations(parameters, options));
            return response;
        }

        public Task<EdiLocationListResponse> SearchLocationsAsync(RequestParameters credentials, EdiLocationListOptions options)
        {
            var response = InvokeAsync(_ => _.SearchLocationsAsync(credentials, options));
            return response;
        }

        public EdiLocationResponse CreateLocation(RequestParameters parameters, EdiLocation location)
        {
            var response = Invoke(_ => _.CreateLocation(parameters, location));
            return response;
        }

        public Task<EdiLocationResponse> CreateLocationAsync(RequestParameters parameters, EdiLocation location)
        {
            var response = InvokeAsync(_ => _.CreateLocationAsync(parameters, location));
            return response;
        }

        public EdiLocationResponse UpdateLocation(RequestParameters parameters, EdiLocation location)
        {
            var response = Invoke(_ => _.UpdateLocation(parameters, location));
            return response;
        }

        public Task<EdiLocationResponse> UpdateLocationAsync(RequestParameters parameters, EdiLocation location)
        {
            var response = InvokeAsync(_ => _.UpdateLocationAsync(parameters, location));
            return response;
        }

        public EdiLocationResponse DeleteLocation(RequestParameters parameters, Guid id)
        {
            throw new NotSupportedException();
        }

        public Task<EdiLocationResponse> DeleteLocationAsync(RequestParameters parameters, Guid id)
        {
            throw new NotSupportedException();
        }

        public EdiLocationResponse CancelLocationRegistrationRequest(RequestParameters parameters, Guid id)
        {
            var response = Invoke(_ => _.CancelLocationRegistrationRequest(parameters, id));
            return response;
        }

        public Task<EdiLocationResponse> CancelLocationRegistrationRequestAsync(RequestParameters parameters, Guid id)
        {
            var response = InvokeAsync(_ => _.CancelLocationRegistrationRequestAsync(parameters, id));
            return response;
        }

        /// <summary>
        /// Выполнить метод сервиса
        /// </summary>
        /// <typeparam name="TResult">Тип результата метода</typeparam>
        /// <param name="action">Делегат метода сервиса</param>
        /// <returns>Результат метода</returns>
        private TResult Invoke<TResult>(Func<EdiServiceClient, TResult> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var client = CreateClient();

            try
            {
                var result = action(client);
                client.Close();
                return result;
            }
            catch
            {
                client.Abort();
                throw;
            }
        }

        /// <summary>
        /// Выполнить асинхронно метод сервиса
        /// </summary>
        /// <typeparam name="TResult">Тип результата метода</typeparam>
        /// <param name="action">Делегат метода сервиса</param>
        /// <returns>Результат метода</returns>
        private async Task<TResult> InvokeAsync<TResult>(Func<EdiServiceClient, Task<TResult>> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            var client = CreateClient();

            try
            {
                var result = await action(client);
                client.Close();
                return result;
            }
            catch
            {
                client.Abort();
                throw;
            }
        }

        /// <summary>
        /// Создать WCF-клиент для EDI сервиса
        /// </summary>
        /// <returns>WCF-клиент</returns>
        private EdiServiceClient CreateClient()
        {
            var endpointConfigurationName = EndpointConfigurationName;
            var remoteAddress = RemoteAddress;

            var client = !string.IsNullOrWhiteSpace(endpointConfigurationName)
                ? !string.IsNullOrWhiteSpace(remoteAddress)
                    ? new EdiServiceClient(endpointConfigurationName, remoteAddress)
                    : new EdiServiceClient(endpointConfigurationName)
                : new EdiServiceClient();
            return client;
        }
    }
}
