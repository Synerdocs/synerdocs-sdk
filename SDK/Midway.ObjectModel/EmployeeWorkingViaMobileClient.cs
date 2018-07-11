using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о сотруднике, использующем мобильный клиент.
    /// </summary>
    [DataContract] 
    public class EmployeeWorkingViaMobileClient
    {
        /// <summary>
        /// ИД сотрудника.
        /// </summary>
        [DataMember]
        public string EmployeeId { get; set; }

        /// <summary>
        /// Ящик абонента.
        /// </summary>
        [DataMember]
        public string BoxId { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [DataMember]
        public string Login { get; set; }

        /// <summary>
        /// <c>true</c>, если требуется отслеживать абонента, иначе <c>false</c>.
        /// </summary>
        [DataMember]
        public bool Enabled { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// <c>true</c>, если требуется уведомлять абонента через СМС, иначе <c>false</c>.
        /// </summary>
        [DataMember]
        public bool NotifyBySms { get; set; }

        /// <summary>
        /// <c>true</c>, если требуется уведомлять абонента через Viber, иначе <c>false</c>.
        /// </summary>
        [DataMember]
        public bool NotifyByViber { get; set; }

        /// <summary>
        /// Дата последнего изменения записи.
        /// </summary>
        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
}
