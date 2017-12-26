using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Список наименований полей, доступных для фильтрации сотрудников.
    /// </summary>
    [DataContract]
    public enum EmployeeFilterFieldNameList
    {
        /// <summary>
        /// Ящик абонента.
        /// </summary>
        [Description("Ящик абонента")]
        OrganizationBoxId = 0,

        /// <summary>
        /// Идентификатор подразделения сотрудника.
        /// </summary>
        [EnumMember]
        [Description("Идентификатор подразделения сотрудника")]
        DepartmentId = 1,

        /// <summary>
        /// Наименование подразделения сотрудника.
        /// </summary>
        [EnumMember]
        [Description("Наименование подразделения сотрудника")]
        DepartmentName = 2,

        /// <summary>
        /// Логин.
        /// </summary>
        [EnumMember]
        [Description("Логин")]
        Login = 3,

        /// <summary>
        /// E-mail.
        /// </summary>
        [EnumMember]
        [Description("E-mail")]
        Email = 4,

        /// <summary>
        /// Фамилия.
        /// </summary>
        [EnumMember]
        [Description("Фамилия")]
        LastName = 5,

        /// <summary>
        /// Имя.
        /// </summary>
        [EnumMember]
        [Description("Имя")]
        FirstName = 6,

        /// <summary>
        /// Отчество.
        /// </summary>
        [EnumMember]
        [Description("Отчество")]
        MiddleName = 7,

        /// <summary>
        /// Должность.
        /// </summary>
        [EnumMember]
        [Description("Должность")]
        Position = 8,

        /// <summary>
        /// Признак «администратор абонента».
        /// </summary>
        [EnumMember]
        [Description("Признак «администратор абонента»")]
        IsAdmin = 9,

        /// <summary>
        /// Отпечаток сертификата.
        /// </summary>
        [EnumMember]
        [Description("Отпечаток сертификата")]
        CertificateThumbprint = 10,

        /// <summary>
        /// Серийный номер сертификата.
        /// </summary>
        [EnumMember]
        [Description("Серийный номер сертификата")]
        CertificateSerialNumber = 11,

        /// <summary>
        /// Начало срока действия сертификата.
        /// </summary>
        [EnumMember]
        [Description("Начало срока действия сертификата")]
        CertificateValidFrom = 12,

        /// <summary>
        /// Конец срока действия сертификата.
        /// </summary>
        [EnumMember]
        [Description("Конец срока действия сертификата")]
        CertificateValidTo = 13
    }
}
