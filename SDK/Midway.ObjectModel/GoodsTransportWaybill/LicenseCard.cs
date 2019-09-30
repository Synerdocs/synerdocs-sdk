using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Лицензионная карточка.
    /// </summary>
    [DataContract]
    public class LicenseCard
    {
        /// <summary>
        /// Тип лицензионной карточки.
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// Реквизиты лицензионной карточки.
        /// </summary>
        [DataMember]
        public RegistrationInfo Requisites { get; set; }
    }
}