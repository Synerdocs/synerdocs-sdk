using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс контрагента.
    /// </summary>
    [DataContract]
    public class ContragentBase
    {
        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// КПП.
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// Банковские реквизиты.
        /// </summary>
        [DataMember]
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
