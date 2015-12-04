using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры поиска/фильтрации списка документов
    /// </summary>
    [DataContract]
    public class DocumentListOptions
    {
        /// <summary>
        /// Отправитель
        /// </summary>
        [DataMember]
        public string BoxFrom { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        [DataMember]
        public string BoxTo { get; set; }

        /// <summary>
        /// Период с
        /// </summary>
        [DataMember]
        public DateTime? From { get; set; }
        
        /// <summary>
        /// Период по
        /// </summary>
        [DataMember]
        public DateTime? To { get; set; }

        /// <summary>
        /// Номер первой записи
        /// </summary>
        [DataMember]
        public int First { get; set; }

        /// <summary>
        /// Максимальное количество документов в списке
        /// </summary>
        [DataMember]
        public int Max { get; set; }

        /// <summary>
        /// Типы документов
        /// </summary>
        [DataMember]
        public DocumentType[] DocumentTypes { get; set; }

        /// <summary>
        /// Ящики контрагентов
        /// </summary>
        [DataMember]
        public string[] ContragentBoxIds { get; set; }

        /// <summary>
        /// Статусы ЭСФ
        /// </summary>
        [DataMember]
        public InvoiceFlowStatus[] InvoiceFlowStatuses { get; set; }

        /// <summary>
        /// Статусы подписания документов 
        /// </summary>
        [DataMember]
        public DocumentSignStatus[] DocumentSignStatuses { get; set; }

        /// <summary>
        /// Требуется подтверждение получения
        /// </summary>
        [DataMember]
        public bool? NeedReceipt { get; set; }

        /// <summary>
        /// Получить параметры поиска/фильтрации в виде строки
        /// </summary>
        /// <returns>Строка в параметрами поиска/фильтрации содержащая
        /// адрес отправителя, адрес получателя, дату с, дата по, номер первой записи, 
        /// максимальное количество документов в списке</returns>
        /// todo вынести в extensions
        public override string ToString()
        {
            return string.Format("BoxFrom: {0}, BoxTo: {1}, From: {2}, To: {3}, First: {4}, Max: {5}", BoxFrom, BoxTo, From, To, First, Max);
        }
    }
}