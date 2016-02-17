using System.Runtime.Serialization;
using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Связь промокод - организация
    /// </summary>
    [DataContract]
    public class OrganizationPromoCode:PromoCode
    {
        /// <summary>
        /// глобальный ИД связи промокода - организации
        /// </summary>
        [DataMember]
        public string OrganizationPromoCodeId { get; set; }

    }
}