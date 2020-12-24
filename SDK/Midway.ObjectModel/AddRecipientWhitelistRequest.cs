using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на добавление организации в белый список получателей.
    /// </summary>
    [DataContract]
    public class AddRecipientWhitelistRequest
    {
        /// <summary>
        /// ИД организации отправителя.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int SenderOrganizationId { get; set; }

        /// <summary>
        /// ИД организации получателя.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int RecipientOrganizationId { get; set; }
    }
}
