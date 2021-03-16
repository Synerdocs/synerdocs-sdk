using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Запись табличных данных универсального корректировочного документа.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionItemData
    {
        /// <summary>
        /// Сумма акциза.
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? Excise { get; set; }

        /// <summary>
        /// Сумма НДС.
        /// </summary>
        [DataMember]
        public VatAmount VatAmount { get; set; }

        /// <summary>
        /// Информация о номере средств идентификации товаров.
        /// </summary>
        [DataMember]
        public List<ProductIdentificationInfo> ProductIdentificationInfos { get; set; }

        /// <summary>
        /// Единица измерения товара.
        /// </summary>
        [DataMember]
        public NameCodeObject UnitMeasure { get; set; }

        /// <summary>
        /// Цена товара.
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? Price { get; set; }

        /// <summary>
        /// Налоговая ставка.
        /// Соответствует перечислению <see cref="Midway.ObjectModel.VatRate"/>.
        /// </summary>
        [DataMember]
        public EnumValue VatRate { get; set; }
    }
}
