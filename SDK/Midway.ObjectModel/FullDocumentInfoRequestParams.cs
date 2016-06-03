using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры загрузки полной информации о документе
    /// </summary>
    [DataContract]
    public class FullDocumentInfoRequestParams
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public FullDocumentInfoRequestParams()
        {
            this.GetContent = true;
            this.GetCard = true;
            this.GetRelatedDocuments = true;
            this.GetServiceDocuments = true;
            this.GetSigns = true;
        }

        /// <summary>
        /// Загружать содержимое документа?
        /// </summary>
        [DataMember]
        public bool GetContent { get; set; }

        /// <summary>
        /// Загружать ?
        /// </summary>
        [DataMember]
        public bool GetCard { get; set; }

        /// <summary>
        /// Загружать подписи?
        /// </summary>
        [DataMember]
        public bool GetSigns { get; set; }

        /// <summary>
        /// Загружать служебные документы?
        /// </summary>
        [DataMember]
        public bool GetServiceDocuments { get; set; }

        /// <summary>
        /// Загружать связанные документы?
        /// </summary>
        [DataMember]
        public bool GetRelatedDocuments { get; set; }

        /// <summary>
        /// Загружать предложения об аннулировании?
        /// </summary>
        [DataMember]
        public bool GetRevocationOffers { get; set; }

        /// <summary>
        /// Фильтрация прав для пользователя сервиса по логину через проверку доступа:
        /// TODO - перенести эту проверку в веб клиент?
        /// </summary>
        [DataMember]
        public string UserLogin { get; set; }

        public override string ToString()
        {
            return string.Format("GetContent: {0}, GetCard: {1}, GetSigns: {2}, GetServiceDocuments: {3}, GetRelatedDocuments: {4}", GetContent, GetCard, GetSigns, GetServiceDocuments, GetRelatedDocuments);
        }
    }
}
