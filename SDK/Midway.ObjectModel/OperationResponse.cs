using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при выполнении операции.
    /// </summary>
    [DataContract]
    public class OperationResponse
    {
        /// <summary>
        /// Статус выполнения.
        /// <para>
        /// Является представлением перечисления <see cref="OperationStatus"/>.
        /// </para>
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
