using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры поиска/фильтрации внутренних документов
    /// Параметры объединяются в уcловие оператором 'И' ('AND')
    /// </summary>
    [DataContract]
    public class InternalListOptions
    {
        /// <summary>
        /// Ящик организации
        /// </summary>
        [DataMember]
        public string BoxId { get; set; }

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
        /// Статусы подписания документов
        /// Если параметр задан, поиск возвращает
        /// документы, у которых есть статус подписания
        /// из этого списка. Если параметр не задан,
        /// то  возращаются все документы
        /// </summary>
        [DataMember]
        public DocumentSignStatus[] DocumentSignStatuses { get; set; }

        /// <summary>
        /// ИД подразделений отправителя
        /// Если параметр задан, поиск возвращает
        /// документы, у которых есть подразделение
        /// отправитель из этого списка
        /// </summary>
        [DataMember]
        public string[] SenderDepartmentIds { get; set; }

        /// <summary>
        /// ИД подразделений получателя
        /// Если параметр задан, поиск возвращает
        /// документы, у которых есть подразделение
        /// получатель из этого списка
        /// </summary>
        [DataMember]
        public string[] RecipientDepartmentIds { get; set; }

        /// <summary>
        /// Логины пользователей получателя
        /// Если параметр задан, поиск возвращает
        /// документы, у которых есть пользователь
        /// получатель из этого списка
        /// </summary>
        [DataMember]
        public string[] RecipientUserLogins { get; set; }

        /// <summary>
        /// Исключить из списка документы,
        /// подписание/отказ по которым недоступно
        /// Значение по умолчанию - <c>false</c>
        /// </summary>
        [DataMember]
        public bool? ExcludeUnavailable { get; set; }
    }
}