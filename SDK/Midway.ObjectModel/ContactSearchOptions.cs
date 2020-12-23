using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Параметры поиска контактов
    /// </summary>
    [DataContract]
    public class ContactSearchOptions
    {
        /// <summary>
        /// Номер записи, начиная с которого ведётся поиск в списке контактов
        /// </summary>
        [DataMember]
        public int From { get; set; }

        /// <summary>
        /// Количество выбираемых записей
        /// </summary>
        [DataMember]
        public int Max { get; set; }

        /// <summary>
        /// ИД организации, осуществляющей поиск
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Строка поиска. В строке поиска можно указывать 
        /// часть наименования, ИНН, КПП
        /// </summary>
        [DataMember]
        public string SearchString { get; set; }

        /// <summary>
        /// Статус контакта
        /// </summary>
        [DataMember]
        public ContactStatus ContactStatus { get; set; }

        /// <summary>
        /// Флаг включения неактивных организаций в поиск
        /// </summary>
        [DataMember]
        public bool IncludeNonActive { get; set; }
    }
}
