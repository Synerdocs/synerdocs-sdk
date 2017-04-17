using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры запроса
    /// </summary>
    [DataContract]
    public class RequestParameters
    {
        /// <summary>
        /// Параметры валидации модели
        /// </summary>
        [DataMember]
        public ModelValidationOptions ValidationOptions { get; set; }
    }
}
