using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на создание пользователя и сотрудника абонента.
    /// </summary>
    [DataContract]
    public class UserAndEmployeeCreationRequest : OperationRequest
    {
        /// <summary>
        /// Сертификат.
        /// </summary>
        [DataMember]
        public byte[] CertificateRaw { get; set; }

        /// <summary>
        /// Идентификатор подразделения, сотрудником которого является пользователь.
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Признак: будет ли сотрудник абонента являться администратором.
        /// </summary>
        [DataMember]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Position { get; set; }

        /// <summary>
        /// Список настроек сотрудника.
        /// </summary>
        [DataMember]
        public List<SettingData> Settings { get; set; }

        /// <summary>
        /// Пользовательская информация.
        /// </summary>
        [DataMember(IsRequired = true)]
        public UserCreationData User { get; set; }
    }
}