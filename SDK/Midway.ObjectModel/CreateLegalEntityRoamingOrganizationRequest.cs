using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Модель роуминговой организации типа ЮЛ.
    /// </summary>
    [DataContract]
    public class LegalEntityRoamingOrganization : RoamingOrganization
    {
        /// <summary>
        /// КПП организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Kpp { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
    }
}
