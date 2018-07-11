using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос получения списка абонентов и пользователей, использующих мобильный клиент.
    /// </summary>
    [DataContract]
    public class EmployeesWorkingViaMobileClientGettingResponse : OperationResponse
    {
        /// <summary>
        /// Информация об абонентах и пользователях, использующий мобильный клиент.
        /// </summary>
        [DataMember]
        public List<EmployeeWorkingViaMobileClient> Employees { get; set; }
    }
}
