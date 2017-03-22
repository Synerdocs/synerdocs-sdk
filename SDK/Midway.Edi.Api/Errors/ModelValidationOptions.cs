using System.Runtime.Serialization;

namespace Midway.Edi.Api.Errors
{
    /// <summary>
    /// Параметры валидации модели
    /// </summary>
    [DataContract]
    public class ModelValidationOptions
    {
        /// <summary>
        /// Формат результата валидации
        /// </summary>
        [DataMember]
        public ValidationResultFormatEnum ResultFormat { get; set; }
    }
}
