using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание порядка внесения записей в документ.
    /// </summary>
    [DataContract]
    public class RecordIntroductionPolicy
    {
        /// <summary>
        /// Реквизит документа, о котором вносится запись.
        /// </summary>
        [DataMember]
        public string DocumentRequisite { get; set; }

        /// <summary>
        /// Порядок внесения записи.
        /// </summary>
        [DataMember]
        public string Routine { get; set; }

        /// <summary>
        /// Иные условия внесения записи.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalPolicies { get; set; }
    }
}
