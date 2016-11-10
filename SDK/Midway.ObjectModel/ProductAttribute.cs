using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о признаке продукта
    /// </summary>
    [DataContract]
    public class ProductAttribute
    {
        /// <summary>
        /// Тип признака
        /// </summary>
        [DataMember]
        public EnumValue AttributeType { get; set; }

        /// <summary>
        /// Дополнительные сведения
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
