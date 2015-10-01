using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры поиска/фильтрации списка вхождений документов
    /// </summary>
    [DataContract]
    public class DocumentEntryOptions : DocumentListOptions
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DocumentEntryOptions()
        {
            DocumentFlowTypes = new[]
            {
                DocumentFlowType.SentSigned,
                DocumentFlowType.SentUnsigned,
                DocumentFlowType.SentPrepared,
                DocumentFlowType.SentForward,
            };
        }

        /// <summary>
        /// Типы документооборота
        /// </summary>
        [DataMember]
        public DocumentFlowType[] DocumentFlowTypes { get; set; }
    }
}