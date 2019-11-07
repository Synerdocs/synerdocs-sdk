using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Модель запроса на создание роуминговой организации.
    /// </summary>
    [DataContract]
    public class CreateRoamingOrganizationRequest
    {
        /// <summary>
        /// Код роумингового оператора.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string OperatorCode { get; set; }

        /// <summary>
        /// Идентификатор абонента, имеет структуру: код роумингового оператора(3 символа) + имя абонента (не более 43 символов).
        /// </summary>
        [DataMember(IsRequired = true)]
        public string SubscriberId { get; set; }


        /// <summary>
        /// Роуминговая организация.
        /// </summary>
        [DataMember(IsRequired = true)]
        public RoamingOrganization RoamingOrganization { get; set; }
    }
}