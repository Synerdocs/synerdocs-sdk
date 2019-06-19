using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения об отгруженных товарах (о выполненных работах, оказанных услугах), переданных имущественных правах.
    /// </summary>
    [DataContract]
    public class GeneralTransferArea
    {
        /// <summary>
        /// Продукты.
        /// </summary>
        [DataMember]
        public GeneralTransferItem[] Items { get; set; }

        /// <summary>
        /// Итого по документу.
        /// </summary>
        [DataMember]
        public GeneralTransferTotal Total { get; set; }
    }
}
