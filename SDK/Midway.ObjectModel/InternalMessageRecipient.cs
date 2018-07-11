using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Получатель внутреннего сообщения
    /// </summary>
    [DataContract]
    public class InternalMessageRecipient
    {
        /// <summary>
        /// ИД подразделения получателя.
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Наименование подразделения получателя.
        /// При создании/сохранении черновика не используется.
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Логин пользователя получателя
        /// </summary>
        [DataMember]
        public string UserLogin { get; set; }
    }
}
