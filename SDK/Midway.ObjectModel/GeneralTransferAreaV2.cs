using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения об отгруженных товарах (о выполненных работах, оказанных услугах), переданных имущественных правах.
    /// </summary>
    [DataContract]
    public class GeneralTransferAreaV2
    {
        /// <summary>
        /// Продукты.
        /// </summary>
        [DataMember(IsRequired = true)]
        public GeneralTransferItemV2[] Items { get; set; }

        /// <summary>
        /// Итого по документу.
        /// </summary>
        [DataMember(IsRequired = true)]
        public GeneralTransferTotalV2 Total { get; set; }
    }
}
