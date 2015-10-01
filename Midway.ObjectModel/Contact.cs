using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о контрагенте
    /// </summary>
    [DataContract]
    public class Contact
    {
        /// <summary>
        /// ИД контрагента
        /// </summary>
        [DataMember]
        public int ContragentId { get; set; }

        /// <summary>
        /// Наименование контрагента
        /// </summary>
        [DataMember]
        public string ContragentName { get; set; }

        /// <summary>
        /// ИНН контрагента
        /// </summary>
        [DataMember]
        public string ContragentInn { get; set; }

        /// <summary>
        /// КПП контрагента
        /// </summary>
        [DataMember]
        public string ContragentKpp { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Дата последнего изменения контакта
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Статус контрагента
        /// </summary>
        [DataMember]
        public ContactStatus ContactStatus { get; set; }

        /// <summary>
        /// Код оператора ЭДО
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }
    }
}
