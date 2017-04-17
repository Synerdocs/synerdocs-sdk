using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class OrganizationShortInfo
    {
        /// <summary>
        /// Ящик организации
        /// </summary>
        [DataMember]
        public string OrganizationBoxId { get; set; }

        /// <summary>
        /// Тип организации
        /// </summary>
        [DataMember]
        public EnumValue OrganizationType { get; set; }

        /// <summary>
        /// Название организации
        /// </summary>
        [DataMember]
        public string Name { get; set; }

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
        /// Имя (для ИП)
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия (для ИП)
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество (для ИП)
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон организации
        /// </summary>
        [DataMember]
        public string Phone { get; set; }
    }
}
