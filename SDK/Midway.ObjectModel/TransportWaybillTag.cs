using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Отметка транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillTag
    {
        /// <summary>
        /// Краткое описание обстоятельств, послуживших основанием для отметки.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Расчет и размеры штрафов.
        /// </summary>
        [DataMember]
        public List<PenaltyCharge> Penalties { get; set; }

        /// <summary>
        /// Подписант отметки.
        /// </summary>
        [DataMember]
        public SignerBase SignatureBy { get; set; }
    }
}
