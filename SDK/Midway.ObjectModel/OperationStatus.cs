using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус выполнения операции.
    /// </summary>
    [DataContract]
    public enum OperationStatus
    {
        /// <summary>
        /// Операция выполнена успешно.
        /// </summary>
        [EnumMember]
        [Description("Операция выполнена успешно")]
        Success = 0,

        /// <summary>
        /// Операция выполнена, но есть предупреждения.
        /// </summary>
        [EnumMember]
        [Description("Операция выполнена, но есть предупреждения")]
        Warning = 1,

        /// <summary>
        /// Во время выполнения операции произошла ошибка.
        /// </summary>
        [EnumMember]
        [Description("Во время выполнения операции произошла ошибка")]
        Error = 2,
    }
}
