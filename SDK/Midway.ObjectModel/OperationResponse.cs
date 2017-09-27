using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при выполнении операции.
    /// </summary>
    [DataContract]
    [KnownType(typeof(OperationStatus))]
    public class OperationResponse
    {
        /// <summary>
        /// Статус выполнения.
        /// </summary>
        [DataMember]
        public EnumValue Status { get; set; }

        /// <summary>
        /// Результат валидации.
        /// </summary>
        [DataMember]
        public ModelValidationResult ValidationResult { get; set; }
    }
}
