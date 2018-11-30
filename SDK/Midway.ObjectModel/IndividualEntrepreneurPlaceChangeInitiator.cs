using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о ИП, от которого получено указание на переадресовку.
    /// </summary>
    [DataContract]
    public class IndividualEntrepreneurPlaceChangeInitiator : PlaceChangeInitiatorBase
    {
        /// <summary>
        /// ИНН физического лица.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Inn { get; set; }

        /// <summary>
        /// Свидетельство государственной регистрации ИП.
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }
    }
}
