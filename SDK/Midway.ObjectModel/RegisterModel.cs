using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class RegisterModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public RegisterModel()
        {
            Certificate = new Certificate();
            OrganizationType = OrganizationType.LegalEntity;
        }

        #region Информация о пользователе

        /// <summary>
        /// Логин
        /// </summary>
        [DataMember]
        [DisplayName("Введите логин")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [DataMember]
        [DisplayName("Введите пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DataMember]
        [DisplayName("Введите имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DataMember]
        [DisplayName("Введите фамилию")]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DataMember]
        [DisplayName("Введите отчество")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        [DataMember]
        [DisplayName("Введите email")]
        public string Email { get; set; }

        #endregion Информация о пользователе

        #region Информация по организации

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        [DataMember]
        [DisplayName("Введите название организации")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// ИНН организации
        /// </summary>
        [DataMember]
        [DisplayName("Введите ИНН")]
        public string Inn { get; set; }

        /// <summary>
        /// КПП организации
        /// </summary>
        [DataMember]
        [DisplayName("Введите КПП")]
        public string Kpp { get; set; }

        /// <summary>
        /// ОГРН организации или ИП
        /// </summary>
        [DataMember]
        [DisplayName("Введите ОГРН")]
        public string Ogrn { get; set; }

        /// <summary>
        /// Принят регламент ЭДО
        /// </summary>
        [DataMember]
        [DisplayName("Вы принимаете доступные по адресу www.synerdocs.ru Правила Synerdocs?")]
        public bool ServiceReglamentAccepted { get; set; }

        /// <summary>
        /// Сертификат
        /// </summary>
        [DataMember]
        public Certificate Certificate { get; set; }

        /// <summary>
        /// Тип организации
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// Код оператора ЭДО
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }

        /// <summary>
        /// Код организации в рамках системы ЭДО, используется при выставлении ЭСФ
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }

        #endregion Информация по организации
    }
}