using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ на запрос на создание роуминговой организации.
    /// </summary>
    [DataContract]
    public class CreateRoamingOrganizationResponse : OperationResponse
    {
        /// <summary>
        /// Ящик созданной роуминговой организации.
        /// </summary>
        [DataMember]
        public string BoxAddress { get; set; }
    }
}
