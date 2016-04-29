using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры загрузки информации о сообщении
    /// </summary>
    [DataContract]
    public class MessageRequestParams
    {
        /// <summary>
        /// Получать контент документов
        /// </summary>
        [DataMember]
        public bool GetDocumentContent { get; set; }

        /// <summary>
        /// Получать контент подписи
        /// </summary>
        [DataMember]
        public bool GetSignContent { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MessageRequestParams()
        {
            GetDocumentContent = true;
            GetSignContent = true;
        }
    }
}
