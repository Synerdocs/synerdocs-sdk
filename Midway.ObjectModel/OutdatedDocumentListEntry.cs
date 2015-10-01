using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о документе.
    /// Используется для получения списка документов в ящике
    /// </summary>
    [DataContract]
    public class OutdatedDocumentListEntry : DocumentListEntry
    {
        /// <summary>
        /// Флаг - исходящий ли это документ для выборки по текущему пользователю
        /// (или по выборке по логину пользователя)
        /// </summary>
        [DataMember]
        public bool IsIncoming { get; set; }

        /// <summary>
        /// Тип группы для старых документов
        /// </summary>
        [DataMember]
        public string NoticeType { get; set; }

        /// <summary>
        /// Название организации-отправителя
        /// </summary>
        [DataMember]
        public new string FromOrganizationName { get; set; }

        /// <summary>
        /// Название организации-получателя
        /// </summary>
        [DataMember]
        public new string ToOrganizationName { get; set; }

        /// <summary>
        /// Название организации-отправителя
        /// </summary>
        [DataMember]
        public string FromOrganizationLegalName { get; set; }

        /// <summary>
        /// Название организации-получателя
        /// </summary>
        [DataMember]
        public string ToOrganizationLegalName { get; set; }

    }
}