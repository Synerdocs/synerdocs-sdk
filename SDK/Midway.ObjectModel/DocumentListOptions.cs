using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры поиска/фильтрации списка документов.
    /// </summary>
    [DataContract]
    public class DocumentListOptions
    {
        /// <summary>
        /// Отправитель.
        /// </summary>
        [DataMember]
        public string BoxFrom { get; set; }

        /// <summary>
        /// Получатель.
        /// </summary>
        [DataMember]
        public string BoxTo { get; set; }

        /// <summary>
        /// Дата отправки документа с.
        /// </summary>
        [DataMember]
        public DateTime? From { get; set; }

        /// <summary>
        /// Дата отправки документа по.
        /// </summary>
        [DataMember]
        public DateTime? To { get; set; }

        /// <summary>
        /// Дата документа включительно, с которой будет производиться поиск.
        /// </summary>
        [DataMember]
        public DateTime? DocumentDateFrom { get; set; }

        /// <summary>
        /// Дата документа включительно, по которую будет производиться поиск.
        /// </summary>
        [DataMember]
        public DateTime? DocumentDateTo { get; set; }

        /// <summary>
        /// Номер первой записи.
        /// </summary>
        [DataMember]
        public int First { get; set; }

        /// <summary>
        /// Максимальное количество документов в списке.
        /// </summary>
        [DataMember]
        public int Max { get; set; }

        /// <summary>
        /// Типы документов.
        /// </summary>
        [DataMember]
        public DocumentType[] DocumentTypes { get; set; }

        /// <summary>
        /// Типы документов в виде EnumValue.
        /// </summary>
        [DataMember]
        public EnumValue[] DocumentTypeEnums { get; set; }

        /// <summary>
        /// Ящики контрагентов.
        /// </summary>
        [DataMember]
        public string[] ContragentBoxIds { get; set; }

        /// <summary>
        /// Статусы ЭСФ.
        /// </summary>
        [DataMember]
        public InvoiceFlowStatus[] InvoiceFlowStatuses { get; set; }

        /// <summary>
        /// Статусы подписания документов.
        /// </summary>
        [DataMember]
        public DocumentSignStatus[] DocumentSignStatuses { get; set; }
        
        /// <summary>
        /// Статусы аннулирования документов.
        /// </summary>
        [DataMember]
        public DocumentRevocationStatus[] DocumentRevocationStatuses { get; set; }

        /// <summary>
        /// Типы тегов, документы с которыми нужно включить.
        /// </summary>
        [DataMember]
        public List<EnumValue> IncludedDocumentTagTypes { get; set; }

        /// <summary>
        /// Типы тегов, документы с которыми нужно исключить.
        /// </summary>
        [DataMember]
        public List<EnumValue> ExcludedDocumentTagTypes { get; set; }

        /// <summary>
        /// Требуется подтверждение получения.
        /// </summary>
        [DataMember]
        public bool? NeedReceipt { get; set; }

        /// <summary>
        /// Номера документов.
        /// </summary>
        [DataMember]
        public string[] DocumentNumbers { get; set; }

        /// <summary>
        /// Получить параметры поиска/фильтрации в виде строки.
        /// </summary>
        /// <returns>
        /// Строка в параметрами поиска/фильтрации содержащая адрес отправителя, адрес получателя, дату с, дата по,
        /// номер первой записи, максимальное количество документов в списке.
        /// </returns>
        public override string ToString()
            => $"BoxFrom: {BoxFrom}, BoxTo: {BoxTo}, From: {From}, To: {To}, DocumentDateFrom: {DocumentDateFrom}, DocumentDateTo: {DocumentDateTo}, First: {First}, Max: {Max}";
    }
}
