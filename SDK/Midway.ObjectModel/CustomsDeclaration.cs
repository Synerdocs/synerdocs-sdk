using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о таможенной декларации
    /// </summary>
    [DataContract]
    public class CustomsDeclaration
    {
        /// <summary>
        /// Цифровой код страны происхождения товара
        /// Код страны по Общероссийскому классификатору стран мира (ОКСМ)
        /// </summary>
        [DataMember]
        public NameCodeObject Country { get; set; }

        /// <summary>
        /// Номер таможенной декларации
        /// </summary>
        [DataMember]
        public string Number { get; set; }
    }
}
