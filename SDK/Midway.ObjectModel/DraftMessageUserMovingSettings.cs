using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Настройки передачи черновика сообщения по ящику организации и логину пользователя.
    /// </summary>
    public class DraftMessageUserMovingSettings : DraftMessageMovingSettings
    {
        /// <summary>
        /// Ящик организации, которой будет передан черновик.
        /// </summary>
        [DataMember]
        public string BoxAddress { get; set; }

        /// <summary>
        /// Логин пользователя, которому будет передан черновик.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Login { get; set; }
    }
}
