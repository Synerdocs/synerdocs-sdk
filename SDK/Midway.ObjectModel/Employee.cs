using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о сотруднике организации.
    /// </summary>
    [DataContract]
    public class Employee
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public Employee()
        {
            Certificate = new Certificate();
        }

        /// <summary>
        /// ИД сотрудника.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Идентификатор организации.
        /// </summary>
        [DataMember]
        public string OrganizationBoxId { get; set; }
        
        /// <summary>
        /// Признак "Участник ЭДО СФ".
        /// </summary>
        [DataMember]
        public bool InvoiceReglamentAccepted { get; set; }
        
        /// <summary>
        /// Администратор организации.
        /// </summary>
        [DataMember]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Информация о пользователе.
        /// </summary>
        [DataMember]
        public UserInfo User { get; set; }

        /// <summary>
        /// Сертификат.
        /// </summary>
        [DataMember]
        public Certificate Certificate { get; set; }

        /// <summary>
        /// Доступные подразделения.
        /// </summary>
        [DataMember]
        public List<AccessToDepartment> AvailableDepartments { get; set; }

        /// <summary>
        /// Признак "Удален".
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Список настроек сотрудника.
        /// </summary>
        [DataMember]
        public List<SettingData> Settings { get; set; }

        /// <summary>
        /// Организация.
        /// </summary>
        [DataMember]
        public Organization Organization { get; set; }
    }
}
