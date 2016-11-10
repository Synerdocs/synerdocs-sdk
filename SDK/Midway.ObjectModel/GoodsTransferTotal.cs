using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Общая стоимость, сумма налога, стоимость с налогом, количество мест, масса брутто и нетто в документе 
    /// о передаче товаров
    /// </summary>
    [DataContract]
    public class GoodsTransferTotal : AmountTotal
    {
        /// <summary>
        /// Количество мест всего по документу
        /// </summary>
        [DataMember]
        public decimal? NumberOfPackages { get; set; }

        /// <summary>
        /// Общая масса брутто
        /// </summary>
        [DataMember]
        public decimal? GrossWeight { get; set; }

        /// <summary>
        /// Общее количество (ма­сса не­тто) 
        /// </summary>
        [DataMember]
        public decimal? Quantity { get; set; }
    }
}
