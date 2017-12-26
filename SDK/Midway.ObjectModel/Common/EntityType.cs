using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Тип сущности.
    /// </summary>
    [DataContract]
    public enum EntityType
    {
        /// <summary>
        /// Сотрудник.
        /// </summary>
        [EnumMember]
        [Description("Сотрудник")]
        Employee = 17
    }
}
