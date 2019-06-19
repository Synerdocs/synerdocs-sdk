using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Участник документооборота.
    /// </summary>
    [DataContract]
    public class DocumentFlowParticipantShortInfo
    {
        /// <summary>
        /// ИД участника черновика документооборота.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Абонентский ящик участника документооборота.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BoxId { get; set; }

        /// <summary>
        /// ИД подразделения участника документооборота.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Список ролей участника в рамках документооборота.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<EnumValue> Roles { get; set; }
    }
}
