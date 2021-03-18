using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Сведения об изменении стоимости ранее отгруженных товаров (выполненных работ, оказанных услуг),
    /// переданных имущественных прав.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionAreaV3
    {
        /// <summary>
        /// Данные об изменении стоимости ранее отгруженных товаров (выполненных работ, оказанных услуг),
        /// переданных имущественных прав.
        /// </summary>
        [DataMember]
        public List<GeneralTransferCorrectionItemV3> GeneralTransferCorrectionItems { get; set; }

        /// <summary>
        /// Изменения итого.
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionTotal Total { get; set; }
    }
}
