
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовая модель роуминговой организации.
    /// </summary>
    [KnownType(typeof(LegalEntityRoamingOrganization))]
    [KnownType(typeof(IndividualEntrepreneurRoamingOrganization))]
    [DataContract]
    public abstract class RoamingOrganization
    {
        /// <summary>
        /// ИНН организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Inn { get; set; }

        /// <summary>
        /// Тип организации, соответствует перечислению <see cref="ObjectModel.OrganizationType"/>.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue OrganizationType { get; set; }
    }
}
