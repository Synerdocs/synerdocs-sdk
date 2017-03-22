using System.Runtime.Serialization;

namespace Midway.Edi.Api.Errors
{
    /// <summary>
    /// Сообщение валидации модели
    /// </summary>
    [DataContract]
    public class ModelValidationMessage
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [DataMember]
        public string Text { get; set; }

        /// <summary>
        /// Статус сообщения
        /// </summary>
        [DataMember]
        public ValidationMessageStatusEnum Status { get; set; }
    }
}
