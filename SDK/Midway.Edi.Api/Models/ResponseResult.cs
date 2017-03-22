using System.Runtime.Serialization;
using Midway.Edi.Api.Errors;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Результат ответа сервиса
    /// </summary>
    [DataContract]
    public class ResponseResult
    {
        /// <summary>
        /// Код ошибки (0 - ошибки нет)
        /// </summary>
        [DataMember]
        public int ErrorCode { get; set; }

        /// <summary>
        /// Краткий заголовок ошибки
        /// </summary>
        [DataMember]
        public string ErrorTitle { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Результат валидации
        /// </summary>
        [DataMember]
        public ModelValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Значение ошибки
        /// Свойство используется для предоставления в WSDL имеющихся кодов ошибок (ServiceErrorCode)
        /// Значение всегда NULL - для проверки кода ошибки нужно использовать свойство ErrorCode
        /// </summary>
        [DataMember]
        public ServiceErrorCode? ErrorValue { get; set; }
    }
}
