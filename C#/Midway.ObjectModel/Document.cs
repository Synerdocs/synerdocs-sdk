using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о документе.
    /// Используется для отправки и получения документов
    /// </summary>
    [DataContract]
    public class Document
    {
        /// <summary>
        /// Идентификатор документа (не используется при отправке)
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Название документа
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        [DataMember]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Содержимое документа
        /// </summary>
        [DataMember]
        public byte[] Content { get; set; }

        /// <summary>
        /// Карточка документа
        /// </summary>
        [DataMember]
        public byte[] Card { get; set; }

        /// <summary>
        /// Имя файла документа
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Флаг ожидания подписи под документом 
        /// </summary>
        [DataMember]
        public bool NeedSign { get; set; }

        /// <summary>
        /// Размер файла (не используется при отправке)
        /// </summary>
        [DataMember]
        public int FileSize { get; set; }

        /// TODO@internal
        /// <summary>
        /// Идентификатор сообщения, содержащего документ
        /// </summary>
        public Guid MessageId { get; set; }

        /// <summary>
        /// Идентификатор родительского документа в цепочке служебных документов
        /// </summary>
        [DataMember]
        public string ParentDocumentId { get; set; }

        /// <summary>
        /// Идентификатор родительского документа в цепочке логических связей
        /// </summary>
        [DataMember]
        public string SourceDocumentId { get; set; }

        /// <summary>
        /// Идентификатор основного документа, к которому относится служебный документ. 
        /// </summary>
        [DataMember]
        public string RootDocumentId { get; set; }

        /// TODO@internal
        /// <summary>
        /// Тип служебного документа
        /// </summary>
        public DocumentServiceType DocumentServiceType { get; set; }

        /// <summary>
        /// Идентификаторы связанных документов
        /// </summary>
        [DataMember]
        public string[] RelatedDocumentIds { get; set; }

        /// <summary>
        /// Комментарий к документу
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Поле для хранение дополнительной информации. До 255 символов.
        /// </summary>
        [DataMember]
        public string CustomField { get; set; }

        /// TODO@перенести
        /// <summary>
        /// Признак "удаления"
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Флаг юридической значимости документа
        /// </summary>
        [DataMember(IsRequired = false)]
        public bool IsLegitimate { get; set; }

        /// <summary>
        /// Причины нелегитимности документа, указываются в виде битовой маски
        /// </summary>
        [DataMember(IsRequired = false)]
        public NonLegitimateReason[] NonLegitimateReasons { get; set; }

        /// <summary>
        /// Вид нетипизированного документа
        /// </summary>
        [DataMember(IsRequired = false)]
        public string UntypedKind { get; set; }
        
        /// <summary>
        /// Флаг "Необходимость генерации извещения о получении"
        /// </summary>
        [DataMember(IsRequired = false)]
        public bool NoticeRequired { get; set; }

        /// <summary>
        /// Итоговая стоимость документа, включая налоги, НДС и т.п.
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? Sum { get; set; }

        /// <summary>
        /// Номер документа, указанный пользователем
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Number { get; set; } 

        /// <summary>
        /// Дата документа, указанная пользователем
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Флаг "Необходимость подтверждения факта приема документа"
        /// </summary>
        [DataMember]
        public bool NeedReceipt { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? SentDate { get; set; }

        /// <summary>
        /// Ящик отправителя
        /// </summary>
        [DataMember]
        public string FromBoxId { get; set; }
    }
}
