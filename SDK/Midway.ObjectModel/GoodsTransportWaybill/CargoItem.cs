using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Грузовая позиция в ТТН.
    /// </summary>
    [DataContract]
    public class CargoItem
    {
        /// <summary>
        /// Краткое наименование.
        /// </summary>
        [DataMember]
        public string ShortName { get; set; }

        /// <summary>
        /// Вид упаковки.
        /// </summary>
        [DataMember]
        public string PackageType { get; set; }

        /// <summary>
        /// Количество мест.
        /// </summary>
        [DataMember]
        public decimal? AreaCount { get; set; }

        /// <summary>
        /// Количество мест прописью.
        /// </summary>
        [DataMember]
        public string AreaCountText { get; set; }

        /// <summary>
        /// Способ определения массы.
        /// </summary>
        [DataMember]
        public string WeightDefinitionMethod { get; set; }

        /// <summary>
        /// Код груза.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Номер контейнера.
        /// </summary>
        [DataMember]
        public string ContainerNumber { get; set; }

        /// <summary>
        /// Класс груза.
        /// </summary>
        [DataMember]
        public string Class { get; set; }

        /// <summary>
        /// Масса брутто.
        /// </summary>
        [DataMember]
        public decimal? GrossWeight { get; set; }

        /// <summary>
        /// Список сопроводительных документов.
        /// </summary>
        [DataMember]
        public List<ShippingDocument> ShippingDocuments { get; set; }
    }
}