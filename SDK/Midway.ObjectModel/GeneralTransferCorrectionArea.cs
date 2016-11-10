using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения об изменении стоимости ранее отгруженных товаров (выполненных работ, оказанных услуг), переданных имущественных прав
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionArea
    {
        /// <summary>
        /// Данные об измении стоимости ранее отгруженных товаров (выполненных работ, оказанных услуг), переданных имущественных прав
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionItem[] Items { get; set; }

        /// <summary>
        /// Изменения итого
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionTotal Total { get; set; }
    }
}
