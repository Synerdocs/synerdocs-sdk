using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о неактивном абоненте
    /// </summary>
    [DataContract]
    public class NonActiveSubscriber : OrganizationShortInfo
    {
        /// <summary>
        /// Контактное лицо
        /// </summary>
        [DataMember]
        public string ContactPerson { get; set; }

        /// <summary>
        /// Список email
        /// </summary>
        [DataMember]
        public List<string> Emails { get; set; }
    }
}
