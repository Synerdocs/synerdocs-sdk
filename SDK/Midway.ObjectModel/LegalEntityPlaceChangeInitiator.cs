using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о ЮЛ, от которого получено указание на переадресовку.
    /// </summary>
    [DataContract]
    public class LegalEntityPlaceChangeInitiator : PlaceChangeInitiatorBase
    {
        /// <summary>
        /// ИНН юридического лица.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Inn { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Должность подписанта.
        /// </summary>
        [DataMember]
        public string Position { get; set; }
    }
}
