using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на получение версий типа документа.
    /// </summary>
    [DataContract]
    public class DocumentTypeVersionsGettingRequest : OperationRequest
    {
        /// <summary>
        /// Тип документа.
        /// </summary>
        [DataMember(IsRequired = false)]
        public EnumValue DocumentType { get; set; }

        /// <summary>
        /// Номер версии типа документа.
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? VersionNumber { get; set; }

        /// <summary>
        /// Дата, на которую запрашивается получение действующих версий типа документа.
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTimeOffset? Date { get; set; }
    }
}
