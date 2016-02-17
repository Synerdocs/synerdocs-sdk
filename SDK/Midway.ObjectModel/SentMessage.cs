using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация об отправленном сообщении
    /// </summary>
    [DataContract]
    public class SentMessage
    {
        /// <summary>
        /// Сгенерированный идентификатор сообщения
        /// </summary>
        [DataMember]
        public string MessageId { get; set; }

        /// <summary>
        /// Сгенерированные идентификаторы документов: локальные и серверные
        /// Ключ - входящий идентификатор
        /// </summary>
        [DataMember]
        public LocalServerId[] DocumentIds { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        [DataMember]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Сгенерированные идентификаторы подписей: локальные и серверные.
        /// </summary>
        [DataMember]
        public LocalServerId[] SignIds { get; set; }

        /// <summary>
        /// Лог отправки. Здесь могут быть сообщения о событиях, возникших в ходе обработки и отправки сообщения
        /// </summary>
        [DataMember]
        public string[] Log { get; set; }
    }
}
