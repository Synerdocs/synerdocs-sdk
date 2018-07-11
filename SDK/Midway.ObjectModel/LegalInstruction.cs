using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Указание, необходимое для выполнения одного из фитосанитарных,
    /// санитарных, карантинных, таможенных и прочих требований.
    /// </summary>
    [DataContract]
    public class LegalInstruction
    {
        /// <summary>
        /// Вид требования.
        /// </summary>
        [DataMember]
        public string RequirementType { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Иные сведения необходимые для выполнения указания.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
