using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на получение абонентов и пользователей, использующих мобильный клиент.
    /// </summary>
    [DataContract]
    public class EmployeesWorkingViaMobileClientGettingRequest : OperationRequest
    {
        /// <summary>
        /// Дата-время, начиная с которой требуется получить информацию, не включая указанное значение.
        /// </summary>
        [DataMember]
        public DateTime? After { get; set; }
    }
}
