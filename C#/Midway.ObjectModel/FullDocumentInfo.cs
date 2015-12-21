﻿using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Полная информация о документе
    /// Включает в себя подписи, статусы, служебные документы и связи.
    /// </summary>
    [DataContract]
    public class FullDocumentInfo
    {
        /// <summary>
        /// Адрес абонентского ящика отправителя
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// Идентификатор подразделения отправителя
        /// </summary>
        [DataMember]
        public string FromDepartmentId { get; set; }

        /// <summary>
        /// Адрес абонентского ящика получателя
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public string To { get; set; }

        /// <summary>
        /// Идентификатор подразделения получателя
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public string ToDepartmentId { get; set; }

        /// <summary>
        /// Список получателей документа со статусами
        /// </summary>
        [DataMember]
        public MessageRecipientWithStatus[] Recipients { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        [DataMember]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Данные о документе
        /// </summary>
        [DataMember]
        public Document Document { get; set; }

        /// <summary>
        /// Подписи к документу
        /// </summary>
        [DataMember]
        public Sign[] Signs { get; set; }

        /// <summary>
        /// Статус документооборота для текущего абонента
        /// </summary>
        [DataMember]
        public DocumentFlowStatus Status { get; set; }

        /// <summary>
        /// Общий статус по документу, отправленному нескольким контрагентам
        /// </summary>
        [DataMember]
        public UntypedDocumentMultiFlowStatus MultiStatus { get; set; }

        /// <summary>
        /// Служебные документы, относящиеся к данному документу
        /// </summary>
        [DataMember]
        public ServiceDocument[] ServiceDocuments { get; set; }

        /// <summary>
        /// Связанные документы
        /// </summary>
        [DataMember]
        public Document[] RelatedDocuments { get; set; }

        /// TODO для чего он здесь нужен, если эта информация должна уже содержаться в Docuemnt.Comment?
        /// TODO нигде не используется УДАЛИТЬ
        /// <summary>
        /// Комментарий к документу
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        [DataMember]
        public string MessageId { get; set; }

        /// <summary>
        /// Количество связанных документов
        /// </summary>
        [DataMember(IsRequired = false)]
        public int CountRelatedDocuments { get; set; }

        /// <summary>
        /// Текстовое описание полного текущего статуса документооборота относительно абонента
        /// </summary>
        [DataMember]
        public DocumentFlowStatusDescription DocumentFlowStatusDescription { get; set; }
    }
}
