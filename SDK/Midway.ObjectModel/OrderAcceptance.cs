using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о принятии заказа (заявки) к исполнению.
    /// </summary>
    [DataContract]
    public class OrderAcceptance
    {
        /// <summary>
        /// Фамилия, имя, отчество, должность лица, принявшего заказ (заявку) к исполнению.
        /// </summary>
        [DataMember]
        public SignerBase AcceptedBy { get; set; }

        /// <summary>
        /// Дата принятия заказа (заявки) к исполнению.
        /// </summary>
        [DataMember]
        public DateTime? AcceptedAt { get; set; }
    }
}
