using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на получение данных личного профиля.
    /// </summary>
    [DataContract]
    [KnownType(typeof(EmployeeProfileGettingRequest))]
    public class ProfileGettingRequest : OperationRequest
    {
        /// <summary>
        /// Настройки выгрузки данных.
        /// </summary>
        [DataMember]
        public EmployeeLoadingSettings LoadingSettings { get; set; }
    }
}