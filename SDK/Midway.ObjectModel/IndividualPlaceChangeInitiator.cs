using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о ФЗ, от которого получено указание на переадресовку.
    /// </summary>
    [DataContract]
    public class IndividualPlaceChangeInitiator : PlaceChangeInitiatorBase
    {
        /// <summary>
        /// ИНН физического лица.
        /// </summary>
        [DataMember]
        public string Inn { get; set; }
    }
}
