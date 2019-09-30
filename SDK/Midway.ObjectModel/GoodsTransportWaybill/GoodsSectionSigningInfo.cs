using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Информация о подписании товарного раздела.
    /// </summary>
    [DataContract]
    public class GoodsSectionSigningInfo
    {
        /// <summary>
        /// Дата подписания.
        /// </summary>
        [DataMember]
        public DateTime? SignedAt { get; set; }

        /// <summary>
        /// Лицо, разрешившее отпуск груза.
        /// </summary>
        [DataMember]
        public OperationAuthority CargoReleaseApprovedBy { get; set; }

        /// <summary>
        /// Лицо, которое произвело отпуск груза.
        /// </summary>
        [DataMember]
        public OperationAuthority CargoReleasedBy { get; set; }

        /// <summary>
        /// Главный бухгалтер.
        /// </summary>
        [DataMember]
        public OperationAuthority СhiefAccountant { get; set; }

        /// <summary>
        /// Лицо, принявшее груз.
        /// </summary>
        [DataMember]
        public OperationAuthority CargoReceivedBy { get; set; }
    }
}