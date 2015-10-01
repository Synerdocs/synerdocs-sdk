using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Полная информация о документе
    /// Включает в себя подписи, статусы, служебные документы и связи.
    /// Также включается информация по документоообороту и вхождениям
    /// </summary>
    [DataContract]
    public class FlowDocumentInfo : FullDocumentInfo
    {
        /// <summary>
        /// Документообороты
        /// </summary>
        [DataMember]
        public DocumentFlow[] Flows { get; set; }

        /// <summary>
        /// Вхождения документа
        /// </summary>
        [DataMember]
        public DocumentEntry[] Entries { get; set; }

        /// <summary>
        /// Тип документооборота у документа
        /// Для документа может принимать следующие значения:
        /// - <c>FlowType.SentSigned</c>
        /// - <c>FlowType.SentUnsigned</c>
        /// - <c>FlowType.SentInternal</c>
        /// Нет значения <c>FlowType.SentForward</c>, т.к. при
        /// пересылке нового документа не создается
        /// </summary>
        [DataMember]
        public FlowType FlowType { get; set; }
    }
}
