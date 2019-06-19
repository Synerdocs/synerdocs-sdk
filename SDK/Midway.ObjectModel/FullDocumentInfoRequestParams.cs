using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры загрузки полной информации о документе.
    /// </summary>
    [DataContract]
    public class FullDocumentInfoRequestParams
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public FullDocumentInfoRequestParams()
        {
            this.GetContent = true;
            this.GetCard = true;
            this.GetRelatedDocuments = true;
            this.GetServiceDocuments = true;
            this.GetSigns = true;
            this.GetDocumentDeletionState = true;
            this.GetAvailableOperations = true;
        }

        /// <summary>
        /// Загружать содержимое документа?
        /// </summary>
        [DataMember]
        public bool GetContent { get; set; }

        /// <summary>
        /// Загружать карточку документа?
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
        /// Загружать информацию о состоянии документа?
        /// </summary>
        [DataMember]
        public bool GetDocumentDeletionState { get; set; }

        /// <summary>
        /// Загружать информацию о доступных операциях?
        /// </summary>
        [DataMember]
        public bool? GetAvailableOperations { get; set; }

        /// <summary>
        /// Фильтрация прав для пользователя сервиса по логину через проверку доступа:
        /// TODO - перенести эту проверку в веб клиент?
        /// </summary>
        [DataMember]
        public string UserLogin { get; set; }

        /// <summary>
        /// <c>true</c>, если требуется загружать информацию о ролях участников документооборота; иначе - <c>false</c>.
        /// </summary>
        [DataMember]
        public bool GetDocumentFlowParticipantsRoles { get; set; }

        public override string ToString() 
            => $"GetAvailableOperations: {GetAvailableOperations}, " +
               $"GetContent: {GetContent}, " +
               $"GetCard: {GetCard}, " +
               $"GetSigns: {GetSigns}, " +
               $"GetServiceDocuments: {GetServiceDocuments}, " +
               $"GetRelatedDocuments: {GetRelatedDocuments}";
    }
}
