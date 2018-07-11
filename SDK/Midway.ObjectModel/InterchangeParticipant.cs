using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения об участнике ЭДО.
    /// </summary>
    [DataContract]
    public class InterchangeParticipant
    {
        /// <summary>
        /// Тип участника ЭДО.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue Type { get; set; }

        /// <summary>
        /// <c>true</c>, если участник является отправителем титула; иначе - <c>false</c>.
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool? IsTitleSender { get; set; }

        /// <summary>
        /// Идентификатор участника документооборота.
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }
    }
}
