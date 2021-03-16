using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Данные об изменении стоимости ранее отгруженных товаров (выполненных работ, оказанных услуг),
    /// переданных имущественных прав.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionItemV3
    {
        /// <summary>
        /// Табличные данные до корректирования.
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionItemData Before { get; set; }

        /// <summary>
        /// Табличные данные после корректирования.
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionItemData After { get; set; }

        /// <summary>
        /// Информация по разнице до и после.
        /// </summary>
        [DataMember]
        public GeneralTransferCorrectionItemChange Change { get; set; }

        /// <summary>
        /// Порядковый номер товара.
        /// </summary>
        [DataMember(IsRequired = false)]
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
        public List<NameCodeObject> InfoTexts { get; set; }

        /// <summary>
        /// Дополнительная информация о товаре.
        /// </summary>
        [DataMember]
        public ProductAdditionalInfo ProductAdditionalInfo { get; set; }
    }
}
