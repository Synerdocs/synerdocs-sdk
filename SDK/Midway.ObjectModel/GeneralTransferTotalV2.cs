using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Общая стоимость, сумма налога, стоимость с налогом, масса нетто в универсальном передаточном документе.
    /// </summary>
    [DataContract]
    public class GeneralTransferTotalV2 : AmountTotalV2
    {
        /// <summary>
        /// Общее количество (ма­сса не­тто) 
        /// </summary>
        [DataMember]
        public decimal? Quantity { get; set; }
    }
}
