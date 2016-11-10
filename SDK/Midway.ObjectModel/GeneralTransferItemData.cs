using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные для расчета для СФ
    /// </summary>
    [DataContract]
    public class GeneralTransferItemData : ItemAmount
    {
        /// <summary>
        /// Сумма акциза
        /// </summary>
        [DataMember]
        public decimal? Excise { get; set; }
    }
}
