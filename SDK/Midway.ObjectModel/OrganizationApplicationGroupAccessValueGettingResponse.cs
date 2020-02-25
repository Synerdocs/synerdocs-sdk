using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос получения настройки допуска организации к группе приложений.
    /// </summary>
    [DataContract]
    public class OrganizationApplicationGroupAccessValueGettingResponse : OperationResponse
    {
        /// <summary>
        /// ИД группы приложений.
        /// </summary>
        [DataMember]
        public EnumValue ApplicationGroup { get; set; }

        /// <summary>
        /// Флаг возможности доступа организации к группе приложений.
        /// </summary>
        [DataMember]
        public bool Enabled { get; set; }
    }
}
