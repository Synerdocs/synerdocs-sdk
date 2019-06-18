using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Документ, подтверждающий отгрузку товаров (работ, услуг, имущественных прав).
    /// </summary>
    [DataContract]
    public class ShippingDocumentApprovement
    {
        /// <summary>
        /// Наименование документа об отгрузке.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        /// <summary>
        /// Номер документа об отгрузке.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Number { get; set; }

        /// <summary>
        /// Дата документа об отгрузке.
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? Date { get; set; }
    }
}
