using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул экспедитора транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillExpeditorTitle : TransportWaybillReplyTitleBase
    {
        /// <summary>
        /// Экспедитор.
        /// </summary>
        [DataMember]
        public CounterpartyBase Expeditor { get; set; }

        /// <summary>
        /// Сведения о подписанте титула.
        /// </summary>
        [DataMember]
        public SignerBase TitleSigner { get; set; }
    }
}
