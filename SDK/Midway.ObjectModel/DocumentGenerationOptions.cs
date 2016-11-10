using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Опции генерации документа
    /// </summary>
    [DataContract]
    public class DocumentGenerationOptions
    {
        /// <summary>
        /// Требуется ли валидация контента
        /// </summary>
        [DataMember]
        public bool ValidateContent { get; set; }

        /// <summary>
        /// Ящик организации-отправителя
        /// </summary>
        [DataMember]
        public string SenderBoxId { get; set; }

        /// <summary>
        /// Ящик организации-получателя
        /// </summary>
        [DataMember]
        public string RecipientBoxId { get; set; }
    }
}
