using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на изменение пароля.
    /// </summary>
    [DataContract]
    public class PasswordUpdatingRequest : OperationRequest
    {
        /// <summary>
        /// Новое значение пароля.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string NewPassword { get; set; }
    }
}