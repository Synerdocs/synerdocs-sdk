using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация по разнице до и после УКД 
    /// </summary>
    [DataContract]
    public class GeneralTransferItemChange : ItemAmountChange
    {
        /// <summary>
        /// Сумма акциза, разница до и после
        /// </summary>
        [DataMember]
        public AmountChange ExciseChange { get; set; }

    }
}
