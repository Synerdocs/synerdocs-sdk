using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос поиска на получение списка центров идентификации облачного провайдера.
    /// </summary>
    [DataContract]
    public class ProviderIdentificationCentersSearchingResponse
    {
        /// <summary>
        /// Список действующих центров идентификации облачного провайдера.
        /// </summary>
        [DataMember]
        public List<ProviderIdentificationCenter> IdentificationCenters { get; set; }
    }
}