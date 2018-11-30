using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс сведений о лице, от которого получено указание на переадресовку.
    /// </summary>
    [DataContract]
    [KnownType(typeof(LegalEntityPlaceChangeInitiator))]
    [KnownType(typeof(IndividualEntrepreneurPlaceChangeInitiator))]
    [KnownType(typeof(IndividualPlaceChangeInitiator))]
    public class PlaceChangeInitiatorBase
    {
        /// <summary>
        /// ФИО подписанта.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// Основание полномочий (доверия).
        /// </summary>
        [DataMember]
        public string AuthorityBase { get; set; }

        /// <summary>
        /// Основание полномочий (доверия) для организации.
        /// </summary>
        [DataMember]
        public string OrganizationAuthorityBase { get; set; }

        /// <summary>
        /// Иные сведения, идентифицирующие физическое лицо.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
