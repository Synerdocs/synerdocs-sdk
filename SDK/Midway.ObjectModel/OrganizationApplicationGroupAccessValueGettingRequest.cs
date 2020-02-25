using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на получение настройки допуска организации к группе приложений.
    /// </summary>
    [DataContract]
    public class OrganizationApplicationGroupAccessValueGettingRequest : OperationRequest
    {
        /// <summary>
        /// ИД организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int OrganizationId { get; set; }

        /// <summary>
        /// ИД группы приложений.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue ApplicationGroup { get; set; }
    }
}
