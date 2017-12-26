using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс, описывающий сущность.
    /// </summary>
    [DataContract]
    public class Entity
    {
        /// <summary>
        /// Тип сущности.
        /// </summary>
        [DataMember]
        public EnumValue EntityType { get; set; }

        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        [DataMember]
        public string Id { get; set; }
    }
}
