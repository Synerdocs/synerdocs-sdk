using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Реквизиты сопроводительного документа.
    /// </summary>
    [DataContract]
    public class ShippingDocument : NumberDate
    {
        /// <summary>
        /// Наименование документа.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Дополнительные сведения о документе.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
