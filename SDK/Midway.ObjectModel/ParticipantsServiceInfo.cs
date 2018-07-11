using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения об участниках электронного документооборота.
    /// </summary>
    [DataContract]
    public class ParticipantsServiceInfo
    {
        /// <summary>
        /// Идентификатор участника документооборота, отправителя.
        /// </summary>
        [DataMember]
        public string SenderServiceCode { get; set; }

        /// <summary>
        /// Идентификатор участника документооборота, получателя.
        /// </summary>
        [DataMember]
        public string RecipientServiceCode { get; set; }

        /// <summary>
        /// Сведения об операторе электронного документооборота отправителя.
        /// </summary>
        [DataMember]
        public SpecialOperatorInfo SenderSpecialOperatorInfo { get; set; }
    }
}
