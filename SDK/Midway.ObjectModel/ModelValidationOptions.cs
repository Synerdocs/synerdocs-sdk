using System.Runtime.Serialization;

namespace Midway.ObjectModel
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
