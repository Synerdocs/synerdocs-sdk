using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Идентификатор отправленного документа
    /// </summary>
    [DataContract]
    public class LocalServerId
    {
        /// <summary>
        /// Локальный идентификатор документа (на стороне клиента)
        /// </summary>
        [DataMember]
        public string LocalId { get; set; }

        /// <summary>
        /// Идентификатор документа в сервисе обмена
        /// </summary>
        [DataMember]
        public string ServiceId { get; set; }
    }
}