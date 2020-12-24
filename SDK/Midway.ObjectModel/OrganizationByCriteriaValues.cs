using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Критерии поиска организаций
    /// </summary>
    [DataContract]
    public class OrganizationByCriteriaValues
    {
        /// <summary>
        /// ИД организации
        /// </summary>
        [DataMember]
        public string OrganizationId { get; set; }

        /// <summary>
        /// ИНН организации
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// КПП организации
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// Адрес абонентского ящика
        /// </summary>
        [DataMember]
        public string BoxAddress { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [DataMember]
        public string UserLogin { get; set; }

        /// <summary>
        /// Код организации в рамках системы ЭДО
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }

        /// <summary>
        /// Код оператора ЭДО
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }
    }
}
