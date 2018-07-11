using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения об участниках и операторе ЭДО.
    /// </summary>
    [DataContract]
    public class InterchangeDescription
    {
        /// <summary>
        /// Участники ЭДО.
        /// </summary>
        [DataMember]
        public List<InterchangeParticipant> Participants { get; set; }

        /// <summary>
        /// Оператор ЭДО отправителя.
        /// </summary>
        [DataMember]
        public SpecialOperatorInfo SenderSpecialOperator { get; set; }
    }
}
