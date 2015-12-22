using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры загрузки полной информации о документе
    /// включая информацию по документооборотам и вхождениям
    /// </summary>
    [DataContract]
    public class FlowDocumentInfoRequestParams : FullDocumentInfoRequestParams
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public FlowDocumentInfoRequestParams()
        {
            GetEntries = true;
            GetRelatedUnsigned = true;
            FlowResult = DocumentFlowResultMode.FullInfo;
        }

        /// <summary>
        /// Загружать вхождения документа?
        /// </summary>
        [DataMember]
        public bool GetEntries { get; set; }

        /// <summary>
        /// Загружать связанные документы без подписи?
        /// </summary>
        [DataMember]
        public bool GetRelatedUnsigned { get; set; }

        /// <summary>
        /// Режим получения документооборотов (DocumentFlow)
        /// Если <c>None</c>, то документообороты не загружаются
        /// </summary>
        [DataMember]
        public DocumentFlowResultMode FlowResult { get; set; }
    }
}
