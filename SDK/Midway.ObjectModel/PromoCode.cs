using System.Runtime.Serialization;
using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Промокод
    /// </summary>
    [DataContract]
    [KnownType(typeof(OrganizationPromoCode))]
    public class PromoCode
    {
        /// <summary>
        /// Наименование промокода
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Описание бонуса промокода
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Флаг неограниченности действия промокода
        /// </summary>
        [DataMember]
        public bool IsValidityNotLimited { get; set; }

        /// <summary>
        /// Начало действия промокода
        /// </summary>
        [DataMember]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Окончание действия промокода
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate { get; set; }

    }
}