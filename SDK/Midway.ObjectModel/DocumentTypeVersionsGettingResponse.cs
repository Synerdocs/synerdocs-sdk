using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос на получение версий типа документа.
    /// </summary>
    [DataContract]
    public class DocumentTypeVersionsGettingResponse : OperationResponse
    {
        /// <summary>
        /// Список версий типа документа.
        /// </summary>
        [DataMember]
        public List<DocumentTypeVersion> DocumentTypeVersions { get; set; }
    }
}
