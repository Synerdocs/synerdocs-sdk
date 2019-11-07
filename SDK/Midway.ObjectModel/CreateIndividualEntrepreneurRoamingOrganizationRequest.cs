using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Модель роуминговой организации типа ИП.
    /// </summary>
    [DataContract]
    public class IndividualEntrepreneurRoamingOrganization : RoamingOrganization
    {
        /// <summary>
        /// ФИО ИП.
        /// </summary>
        [DataMember(IsRequired = true)]
        public FullName FullName { get; set; }
    }
}
