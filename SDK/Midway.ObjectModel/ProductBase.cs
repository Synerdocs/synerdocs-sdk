using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовая модель товара / услуги
    /// </summary>
    [DataContract]
    public class ProductBase: ItemAmount
    {
        /// <summary>
        /// Номер
        /// </summary>
        [DataMember]
        public int Number { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Корректировочный дебетовый счет
        /// </summary>
        [DataMember]
        public string DebitAccount { get; set; }

        /// <summary>
        /// Корректировочный кредитовый счет
        /// </summary>
        [DataMember]
        public string CreditAccount { get; set; }

        /// <summary>
        /// Информационное поле
        /// </summary>
        [DataMember]
        public NameCodeObject[] InfoTexts { get; set; }
    }
}
