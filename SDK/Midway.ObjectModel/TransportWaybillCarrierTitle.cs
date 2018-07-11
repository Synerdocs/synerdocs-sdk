using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул перевозчика транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCarrierTitle : TransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Информация о принятии заказа (заявки) к исполнению.
        /// </summary>
        [DataMember]
        public OrderAcceptance OrderAcceptance { get; set; }

        /// <summary>
        /// Сведения о лицах, подписывающих Транспортную накладную от имени Перевозчика.
        /// </summary>
        [DataMember]
        public List<SignerBase> CarrierSigners { get; set; }
    }
}