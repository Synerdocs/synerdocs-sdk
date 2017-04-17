using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сообщение валидации поля
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
        public EnumValue Status { get; set; }

        /// <summary>
        /// Категория сообщения
        /// </summary>
        [DataMember]
        public EnumValue Category { get; set; }
    }
}
