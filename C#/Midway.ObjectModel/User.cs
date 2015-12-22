using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс, содержащий информацию о пользователе в контексте организации
    /// </summary>
    [DataContract]
    public class User
    {
         /// <summary>
        /// Конструктор
        /// </summary>
        public User()
        {
            Certificate = new Certificate();
        }

        /// <summary>
        /// Логин
        /// </summary>
        [DataMember]
        public string Login { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [DataMember]
        public string Tel { get; set; }

        /// <summary>
        /// Эл.почта
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Аська
        /// </summary>
        [DataMember]
        public string Icq { get; set; }

        /// <summary>
        /// Скайп
        /// </summary>
        [DataMember]
        public string Skype { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [DataMember]
        public bool State { get; set; }
        
        /// <summary>
        /// Комментарий
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Часовой пояс
        /// </summary>
        [DataMember]
        public string TimeZone { get; set; }

        /// <summary>
        /// Администратор организации
        /// </summary>
        [DataMember]
        public bool IsAdmin { get; set; }
        

        //информация по организации

        /// <summary>
        /// Должность
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [DataMember]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Наименование подразделения
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Доступ к вложенным основного подразделения
        /// </summary>
        [DataMember]
        public bool DepartmentSubElementsAccess { get; set; }
        
        /// <summary>
        /// Признак "Участник ЭДО СФ"
        /// </summary>
        [DataMember]
        public bool InvoiceReglamentAccepted { get; set; }
        
        /// <summary>
        /// Сертификат
        /// </summary>
        [DataMember]
        public Certificate Certificate { get; set; }
    }
}
