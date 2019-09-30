using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на перемещение документа из одного подразделения в другое.
    /// </summary>
    [DataContract]
    public class DocumentMovingRequest : OperationRequest
    {
        /// <summary>
        /// ИД перемещаемого документа.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string DocumentId { get; set; }

        /// <summary>
        /// ИД подразделения, из которого нужно переместить документ.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// ИД подразделения, в которое нужно переместить документ.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ToDepartmentId { get; set; }
    }
}
