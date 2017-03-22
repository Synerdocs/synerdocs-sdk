using System.Runtime.Serialization;
using Midway.Edi.Api.Errors;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Параметры запроса
    /// </summary>
    [DataContract]
    public class RequestParameters
    {
        /// <summary>
        /// Учетные данные запроса
        /// </summary>
        [DataMember]
        public RequestCredentials Credentials { get; set; }

        /// <summary>
        /// Параметры валидации модели
        /// </summary>
        [DataMember]
        public ModelValidationOptions Validation { get; set; }
    }
}
