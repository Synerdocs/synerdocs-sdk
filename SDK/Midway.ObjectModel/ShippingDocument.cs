using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Реквизиты сопроводительного документа.
    /// </summary>
    [DataContract]
    public class ShippingDocument : NamedNumberDate
    {
        /// <summary>
        /// Дополнительные сведения о документе.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
