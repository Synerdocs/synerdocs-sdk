using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Номер средств идентификации товаров.
    /// </summary>
    [DataContract]
    public class ProductIdentificationInfo
    {
        /// <summary>
        /// Уникальный ИД транспортной упаковки.
        /// </summary>
        [DataMember]
        public string TransportPackageId { get; set; }

        /// <summary>
        /// Контрольные идентификационные знаки.
        /// </summary>
        [DataMember]
        public List<string> CheckMarks { get; set; }

        /// <summary>
        /// Уникальные идентификаторы вторичной (потребительской)/третичной (заводской, транспортной) упаковок.
        /// </summary>
        [DataMember]
        public List<string> SecondaryPackageIds { get; set; }
    }
}
