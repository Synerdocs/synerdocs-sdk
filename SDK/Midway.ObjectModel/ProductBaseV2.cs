using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовая модель товара (услуги).
    /// </summary>
    [DataContract]
    public class ProductBaseV2 : ItemAmountV2
    {
        /// <summary>
        /// Номер.
        /// </summary>
        [DataMember]
        public int Number { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Информационное поле.
        /// </summary>
        [DataMember]
        public NameCodeObject[] InfoTexts { get; set; }
    }
}
